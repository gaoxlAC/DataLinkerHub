using NengHuan.Database.MySQL.ModelsManage;
using NengHuan.Database.SqLite;
using NengHuan.Database.VO;
using NengHuan.Forms;
using NengHuan.Models.Sjcj;
using Opc.Ua;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace NengHuan.Database.MySQL.Service
{
    // 设备信息的操作放在这个类中
    public class DeviceManageService
    {
        /// <summary>
        ///   显示所有设备信息
        /// </summary>
        /// <returns></returns>
        public List<BaseDataDevice> ShowDeviceInfos()
        {
            List<BaseDataDevice> deviceInfoManages = new List<BaseDataDevice>();          
            try
            {
                // 获取所有设备信息
                deviceInfoManages = new BaseDataDeviceManages().GetList();
                //PrintDeviceInfos(mergedDeviceInfoList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("数据查询失败，失败原因为：");
                Console.WriteLine(ex.Message);
            }
            return deviceInfoManages;
        }

        /// <summary>
        /// 根据设备编号、设备名称、设备类型名称和设备安装位置进行查询设备信息。
        /// </summary>     
        /// <param name="deviceName">设备名称，用于筛选设备名称包含指定字符串的设备信息。可以为空。</param>
        /// <returns></returns>
        public List<BaseDataDevice> SearchDeviceInfo(string deviceName)
        {

            List<BaseDataDevice> results = ShowDeviceInfos();  // 获取所有设备信息列表

            Console.WriteLine("查询前：");
            PrintDeviceInfosByNodes(results);

            // 根据输入的查询条件进行模糊匹配过滤
            results = results.Where(d =>
                (string.IsNullOrEmpty(deviceName) || d.DeviceName.Contains(deviceName))
            ).ToList();

            Console.WriteLine("查询后：");
            PrintDeviceInfosByNodes(results);
            return results;
        }

        /// <summary>
        /// 从数据库中获取最新的数据以设备类型为单位
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, DeviceTypeInfoVO> GetRealTimeDeviceInfoByType()
        {
            // 先获取所有设备类型
            List<string> deviceTypes = new DictDeviceTypeManages().GetAllDeviceTypes();

            // 创建存放结果的字典
            Dictionary<string, DeviceTypeInfoVO> resultDict = new Dictionary<string, DeviceTypeInfoVO>();

            // 先获取所有设备及其点位信息
            List<DeviceInfoVO> deviceInfos = GetRealTimeDeviceInfo();
            foreach (DeviceInfoVO deviceInfo in deviceInfos)
            {
                if(!resultDict.ContainsKey(deviceInfo.TypeName))
                {
                    // 创建 DeviceTypeInfoVO 对象
                    DeviceTypeInfoVO deviceTypeInfoVO = new DeviceTypeInfoVO
                    {
                        DeviceTypeName = deviceInfo.TypeName,
                        ReadFrequency = 1000,  // 这里需要你设置读取频率的逻辑
                        Devices = new List<DeviceInfoVO>()
                    };
                    // 将设备类型添加到字典中
                    resultDict.Add(deviceInfo.TypeName, deviceTypeInfoVO);
                }
                // 将设备信息添加到deviceTypeInfoVO的device中
                resultDict[deviceInfo.TypeName].Devices.Add(deviceInfo);
            }

            return resultDict;
        }

        /// <summary>
        /// 获取设备信息、对应的状态信息、数据值，并实时返回
        /// </summary>
        /// <returns></returns>
        public List<DeviceInfoVO> GetRealTimeDeviceInfo()
        {
            // 需要用到的信息：设备名称、安装位置、数据采集的最近时间、各个节点的状态信息
            // 需要用到的表：BaseDataDevice、DeviceNodeState、DeviceAlarm、DeviceFailure、DeviceNodeState、DeviceSwitch、SubtableRealtimeValue

            // 查询BaseDataDevice表获取设备信息列表
            List<BaseDataDevice> baseDataDevices = new BaseDataDeviceManages().GetList();

            // 查询DeviceRealtimeValue表获取实时数据列表
            List<DeviceRealtimeValue> deviceRealtimeValues = new DeviceRealtimeValueManages().GetList();

            // 查询BaseDataNode表获取节点信息列表
            List<BaseDataNode> baseDataNodes = new BaseDataNodeManages().GetList();

            // 创建字典来跟踪已处理的设备类型
            Dictionary<string, DeviceInfoVO> deviceInfoDict = new Dictionary<string, DeviceInfoVO>();

            // 手动编号
            int sort = 0;
            foreach (var baseDataDevice in baseDataDevices)
            {
                // 获取设备名称和点位描述
                string deviceName = baseDataDevice.DeviceName;
                string nodeDescribe = baseDataDevice.NodeDescribe;

                if (deviceName == null || nodeDescribe == null) continue;

                // 查询DeviceRealtimeValue表获取对应的实时数据记录
                var realtimeValue = deviceRealtimeValues.FirstOrDefault(d => d.DeviceName == deviceName && d.NodeDescribe == nodeDescribe);

                // 检查设备类型是否已处理过
                if (!deviceInfoDict.ContainsKey(deviceName))
                {
                    // 创建DeviceInfoVO对象
                    DeviceInfoVO deviceInfo = new DeviceInfoVO
                    {
                        Sort = ++sort,
                        DeviceId = baseDataDevice.DeviceId,
                        DeviceName = baseDataDevice.DeviceName,
                        TypeId = baseDataDevice.TypeId,
                        TypeName = baseDataDevice.TypeName,
                        ParentDeviceName = baseDataDevice.ParentDeviceName,
                        ParentSystemName = baseDataDevice.SystemName,
                        Location = baseDataDevice.Location,
                        CreateTime = baseDataDevice.CreateTime,
                        ModifyTime = baseDataDevice.ModifyTime,
                        IsCollection = true,
                        NodeInfos = new List<NodeInfoVO>()
                    };

                    // 获取 DeviceTypeInfoVO 对象
                    deviceInfoDict.Add(deviceName,deviceInfo);
                }

                // 获取DeviceInfoVO对象
                DeviceInfoVO deviceInfoVO = deviceInfoDict[deviceName];

                // 添加NodeInfoVO信息
                if (realtimeValue != null)
                {
                    // 创建NodeInfoVO对象
                    NodeInfoVO nodeInfo = new NodeInfoVO
                    {
                        NodeId = baseDataDevice.NodeId,
                        NodeDescribe = baseDataDevice.NodeDescribe,
                        Value = realtimeValue.Value,                       
                        CollectTime = realtimeValue.CollectTime
                    };

                    // 获取节点信息中的Unit                   
                    var baseDataNode = baseDataNodes.FirstOrDefault(n => n.DeviceName == deviceName && n.NodeDescribe == nodeDescribe);
                    if (baseDataNode != null)
                    {
                        nodeInfo.Unit = baseDataNode.Unit;
                    }

                    // 将NodeInfoVO对象添加到DeviceInfoVO的NodeInfos列表中
                    deviceInfoVO.NodeInfos.Add(nodeInfo);                   
                }
            }
            // 打印测试
            // PrintDeviceInfos(deviceInfoDict.Values.ToList());
            return deviceInfoDict.Values.ToList();
        }

        /// <summary>
        /// 从数据库中读取设备类型的读取频率
        /// </summary>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        private int ReadFrequencyFromDatabase(string deviceType)
        {
            // 根据需要从数据库中读取设备类型的读取频率
            // 这里仅为示例，你需要替换成实际的数据库查询逻辑
            return 1000; // 假设默认读取频率为 1000 毫秒
        }

        /// <summary>
        /// 打印设备信息及其所属的点位信息（以设备为基本单位）
        /// </summary>
        /// <param name="deviceInfos">设备信息列表</param>
        public void PrintDeviceInfos(List<DeviceInfoVO> deviceInfos)
        {
            foreach (var deviceInfo in deviceInfos)
            {
                Console.WriteLine("设备序号: {0}", deviceInfo.Sort);
                Console.WriteLine("设备编码: {0}", deviceInfo.DeviceId);
                Console.WriteLine("设备名称: {0}", deviceInfo.DeviceName);
                Console.WriteLine("设备类型编码: {0}", deviceInfo.TypeId);
                Console.WriteLine("设备类型名称: {0}", deviceInfo.TypeName);
                Console.WriteLine("所属父设备名称: {0}", deviceInfo.ParentDeviceName);
                Console.WriteLine("所属系统名称: {0}", deviceInfo.ParentSystemName);
                Console.WriteLine("安装位置: {0}", deviceInfo.Location);
                Console.WriteLine("创建时间: {0}", deviceInfo.CreateTime);
                Console.WriteLine("最后一次更新时间: {0}", deviceInfo.ModifyTime);
                Console.WriteLine("点位信息:");

                foreach (var nodeInfo in deviceInfo.NodeInfos)
                {
                    Console.WriteLine("\t点位id: {0}", nodeInfo.NodeId);
                    Console.WriteLine("\t点位描述: {0}", nodeInfo.NodeDescribe);
                    Console.WriteLine("\t监测值: {0}", nodeInfo.Value);
                    Console.WriteLine("\t监测单位: {0}", nodeInfo.Unit);
                    Console.WriteLine("\t最近的采集时间: {0}", nodeInfo.CollectTime);
                    Console.WriteLine();
                }



                Console.WriteLine("----------------------------------------");
            }
        }

        /// <summary>
        /// 以点位为单位打印设备信息
        /// </summary>
        /// <param name="deviceInfos">设备信息实体类列表</param>
        public void PrintDeviceInfosByNodes(List<BaseDataDevice> deviceInfos)
        {
            foreach (BaseDataDevice deviceInfo in deviceInfos)
            {
                Console.WriteLine($"Sid: {deviceInfo.Sid}");
                Console.WriteLine($"Device Name: {deviceInfo.DeviceName}");
                Console.WriteLine($"Device Type: {deviceInfo.TypeName}");
                Console.WriteLine("NodeInfo: \n");               
                Console.Write($"NodeId:{deviceInfo.NodeId}\t");
                Console.Write($"NodeDes:{deviceInfo.NodeDescribe}\t");
                Console.WriteLine($"ParentDeviceName: {deviceInfo.ParentDeviceName}");
                Console.WriteLine($"ParentSystemName: {deviceInfo.SystemName}");
                Console.WriteLine($"Install Location: {deviceInfo.Location}");
                Console.WriteLine($"CreateTime: {deviceInfo.CreateTime}");
                Console.WriteLine($"ModifyTime: {deviceInfo.ModifyTime}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 以设备类型为单位打印信息
        /// </summary>
        /// <param name="resultDict"></param>
        public void PrintDeviceInfosByType(Dictionary<string, DeviceTypeInfoVO> resultDict)
        {
            foreach (var kvp in resultDict)
            {
                Console.WriteLine($"DeviceTypeName: {kvp.Key}, ReadFrequency: {kvp.Value.ReadFrequency}, Devices Count: {kvp.Value.Devices.Count}");

                foreach (var deviceInfo in kvp.Value.Devices)
                {
                    Console.WriteLine($"DeviceId: {deviceInfo.DeviceId}, DeviceName: {deviceInfo.DeviceName}, TypeId: {deviceInfo.TypeId}, TypeName: {deviceInfo.TypeName}, ...");

                    foreach (var nodeInfo in deviceInfo.NodeInfos)
                    {
                        Console.WriteLine($"NodeId: {nodeInfo.NodeId}, NodeDescribe: {nodeInfo.NodeDescribe}, Value: {nodeInfo.Value}, CollectTime: {nodeInfo.CollectTime}, ...");
                    }
                }
            }
        }

    }
}
