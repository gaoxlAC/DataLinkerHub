using NengHuan.Database.MySQL.ModelsManage;
using NengHuan.Database.MySQL.Utils;
using NengHuan.Database.SeparateTable;
using NengHuan.Database.VO;
using NengHuan.Forms.Common;
using NengHuan.Models.Sjcj;
using NengHuan.OPCUA;
using NengHuan.UI;
using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace NengHuan.Database.MySQL.Service
{
    /// <summary>
    /// 设备实时数据和历史入库的相关操作
    /// </summary>
    public class DeviceDataService
    {

        /// <summary>
        /// 客户端对象
        /// </summary>
        private OpcUaClient m_OpcUaClient;  // 获取ServiceConnect中的唯一m_OpcUaClient
        private List<string> nodeList;    // 存储当前opc服务器上的所有NodeId：通道.设备.点位
        //private BaseDataNodeManages baseDataNodeManages;    // 需要一些对节点的操作
        /// <summary>
        /// 通过构造函数连接服务器
        /// </summary>
        public DeviceDataService()
        {        
            m_OpcUaClient = new ServiceConnect().GetOpcUaClient();  // 直接获取已经连接的客户端对象
        }


        // 需要用到的功能：
        // 1.读取所有点位Id和对应的点位信息
        // 2.拆分点位信息为：passage、node_describe、device_name、vlaue、collect_time、quality（对应state）
        // 3.将拆分后的数据入库（先入实时数据库）
        // 4.将入库成功的数据的显示在客户端界面

        #region 实时数据和历史数据入库
        /// <summary>
        /// 读取节点任务
        /// </summary>
        public Task ReadNodesTask;
        /// <summary>
        /// 取消任务对象
        /// </summary>
        public CancellationTokenSource CTS;

        /// <summary>
        /// 通过异步读取的方法对实时数据进行入库操作
        /// </summary>
        public void RealTimeToDB()
        {
            try
            {
                // 判断m_OpcUaClient是否为空，若为空则取消读取任务
                if (m_OpcUaClient == null)
                {
                    // 还没连接服务器，需要到服务器配置那里先连接
                    Console.WriteLine("DeviceDataService:还没连接服务器，需要到服务器配置那里先连接");
                    return;
                }

                // 设置一个读取点位信息的标记
                CTS = new CancellationTokenSource();
                ReadNodesTask = Task.Run(() => GetAllNodeInfosToDB(CTS.Token), CTS.Token);  // 循环采集数据并入库
            }
            catch
            {
                // 窗口输出读取点位信息失败
                MessageBox.Show("读取点位信息失败！");
            }
        }

        /// <summary>
        /// 停止实时数据入库
        /// </summary>
        public void StopRealTimeToDBAsync()
        {
            try
            {
                // 判断取消任务对象是否为空，不为空则取消任务
                if (CTS != null)
                {
                    CTS.Cancel();//取消任务
                    CTS = null;
                    ReadNodesTask = null;
                }               
            }
            catch
            {
                // 窗口输出读取点位信息失败
                MessageBox.Show("停止读取失败！");
            }
        }

        /// <summary>
        /// 从OPC服务器上读取所有点位信息并入库
        /// </summary>
        /// <returns></returns>
        private async Task GetAllNodeInfosToDB(CancellationToken token) 
        {    

            // 将NodeId封装到OPC自带的NodeId列表中
            List<NodeId> nodeIds = new List<NodeId>();
            
            // 该方法执行之前已经确定服务器已连接，否则无法触发该方法
            nodeList = new BaseDataNodeManages().GetAllNodeIds();

            foreach (string nodeId in nodeList)
            {
                nodeIds.Add(new NodeId(nodeId));
            }

            // 将点位信息存储在OPCUA自带的DataValue中
            List<DataValue> dataValues = null;

            // 当标记没有被取消时，可以一直从opc服务器上读取数据并入库
            // 设置两个循环方式：1.全部开始的循环方式；2.非全部开始的循环方式
            // 按照设备类型划分：

            while (true)
            {
                // 判断标记是否被取消
                if (token.IsCancellationRequested)
                {
                    break;
                }               
                // 点击了全部开始采集按钮
                if(FMain.isAll == 1)
                {
                    // 测试执行时间
                    DateTime startTime = DateTime.Now;
                    dataValues = await m_OpcUaClient.ReadNodesAsync(nodeIds.ToArray()); // 异步读取
                    //dataValues = m_OpcUaClient.ReadNodes(nodeIds.ToArray()); // 同步读取
                    //DateTime endTime = DateTime.Now;
                    //TimeSpan ts = endTime - startTime;
                    // 输出执行时间
                    //Console.WriteLine("执行时间：" + ts.TotalMilliseconds + "ms");
                    //Console.WriteLine(dataValues);
                }
                // 点击了全部停止采集按钮，结束采集任务
                else if (FMain.isAll == 0)
                {
                    break;
                }
                // 否则根据每台设备的采集状态来进行采集，按照设备类型进行分类
                //  采集之前，要获取FMain中按设备类型划分的：设备下的各种点位的采集状态、设备名称以及点位信息、设备类型下的采集频率。
                //  只需要知道那些设备没有采集，然后转化为对应的nodeIds
                //  设计字典：Dictionary<string, DeviceInfoVO>:{"温度传感器_5000", {"温度传感器1", {"温度","32","℃"}}
                else
                {
                    break;
                }
                if(dataValues.Count > 0)
                {
                    // 封装好实时数据信息
                    List<DeviceRealtimeValue> deviceRealtimeValues = new List<DeviceRealtimeValue>();

                    //deviceRealtimeValues = SplitNodeInfos(dataValues);

                    for (int i=0;i< dataValues.Count; i++)
                    {
                        DeviceRealtimeValue deviceRealtimeValue = new DeviceRealtimeValue();
                        string passageDeviceNode = nodeList[i];
                        deviceRealtimeValue.PassageDeviceNode = passageDeviceNode;
                        // 如果读取的值不为空则进行赋值，否则赋值为空
                        if (dataValues[i] != null)
                        {
                            deviceRealtimeValue.Value = dataValues[i].WrappedValue.Value == null ? "-1" : dataValues[i].WrappedValue.Value.ToString();
                        }
                        else
                        {
                            deviceRealtimeValue.Value = "-1"; // 设置为空值
                        }

                        // 数据采集的时间记录下来（无论时有效数据还是无效数据）
                        deviceRealtimeValue.CollectTime = dataValues[i].SourceTimestamp.ToLocalTime();
                        deviceRealtimeValue.State = StatusCode.IsGood(dataValues[i].StatusCode);  // 0-无效，1-有效
                        // 输出实时数据信息
                        Console.WriteLine("测试：" + deviceRealtimeValue.PassageDeviceNode + " " + deviceRealtimeValue.Value  + " " + deviceRealtimeValue.CollectTime + " " + deviceRealtimeValue.State);

                        deviceRealtimeValues.Add(deviceRealtimeValue);
                    }
                    // 将实时数据信息存储到实时数据库中
                    DeviceRealtimeValueManages deviceRealtimeValueManages = new DeviceRealtimeValueManages();
                    deviceRealtimeValueManages.InsertBatches(deviceRealtimeValues);
                    Console.WriteLine("数据插入成功！");
                    //await Task.Run(() =>
                    //{
                    //    DeviceRealtimeValueManages deviceRealtimeValueManages = new DeviceRealtimeValueManages();
                    //    int insertFlag = deviceRealtimeValueManages.InsertBatches(deviceRealtimeValues);
                    //    if(insertFlag == 0)
                    //    {
                    //        MessageBox.Show("OPC服务器中的点位信息为空!");
                    //    }
                    //});


                    // 将实时数据信息存储到实时数据库中
                    //await NodeInfosRealTimeToDB(deviceRealtimeValues);
                    

                    // 将实时数据插入到历史数据子表中
                    //await NodeInfosToHistoryDB(deviceRealtimeValues);
                }
                else
                {
                    // 异步方法中使用 MessageBox.Show 可能导致线程问题，最好在 UI 线程上调用
                    await Task.Run(() => MessageBox.Show("OPC服务器中的点位信息为空!"));
                }
                // 停止1s
                // await Task.Delay(1000);
            }
        }

        /// <summary>
        /// 拆分点位信息以便录入到数据库
        /// </summary>
        /// <param name="nodeInfos"></param>
        private List<DeviceRealtimeValue> SplitNodeInfos(List<DataValue> dataValues)
        {
            List<DeviceRealtimeValue> deviceRealtimeValues = new List<DeviceRealtimeValue>();
           
            // 拆分OPC的NodeId转为实时数据库DeviceRealTimeValue对应的字段
            // 如果点位信息不空则进行拆分，否则给出提示
            if(dataValues.Count > 0)
            {
                // 自己写的一个OpcUa的工具类，主要用于处理NodeId
                //OpcNodeIdUtils opcNodeIdUtils = new OpcNodeIdUtils();
                for (int i = 0; i < dataValues.Count; i++)
                {
                    DeviceRealtimeValue deviceRealtimeValue = new DeviceRealtimeValue();
                    //string passageName = opcNodeIdUtils.GetPassageName(nodeList[i]);
                    //string deviceName = opcNodeIdUtils.GetDeviceName(nodeList[i]);
                    //string nodeDescribe = opcNodeIdUtils.GetNodeDescription(nodeList[i]);
                    //deviceRealtimeValue.Passage = passageName;
                    //deviceRealtimeValue.DeviceName = deviceName;
                    //deviceRealtimeValue.NodeDescribe = nodeDescribe;
                    //直接把NodeId赋值给passageDeviceNode
                    string passageDeviceNode = nodeList[i];
                    deviceRealtimeValue.PassageDeviceNode = passageDeviceNode;
                    // 如果读取的值不为空则进行赋值，否则赋值为空
                    if (dataValues[i] != null)
                    { 
                        deviceRealtimeValue.Value = dataValues[i].WrappedValue.Value == null ? "" : dataValues[i].WrappedValue.Value.ToString(); 
                    }
                    else
                    {
                        deviceRealtimeValue.Value = ""; // 设置为空值
                    }

                    // 数据采集的时间记录下来（无论时有效数据还是无效数据）
                    deviceRealtimeValue.CollectTime = dataValues[i].SourceTimestamp.ToLocalTime();
                    deviceRealtimeValue.State = StatusCode.IsGood(dataValues[i].StatusCode);  // 0-无效，1-有效
                    deviceRealtimeValues.Add(deviceRealtimeValue);
                }
                return deviceRealtimeValues;
            }
            Console.WriteLine("读取的opc服务器结点为空！");
            return deviceRealtimeValues;
        }

        /// <summary>
        /// 将拆分好的点位信息录入到实时数据库中
        /// </summary>
        /// <returns></returns>
        private async Task NodeInfosRealTimeToDB(List<DeviceRealtimeValue> deviceRealtimeValues)
        {

            // 使用sqlsugar将DeviceRealtimeValue插入到数据库，使用try-catch语句
            try
            {
                // 根据设备名称更新数据库
                // 1.先根据设备名称查询数据库中是否有该设备的信息
                // 2.如果有则更新，如果没有则插入

                // 获取实时数据库中的所有点位信息
                //List<DeviceRealtimeValue> deviceRealtimes = new DeviceRealtimeValueManages().GetList();

                // 获取实时数据库中的设备名称并去重
                //List<string> deviceNames = null;
                //deviceNames = deviceRealtimes.Select(deviceRealtime => deviceRealtime.DeviceName).Distinct().ToList();
                // 输出deviceName（测试已通过）
                //if(deviceNames.Count > 0)
                //{
                //    Console.WriteLine("实时数据库中有数据");
                //    foreach (string deviceName in deviceNames)
                //    {
                //        Console.WriteLine("deviceName:" + deviceName);
                //    }
                //}
                
                // 创建一个插入的实体类列表deviceRealtimeValueInsert
                //List<DeviceRealtimeValue> deviceRealtimeValueInsert = new List<DeviceRealtimeValue>();

                // 创建一个更新的实体类列表deviceRealtimeValueUpdate
                //List<DeviceRealtimeValue> deviceRealtimeValueUpdate = new List<DeviceRealtimeValue>();

                // 插入和更新实时数据
                //foreach (DeviceRealtimeValue deviceRealtimeValue in deviceRealtimeValues)
                //{
                //    // 如果实时数据库中有该设备的信息
                //    if (deviceNames.Contains(deviceRealtimeValue.DeviceName))
                //    {
                //        // 从deviceRealtimes中找到deviceRealtimeValue的记录（有DeviceName和NodeDescribe确定唯一的记录）
                //        DeviceRealtimeValue deviceRealtime = deviceRealtimes.
                //            Where(it => it.DeviceName == deviceRealtimeValue.DeviceName).
                //            Where(it => it.NodeDescribe == deviceRealtimeValue.NodeDescribe).
                //            FirstOrDefault();
                //        // 且Value值或者State值无论发生变化与否都要做更新
                //        //Console.WriteLine("Sid:"+deviceRealtime.Sid);
                //        deviceRealtimeValue.Sid = deviceRealtime.Sid;
                //        deviceRealtimeValue.DelFlag = false;
                //        deviceRealtimeValueUpdate.Add(deviceRealtimeValue);
                //    }

                //    // 如果实时数据库中没有有该设备的信息，则插入
                //    else if (!deviceNames.Contains(deviceRealtimeValue.DeviceName))
                //    {
                //        deviceRealtimeValue.DelFlag = false;
                //        deviceRealtimeValueInsert.Add(deviceRealtimeValue);
                //    }
                //}
               /* foreach(DeviceRealtimeValue deviceRealtimeValue in deviceRealtimeValues)
                {
                    deviceRealtimeValueInsert.Add(deviceRealtimeValue);
                }*/
                


                // 输出实体类列表
               /* Console.WriteLine("插入的数据有:");
                foreach (DeviceRealtimeValue deviceRealtimeValue in deviceRealtimeValueInsert)
                {
                    // 输出deviceRealtimeValue的值
                    Console.WriteLine(deviceRealtimeValue.Passage);
                    Console.WriteLine(deviceRealtimeValue.DeviceName);
                    Console.WriteLine(deviceRealtimeValue.NodeDescribe);
                    Console.WriteLine(deviceRealtimeValue.State);
                    Console.WriteLine(deviceRealtimeValue.Value);
                    Console.WriteLine(deviceRealtimeValue.CollectTime);
                }*/

                /*Console.WriteLine("更新的数据有:");
                foreach(DeviceRealtimeValue deviceRealtimeValue2 in deviceRealtimeValueUpdate)
                {
                    // 输出deviceRealtimeValue的值
                    Console.WriteLine(deviceRealtimeValue2.Sid); 
                    Console.WriteLine(deviceRealtimeValue2.Passage);
                    Console.WriteLine(deviceRealtimeValue2.DeviceName);
                    Console.WriteLine(deviceRealtimeValue2.NodeDescribe);
                    Console.WriteLine(deviceRealtimeValue2.State);
                    Console.WriteLine(deviceRealtimeValue2.Value);
                    Console.WriteLine(deviceRealtimeValue2.CollectTime);
                }*/

                DeviceRealtimeValueManages deviceRealtimeValueManages = new DeviceRealtimeValueManages();
                
                // 如何更新列表不为空则更新
                /*if (deviceRealtimeValueUpdate.Count > 0) 
                {
                    int resUpdate = deviceRealtimeValueManages.UpdateBatches(deviceRealtimeValueUpdate);

                }*/

                // 如果插入列表不为空则插入
                if (deviceRealtimeValues.Count > 0)
                {
                    int resInsert = deviceRealtimeValueManages.InsertBatches(deviceRealtimeValues);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("插入或更新实时数据失败！"+e.Message);            
            }
        }

        /// <summary>
        /// 将从服务器读到的实时数据插入到历史数据当中（只做插入操作）
        /// </summary>
        /// <param name="deviceRealtimeValues"></param>
        /// <returns></returns>
        public async Task NodeInfosToHistoryDB(List<DeviceRealtimeValue> deviceRealtimeValues)
        {
            // 使用sqlsugar将DeviceRealtimeValues插入历史数据库中
            try
            {
                // 要插入的历史数据
                foreach (DeviceRealtimeValue deviceRealtimeValue in deviceRealtimeValues)
                {
                    // 输出deviceRealtimeValue的值
                    Console.WriteLine(deviceRealtimeValue.Passage);
                    Console.WriteLine(deviceRealtimeValue.DeviceName);
                    Console.WriteLine(deviceRealtimeValue.NodeDescribe);
                    Console.WriteLine(deviceRealtimeValue.State);
                    Console.WriteLine(deviceRealtimeValue.Value);
                    Console.WriteLine(deviceRealtimeValue.CollectTime);
                }

                // 有数据才插入
                if (deviceRealtimeValues.Count > 0)
                {
                    // 使用插入历史数据接口，要求传递的参数：实时数据、子表的存储日期、子表名
                    DateTime collectDate = DateTime.Now.Date;      // 获取当前系统日期
                    string subTableName = $"subtable_value{collectDate.ToString("yyyyMMdd")}"; // 获取表名
                    HistoryTable historyTable = new HistoryTable();
                    historyTable.InsertDataToHistoryTable(deviceRealtimeValues, collectDate, subTableName);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("插入历史数据失败" + e.Message);
            }
        }
        #endregion

        #region 控制点位状态
        readonly DeviceRealtimeValueWriteManages deviceRealtimeValueWriteManages = new DeviceRealtimeValueWriteManages();
        /// <summary>
        /// 使用定时器执行控制功能，设置为每5s执行一次
        /// </summary>
        public void StartControlLoop()
        {
            // 这里使用 Timer 定期执行控制逻辑
            var controlTimer = new Timer
            {
                Interval = 5000  // 设置为每隔5秒执行一次，可以根据需要调整
            };
            controlTimer.Tick += ControlTimer_Tick;
            controlTimer.Start();
        }
        /// <summary>
        /// 定时器控制事件，写状态到opc服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ControlTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("开始执行控制功能触发事件");
                // 从数据库中获取所有设备的实时数据
                List<DeviceRealtimeValueWrite> deviceRealtimeValues = deviceRealtimeValueWriteManages.GetList();

                // 遍历每个设备的实时数据
                foreach (var deviceRealtimevalueControl in deviceRealtimeValues)
                {
                    // 获取之前保存的状态
                    string previousState = GetPreviousStateFromSomewhere(deviceRealtimevalueControl.PassageDeviceNode);

                    // 获取当前状态
                    string currentState = deviceRealtimevalueControl.Value.ToString();

                    // 若不为空且未发生变化，则不写入。
                    if (previousState != null && previousState == currentState)
                    {
                        continue;
                    }

                    // 否则直接写入到opc服务器
                    Console.WriteLine($"之前的状态：{previousState} 现在的状态：{currentState}");
                    
                    // 将状态值转为bool类型                    
                    bool state = Convert.ToBoolean(Convert.ToInt32(deviceRealtimevalueControl.Value));
                    // 测试WriteNodeAsync所需执行的时间
                    DateTime startTime = DateTime.Now;
                    //bool writeSuccess = await m_OpcUaClient.WriteNodeAsync(deviceRealtimevalueControl.PassageDeviceNode, state);  // 会导致重复写入的问题
                    bool writeSuccess = m_OpcUaClient.WriteNode(deviceRealtimevalueControl.PassageDeviceNode, state);
                    DateTime endTime = DateTime.Now;
                    TimeSpan timeSpan = endTime - startTime;
                    Console.WriteLine($"写入状态所需时间：{timeSpan.TotalMilliseconds}ms");
                    // 更新状态
                    if(previousState == null)
                    {
                        NodeControlVO nodeControlVO = new NodeControlVO
                        {
                            PassageDeviceNode = deviceRealtimevalueControl.PassageDeviceNode,
                            Value = deviceRealtimevalueControl.Value
                        };
                        FMain.nodeControlVOs.Add(nodeControlVO);                      
                    }
                    else FMain.nodeControlVOs.Where(it => it.PassageDeviceNode == deviceRealtimevalueControl.PassageDeviceNode).FirstOrDefault().Value = currentState;

                    if (!writeSuccess)
                    {
                        MessageBox.Show($"点位：{deviceRealtimevalueControl.PassageDeviceNode} 状态值：{deviceRealtimevalueControl.Value} 未写入成功");
                    }
                    else Console.WriteLine($"点位：{deviceRealtimevalueControl.PassageDeviceNode} 状态值：{deviceRealtimevalueControl.Value} 写入成功");
                }
            }
            catch (Exception ex)
            {
                // 处理异常，可以记录日志或者采取其他措施
                Console.WriteLine($"Error in ControlTimer_Tick: {ex.Message}");
            }
        }

        /// <summary>
        /// 获取之前的状态
        /// </summary>
        /// <param name="nodeInfo">点位信息：ns=2;通道.设备.点位</param>
        /// <returns></returns>
        private string GetPreviousStateFromSomewhere(string nodeInfo)
        {
            // 控制点位为空，说明还未存储之前的状态
            if (FMain.nodeControlVOs.Count == 0) return null;

            // 在FMain.nodeControlVOs中查找value值
            NodeControlVO nodeControlVO =  FMain.nodeControlVOs.Where(it => it.PassageDeviceNode == nodeInfo).FirstOrDefault();
            Console.WriteLine($"之前的状态：{nodeControlVO.PassageDeviceNode} {nodeControlVO.Value}");
            return nodeControlVO?.Value.ToString();
        }
        #endregion
        /// <summary>
        /// 显示设备的实时数据
        /// </summary>
        /// <returns></returns>
        public List<DeviceInfoVO> ShowDeviceRealTimeData()
        {
            List<DeviceInfoVO> deviceInfoVOs = new List<DeviceInfoVO>();

            // 这里写逻辑

            return deviceInfoVOs;
        }
    }
}
