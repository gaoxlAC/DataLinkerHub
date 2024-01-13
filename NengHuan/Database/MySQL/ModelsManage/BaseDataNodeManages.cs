using MySqlX.XDevAPI;
using NengHuan.Database.MySQL.Utils;
using NengHuan.Database.VO;
using NengHuan.Models.Sjcj;
using NengHuan.OPCUA;
using NengHuan.UI;
using Opc.Ua;
using Opc.Ua.Export;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NengHuan.Database.MySQL.ModelsManage
{
    /// <summary>
    /// 设备点位信息管理，包括对点位信息的添加、删除、读取、更新、订阅等功能
    /// </summary>
    class BaseDataNodeManages : DbContext_MySQL<BaseDataNode>
    {
        /// <summary>
        /// 客户端连接对象
        /// </summary>
        private OpcUaClient _client = null;

        /// <summary>
        /// 使用点位信息管理功能之前要确保服务器处于已连接状态
        /// </summary>
        public  BaseDataNodeManages()
        {
           _client = new ServiceConnect().GetOpcUaClient();
        }

        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <returns></returns>
        public bool IsExist()
        {
            try
            {
                CurrentDb.GetList();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 通过id删除表
        /// </summary>
        /// <param name="id"></param>
        internal void DeleteById(string id)
        {
            CurrentDb.Delete(it => it.NodeId == id);
        }

        /// <summary>
        /// 获取所有点位信息
        /// </summary>
        /// <returns></returns>
        public override List<BaseDataNode> GetList()
        {
            return Db.Queryable<BaseDataNode>().Where(it => it.DelFlag == false || it.DelFlag == null).OrderBy(it => it.Sid).ToList();
        }

        /// <summary>
        /// 插入点位信息
        /// </summary>
        /// <param name="baseDataNode"></param>
        /// <returns></returns>
        public string InsertNodeInfo(BaseDataNode baseDataNode)
        {
            try
            {
                Db.Insertable(baseDataNode).ExecuteCommand();
                return "插入点位信息成功";
            }
            catch (Exception)
            {
                return "插入点位信息失败";
            }
        }

        /// <summary>
        /// 通过id获取点位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override BaseDataNode GetById(string id)
        {
            return Db.Queryable<BaseDataNode>()
                .Where(it => it.DelFlag == false || it.DelFlag == null)
                .Where(it => it.NodeId == id).First();
        }

        /// <summary>
        /// 获取指定设备id下的所有点位信息
        /// </summary>
        public void FilterAndStoreNodes()
        {
            if ( _client == null ) 
            {
                MessageBox.Show("未连接服务器！"); 
                return; 
            }
            NodeId sourceId = new NodeId(ObjectIds.ObjectsFolder); // 服务器的源结点 NodeId

            List<BaseDataNode> nodesToStore = new List<BaseDataNode>(); // 收集需要存储的结点信息

            // 找到点位结点，即代表点位的结点
            FindPointLocation(sourceId, nodesToStore);

            foreach (BaseDataNode node in nodesToStore)
            {
                Console.WriteLine($"Node Id: {node.NodeId}");
                Console.WriteLine($"Node Describe: {node.NodeDescribe}");
                Console.WriteLine($"Device Id: {node.DeviceId}");
                Console.WriteLine($"Device Name: {node.DeviceName}");
                Console.WriteLine();
            }

            //存储过滤后的结点到数据库
            //Db.Insertable(nodesToStore).ExecuteCommand();

            // 发送窗口信息，数据添加成功
            MessageBox.Show("数据添加成功");
        }

        /// <summary>
        /// 获取系统上所有的点位Id
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllNodeIds()
        {
            if (_client == null ) 
            {
                //Console.WriteLine("BaseDataNodeManages.GetAllNodeIds:服务器为空");
                return null;
            }
            NodeId sourceId = new NodeId(ObjectIds.ObjectsFolder); // 服务器的源结点 NodeId

            List<BaseDataNode> nodesToStore = new List<BaseDataNode>(); // 收集需要存储的结点信息

            // 找到点位结点，即代表点位的结点
            FindPointLocation(sourceId, nodesToStore);

            List<string> nodeIds = new List<string>();

            foreach (BaseDataNode node in nodesToStore)
            {
                nodeIds.Add(node.NodeId);
            }

            // 输出nodeIds
            foreach (string nodeId in nodeIds)
            {
                Console.WriteLine($"Node Id: {nodeId}");
            }
            return nodeIds;
        }

        /// <summary>
        /// 找到最后一层的结点，并过滤掉不必要的结点
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="db"></param>

        private void FindPointLocation(NodeId nodeId, List<BaseDataNode> nodesToStore)
        {
            ReferenceDescriptionCollection references = GetReferenceDescriptionCollection(nodeId);

            //foreach (ReferenceDescription reference in references)
            //{
            //    Console.WriteLine("过滤前----------Reference: {0}, NodeId: {1}", reference.DisplayName.Text, reference.NodeId);
            //}

            // 先过滤掉不用的信息
            references = FilterReferences(references);

            //Console.WriteLine("------------------------");
            //foreach (ReferenceDescription reference in references)
            //{
            //    Console.WriteLine("过滤后---------Reference: {0}, NodeId: {1}", reference.DisplayName.Text, reference.NodeId);
            //}

            // 递归调用，继续查找下一个层级的节点
            foreach (var reference in references)
            {
                NodeId childNodeId = (NodeId)reference.NodeId;

                //Console.WriteLine("\n当前节点：{0}",childNodeId.ToString());

                // 结点层级小于三层结点，则继续往下找
                if(childNodeId.ToString().Split('.').Length < 3)
                {
                    // 继续查找下一层节点
                    FindPointLocation(childNodeId, nodesToStore);
                }

                // 判断是否为第三层节点，因为点位结点是由两个分隔符‘.’组成的三段字符串
                else if(childNodeId.ToString().Split('.').Length == 3)
                {
                    // 继续判断是否为点位节点
                    // Console.WriteLine("\n点位节点：childNodeId={0}", childNodeId);
                    // 判断GetNodeType是否出现异常，若出现异常则给出提示并继续读取下一个节点
                    try
                    {
                        if (GetNodeType(childNodeId) == NodeClass.Variable)
                        {
                            // 测试分割后的字符串
                            // Console.WriteLine($"{childNodeId.ToString()}");
                            // Console.WriteLine($"{GetPassageName(childNodeId.ToString())}");
                            // Console.WriteLine($"{GetNodeDescription(childNodeId.ToString())}");
                            // Console.WriteLine($"{GetDeviceName(childNodeId.ToString())}");

                            OpcNodeIdUtils opcNodeIdUtils = new OpcNodeIdUtils();
                            var node = new BaseDataNode
                            {
                                NodeId = childNodeId.ToString(),
                                NodeDescribe = opcNodeIdUtils.GetNodeDescription(childNodeId.ToString()),
                                DeviceId = opcNodeIdUtils.GetParentDeviceId(childNodeId.ToString()),
                                DeviceName = opcNodeIdUtils.GetDeviceName(childNodeId.ToString())
                            };
                            // 控制台输出最后一个层级的节点
                            // Console.WriteLine($"Node - NodeId: {node.NodeId}, NodeDescribe:{node.NodeDescribe}, DeviceId:{node.DeviceId}, DeviceName:{node.DeviceName}");

                            // 将点位信息添加到nodesToStore中
                            nodesToStore.Add(node);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(childNodeId + "节点发生故障，无法获取");
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// 浏览节点下的直接子节点
        /// </summary>
        /// <param name="sourceId"></param>
        /// <returns></returns>
        private ReferenceDescriptionCollection GetReferenceDescriptionCollection(NodeId sourceId)
        {
            TaskCompletionSource<ReferenceDescriptionCollection> task = new TaskCompletionSource<ReferenceDescriptionCollection>();

            // find all of the components of the node.
            BrowseDescription nodeToBrowse1 = new BrowseDescription();

            nodeToBrowse1.NodeId = sourceId;
            nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.Aggregates;
            nodeToBrowse1.IncludeSubtypes = true;
            nodeToBrowse1.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable | NodeClass.Method | NodeClass.ReferenceType | NodeClass.ObjectType | NodeClass.View | NodeClass.VariableType | NodeClass.DataType);
            nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

            // find all nodes organized by the node.
            BrowseDescription nodeToBrowse2 = new BrowseDescription();

            nodeToBrowse2.NodeId = sourceId;
            nodeToBrowse2.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse2.ReferenceTypeId = ReferenceTypeIds.Organizes;
            nodeToBrowse2.IncludeSubtypes = true;
            nodeToBrowse2.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable | NodeClass.Method | NodeClass.View | NodeClass.ReferenceType | NodeClass.ObjectType | NodeClass.VariableType | NodeClass.DataType);
            nodeToBrowse2.ResultMask = (uint)BrowseResultMask.All;

            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            nodesToBrowse.Add(nodeToBrowse1);
            nodesToBrowse.Add(nodeToBrowse2);

            // fetch references from the server.
            ReferenceDescriptionCollection references = FormUtils.Browse(_client.Session, nodesToBrowse, false);
            return references;
        }

        /// <summary>
        /// 如果只想获取通道、设备和点位，而不参考其他隐藏信息的话，则需要过滤掉这些信息
        /// </summary>
        /// <param name="references"></param>
        /// <returns></returns>
        private ReferenceDescriptionCollection FilterReferences(ReferenceDescriptionCollection references)
        {
            // 有其他需要过滤的信息直接在列表中加
            List<string> filteredNames = new List<string>
            {
                "Server",
                "_AdvancedTags",
                "_ConnectionSharing",
                "_CustomAlarms",
                "_DataLogger",
                "_EFMExporter",
                "_IDF_for_Splunk",
                "_IoT_Gateway",
                "_LocalHistorian",
                "_Redundancy",
                "_Scheduler",
                "_SecurityPolicies",
                "_SNMP Agent",
                "_System",
                "_ThingWorx",
                "OPC UA CLIENT",
                "Switch",
                "_CommunicationSerialization",
                "_Statistics",
                "_System",
                "_Statistics",
                "_Hints"
            };

            ReferenceDescriptionCollection filteredReferences = new ReferenceDescriptionCollection();

            foreach (ReferenceDescription reference in references)
            {
                // 判断 reference.DisplayName.Text 是否在过滤列表中
                if (!filteredNames.Contains(reference.DisplayName.Text))
                {
                    // 如果不在过滤列表中，则将该参考描述添加到筛选后的集合中
                    filteredReferences.Add(reference);
                }
            }

            return filteredReferences;
        }


        /// <summary>
        /// 根据NodeId获取该节点的类型
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public NodeClass GetNodeType(NodeId nodeId)
        {
            // 判断nodeId是否为null
            if (NodeId.IsNull(nodeId))
            {
                throw new ArgumentException("获取节点类型失败，NodeId为空");
            }
            // 读取节点
            Node node = _client.Session.ReadNode(nodeId);
            return node.NodeClass;
        }

        public List<NodeInfoVO> GetNodeInfoList()
        {
            List<NodeInfoVO> nodeInfoVOs = new List<NodeInfoVO>();

            // 查询设备信息列表，需要点位id，点位描述，设备id和设备名称，安装位置
            List<BaseDataDevice> deviceList = Db.Queryable<BaseDataDevice>().ToList();

            // 查询点位信息列表，需要点位列表中的单位
            List<BaseDataNode> nodeList = Db.Queryable<BaseDataNode>().ToList();

            // 查询设备状态列表，包括开关状态、预警状态、故障状态和其他状态
            List<DeviceNodeState> stateList = Db.Queryable<DeviceNodeState>().ToList();

            // 查询实时数据列表
            List<DeviceRealtimeValue> realtimeList = Db.Queryable<DeviceRealtimeValue>().ToList();

            // 避免了某一个实体类为空返回结果为空的情况
            nodeInfoVOs = (from node in nodeList
                            join device in deviceList on node.NodeId equals device.NodeId into deviceGroup
                            from device in deviceGroup.DefaultIfEmpty()
                            join state in stateList on node.NodeId equals state.NodeId into stateGroup
                            from state in stateGroup.DefaultIfEmpty()
                            join value in realtimeList on node.NodeId equals value.NodeId into valueGroup
                            from value in valueGroup.DefaultIfEmpty()
                            select new NodeInfoVO
                            {
                                NodeId = node.NodeId,
                                NodeDescribe = node.NodeDescribe,                              
                                Value = value?.Value,
                                Unit = node.Unit,
                                CollectTime = value?.CollectTime ?? DateTime.MinValue
                            }).ToList();
            return nodeInfoVOs;
        }
    }
}

