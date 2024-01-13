using NengHuan.Database.MySQL.ModelsManage;
using NengHuan.Database.MySQL.Service;
using NengHuan.Database.SeparateTable;
using NengHuan.Database.VO;
using NengHuan.OPCUA;
using Opc.Ua;
using Opc.Ua.Client;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NengHuan.Forms.Common
{
    public partial class FormBrowseServer : UIForm
    {
        bool ButtonState = false;

        #region Constructor
        /// <summary>
        /// 允许自己输入服务器地址的实例化
        /// </summary>
        /*public FormBrowseServer()
        {
            InitializeComponent();
            uiLight1.OnColor = Color.Gray;
        }*/
        /// <summary>
        /// 固定地址且不允许更改的实例化
        /// </summary>
        public FormBrowseServer(string server)
        {
            InitializeComponent();

            Icon = ClientUtils.GetAppIcon();
            uiipTextBox.Text = server;
            uiLight1.OnColor = Color.Gray;
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public FormBrowseServer() { }


        #endregion

        #region Load Show Close
        private void FormBrowseServer_Load(object sender, EventArgs e)
        {
            // 判断是否允许更改
            if (!string.IsNullOrEmpty(uiipTextBox.Text)) uiipTextBox.ReadOnly = true;
            // Opc Ua 服务的初始化
            OpcUaClientInitialization();
        }



        private string GetImageKeyFromDescription(ReferenceDescription target, NodeId sourceId)
        {
            if (target.NodeClass == NodeClass.Variable)
            {
                DataValue dataValue = m_OpcUaClient.ReadNode((NodeId)target.NodeId);

                if (dataValue.WrappedValue.TypeInfo != null)
                {
                    if (dataValue.WrappedValue.TypeInfo.ValueRank == ValueRanks.Scalar)
                    {
                        return "Enum_582";
                    }
                    else if (dataValue.WrappedValue.TypeInfo.ValueRank == ValueRanks.OneDimension)
                    {
                        return "brackets";
                    }
                    else if (dataValue.WrappedValue.TypeInfo.ValueRank == ValueRanks.TwoDimensions)
                    {
                        return "Module_648";
                    }
                    else
                    {
                        return "ClassIcon";
                    }
                }
                else
                {
                    return "ClassIcon";
                }
            }
            else if (target.NodeClass == NodeClass.Object)
            {
                if (sourceId == ObjectIds.ObjectsFolder)
                {
                    return "VirtualMachine";
                }
                else
                {
                    return "ClassIcon";
                }
            }
            else if (target.NodeClass == NodeClass.Method)
            {
                return "Method_636";
            }
            else
            {
                return "ClassIcon";
            }
        }

        private void FormBrowseServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_OpcUaClient.Disconnect();
        }

        #endregion

        #region OPC UA client

        /// <summary>
        /// Opc客户端的核心类
        /// </summary>
        private static OpcUaClient m_OpcUaClient = null;

        public OpcUaClient GetOpcUaClient()
        {
            return m_OpcUaClient;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void OpcUaClientInitialization()
        {
            if(m_OpcUaClient == null) m_OpcUaClient = new OpcUaClient();
            //if(m_OpcUaClient == null) m_OpcUaClient = new ServiceConnect().GetOpcUaClient();
            m_OpcUaClient.OpcStatusChange += M_OpcUaClient_OpcStatusChange1; ;
            m_OpcUaClient.ConnectComplete += M_OpcUaClient_ConnectComplete;
        }
        /// <summary>
        /// 连接服务器结束后马上浏览根节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void M_OpcUaClient_ConnectComplete(object sender, EventArgs e)
        {
            try
            {
                OpcUaClient client = (OpcUaClient)sender;
                // 当连接成功后，开始浏览根节点
                if (client.Connected)
                {
                    // populate the browse view.
                    // ObjectIds.ObjectsFolder代表了OPC UA服务器上的Objects节点
                    PopulateBranch(ObjectIds.ObjectsFolder, BrowseNodesTV.Nodes);

                    BrowseNodesTV.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(Text, exception);
            }
        }

        /// <summary>
        /// OPC 客户端的状态变化后的消息提醒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void M_OpcUaClient_OpcStatusChange1(object sender, OpcUaStatusEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    M_OpcUaClient_OpcStatusChange1(sender, e);
                }));
                return;
            }

            if (e.Error)
            {
                toolStripStatusLabel1.BackColor = Color.Red;
            }
            else
            {
                toolStripStatusLabel1.BackColor = SystemColors.Control;
            }

            toolStripStatusLabel_opc.Text = e.ToString();
        }


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
            ReferenceDescriptionCollection references = FormUtils.Browse(m_OpcUaClient.Session, nodesToBrowse, false);
            return references;
        }

        /// <summary>
        /// 0:NodeClass  1:Value  2:AccessLevel  3:DisplayName  4:Description
        /// </summary>
        /// <param name="nodeIds"></param>
        /// <returns></returns>
        private DataValue[] ReadOneNodeFiveAttributes(List<NodeId> nodeIds)
        {
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();
            foreach (var nodeId in nodeIds)
            {
                NodeId sourceId = nodeId;
                nodesToRead.Add(new ReadValueId()
                {
                    NodeId = sourceId,
                    AttributeId = Attributes.NodeClass
                });
                nodesToRead.Add(new ReadValueId()
                {
                    NodeId = sourceId,
                    AttributeId = Attributes.Value
                });
                nodesToRead.Add(new ReadValueId()
                {
                    NodeId = sourceId,
                    AttributeId = Attributes.AccessLevel
                });
                nodesToRead.Add(new ReadValueId()
                {
                    NodeId = sourceId,
                    AttributeId = Attributes.DisplayName
                });
                nodesToRead.Add(new ReadValueId()
                {
                    NodeId = sourceId,
                    AttributeId = Attributes.Description
                });
            }

            // read all values.
            m_OpcUaClient.Session.Read(
                null,
                0,
                TimestampsToReturn.Neither,
                nodesToRead,
                out DataValueCollection results,
                out DiagnosticInfoCollection diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

            return results.ToArray();
        }


        /// <summary>
        /// 读取一个节点的指定属性
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        private DataValue ReadNoteDataValueAttributes(NodeId nodeId, uint attribute)
        {
            NodeId sourceId = nodeId;
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();


            ReadValueId nodeToRead = new ReadValueId();
            nodeToRead.NodeId = sourceId;
            nodeToRead.AttributeId = attribute;
            nodesToRead.Add(nodeToRead);

            int startOfProperties = nodesToRead.Count;

            // find all of the pror of the node.
            BrowseDescription nodeToBrowse1 = new BrowseDescription();

            nodeToBrowse1.NodeId = sourceId;
            nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.HasProperty;
            nodeToBrowse1.IncludeSubtypes = true;
            nodeToBrowse1.NodeClassMask = 0;
            nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            nodesToBrowse.Add(nodeToBrowse1);

            // fetch property references from the server.
            ReferenceDescriptionCollection references = FormUtils.Browse(m_OpcUaClient.Session, nodesToBrowse, false);

            if (references == null)
            {
                return null;
            }

            for (int ii = 0; ii < references.Count; ii++)
            {
                // ignore external references.
                if (references[ii].NodeId.IsAbsolute)
                {
                    continue;
                }

                ReadValueId nodeToRead2 = new ReadValueId();
                nodeToRead2.NodeId = (NodeId)references[ii].NodeId;
                nodeToRead2.AttributeId = Attributes.Value;
                nodesToRead.Add(nodeToRead2);
            }

            // read all values.
            DataValueCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            m_OpcUaClient.Session.Read(
                null,
                0,
                TimestampsToReturn.Neither,
                nodesToRead,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

            return results[0];
        }

        #endregion

        #region Menu Click Event

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // press exit menu button
            Close();
        }

       /* private void discoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string endpointUrl = new DiscoverServerDlg().ShowDialog(m_OpcUaClient.AppConfig, null);

            if (endpointUrl != null)
            {
                uiipTextBox.Text = endpointUrl;
            }
        }*/



        #endregion

        #region Press Connect and dicconnet Click Button
        /// <summary>
        /// 使用异步方法执行连接操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void uiButton_connect_Click(object sender, EventArgs e)
        {
            /// 以下的方法的调用都是我用来测试我写的接口用的，先不要删除，用不到的地方直接注释就行
            // 1.将nodeid添加进数据库中的测试
            //BaseDataNodeManages deviceNodeManages = new BaseDataNodeManages(uiipTextBox.Text);
            //deviceNodeManages.FilterAndStoreNodes();

            ////2. 返回点位信息的测试
            //List<NodeInfoVO>  nodeInfoVOs = deviceNodeManages.GetNodeInfoList();
            //// 输出nodeInfoVOs的大小
            //Console.WriteLine(nodeInfoVOs.Count);

            // 3.测试分表
            //HistoryTable historyTable = new HistoryTable();
            //historyTable.CreateHistoryTable();

            // 4.获取opc服务器上的所有点位信息
            //List<string> nodeIds = new List<string>();
            //nodeIds = new BaseDataNodeManages(uiipTextBox.Text).GetAllNodeIds();


            //foreach (var nodeInfo in nodeInfoVOs)
            //{
            //    Console.WriteLine("NodeId: " + nodeInfo.NodeId);
            //    Console.WriteLine("NodeDescribe: " + nodeInfo.NodeDescribe);
            //    Console.WriteLine("DeviceId: " + nodeInfo.DeviceId);
            //    Console.WriteLine("DeviceName: " + nodeInfo.DeviceName);
            //    Console.WriteLine("TypeId: " + nodeInfo.TypeId);
            //    Console.WriteLine("TypeName: " + nodeInfo.TypeName);
            //    Console.WriteLine("State: " + nodeInfo.State);
            //    Console.WriteLine("Value: " + nodeInfo.Value);
            //    Console.WriteLine("Unit: " + nodeInfo.Unit);
            //    Console.WriteLine("Location: " + nodeInfo.Location);
            //    Console.WriteLine("CollectTime: " + nodeInfo.CollectTime);
            //    Console.WriteLine("---------------------------------------");
            //}
            if (!ButtonState)
            {
                // connect to server
                FormConnectSelect formConnectSelect = new FormConnectSelect(m_OpcUaClient);
                
                    if (formConnectSelect.ShowDialog() == DialogResult.OK)
                    {
                    ButtonState = !ButtonState;
                    try
                    {
                        // 从配置文件中获取服务器地址并填入进文本框中
                        await m_OpcUaClient.ConnectServer(uiipTextBox.Text);
                        if(m_OpcUaClient != null)
                        {
                            uiLight1.OnColor = Color.LimeGreen;
                            uiButton_connect.Text = "断开连接";
                            new ServiceConnect().SetOpcUaClient(m_OpcUaClient);
                        }
                            // 5.实时数据入库操作
                           /* DeviceDataService deviceRealTimeDataService = new DeviceDataService();
                            deviceRealTimeDataService.RealTimeToDBAsync();*/

                    }
                    catch (Exception ex)
                    {
                        ClientUtils.HandleException(Text, ex);
                    }
                    }
                
            }
            else
            //disconnect
            {
                ButtonState = !ButtonState;
                m_OpcUaClient.Disconnect();
                uiLight1.OnColor = Color.FromArgb(140, 140, 140);
                BrowseNodesTV.Nodes.Clear();
                dataGridView1.ClearAll();
                textBox_nodeId.Clear();
                label_time_spend.Text = "0ms";
                uiButton_connect.Text = "连接";
            }
            
        }

        #endregion

        #region 填入分支

        /// <summary>
        /// Populates the branch in the tree view.
        /// </summary>
        /// <param name="sourceId">The NodeId of the Node to browse.</param>
        /// <param name="nodes">The node collect to populate.</param>
        private async void PopulateBranch(NodeId sourceId, TreeNodeCollection nodes)
        {
            nodes.Clear();
            nodes.Add(new TreeNode("Browsering..."));
            // fetch references from the server.
            TreeNode[] listNode = await Task.Run(() =>
            {
                // 调用GetReferenceDescriptionCollection方法获取指定节点的子节点集合。
                ReferenceDescriptionCollection references = GetReferenceDescriptionCollection(sourceId);
                // 输出节点的子节点集合
                //foreach (ReferenceDescription reference in references)
                //{
                //    Console.WriteLine("Reference: {0}, NodeId: {1}", reference.DisplayName.Text, reference.NodeId);
                //}

                // 输出节点名称
                //foreach (ReferenceDescription reference in references)
                //{
                //    Console.WriteLine("{0}", reference.DisplayName.Text);
                //}
                List<TreeNode> list = new List<TreeNode>();
                if (references != null)
                {
                    // process results.
                    for (int ii = 0; ii < references.Count; ii++)
                    {
                        ReferenceDescription target = references[ii];
                        TreeNode child = new TreeNode(Utils.Format("{0}", target));

                        child.Tag = target;
                        string key = GetImageKeyFromDescription(target, sourceId);
                        child.ImageKey = key;
                        child.SelectedImageKey = key;

                        // if (target.NodeClass == NodeClass.Object || target.NodeClass == NodeClass.Unspecified || expanded)
                        // {
                        //     child.Nodes.Add(new TreeNode());
                        // }

                        if (!checkBox1.Checked)
                        {
                            if (GetReferenceDescriptionCollection((NodeId)target.NodeId).Count > 0)
                            {
                                child.Nodes.Add(new TreeNode());
                            }
                        }
                        else
                        {
                            child.Nodes.Add(new TreeNode());
                        }


                        list.Add(child);
                    }
                    //Console.WriteLine("------------------");
                    //foreach (TreeNode node in list)
                    //{
                    //    Console.WriteLine(node.Text);
                    //}
                }
                return list.ToArray();
            });


            // update the attributes display.
            // DisplayAttributes(sourceId);
            nodes.Clear();
            nodes.AddRange(listNode.ToArray());
        }



        #endregion

        #region 节点打开的时候操作

        private void BrowseNodesTV_MouseClick(object sender, MouseEventArgs e)
        {
            // 判断鼠标点击的按钮是否为右键
            if (e.Button == MouseButtons.Right)
            {
                // 获取鼠标点击位置的树形节点
                TreeNode tn = BrowseNodesTV.GetNodeAt(e.X, e.Y);
                // 如果该节点不为空
                if (tn != null)
                {
                    // 将该节点设置为选中的节点
                    BrowseNodesTV.SelectedNode = tn;
                }
            }
        }
        /// <summary>
        /// 定义一个树形视图节点展开前的事件处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseNodesTV_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                // 检查节点是否已经展开过一次
                if (e.Node.Nodes.Count != 1)
                {
                    return;
                }
                // 检查节点的子节点数量
                if (e.Node.Nodes.Count > 0)
                {
                    // 如果第一个子节点的文本不为空
                    if (e.Node.Nodes[0].Text != String.Empty)
                    {
                        return;
                    }
                }

                // 获取节点的源引用
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;
                // 如果引用为空或引用的NodeId是绝对的
                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    // 取消展开并返回
                    e.Cancel = true;
                    return;
                }

                // 填充子节点
                PopulateBranch((NodeId)reference.NodeId, e.Node.Nodes);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// 定义一个树形视图节点选择后的事件处理程序，点击具体的节点后显示信息至右边的界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseNodesTV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                // 移除所有下标
                RemoveAllSubscript();
                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    return;
                }

                // populate children.
                ShowMember((NodeId)reference.NodeId);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(Text, exception);
            }
        }


        private void ClearDataGridViewRows(int index)
        {
            Console.WriteLine("Rows Count = {0}", dataGridView1.Rows.Count);
            for (int i = dataGridView1.Rows.Count - 1; i >= index; i--)
            {
                if (i >= 0)
                {
                    Console.WriteLine("删除一行前");
                    dataGridView1.Rows.RemoveAt(i);
                    Console.WriteLine("删除一行后");
                }
            }
        }

        #endregion

        #region 点击树节点后在数据表显示

        /// <summary>
        /// 点击了节点名称前的内容进行复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_nodeId.Text))
            {
                Clipboard.SetText(textBox_nodeId.Text);
            }
        }
        private async void ShowMember(NodeId sourceId)
        {

            textBox_nodeId.Text = sourceId.ToString();

            // dataGridView1.Rows.Clear();
            int index = 0;
            ReferenceDescriptionCollection references;
            try
            {
                
                references = await Task.Run(() =>
                {
                    return GetReferenceDescriptionCollection(sourceId);
                });
                // 输出reference
                Console.WriteLine("showmember里面的references");
                //foreach (ReferenceDescription reference in references)
                //{
                //    Console.WriteLine("Reference: {0}, NodeId: {1}", reference.DisplayName.Text, reference.NodeId);
                //}

                foreach (ReferenceDescription reference in references)
                {
                    Console.WriteLine("{0}", reference.DisplayName.Text);
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(Text, exception);
                return;
            }


            if (references?.Count > 0)
            {
                // 获取所有要读取的子节点
                List<NodeId> nodeIds = new List<NodeId>();
                for (int ii = 0; ii < references.Count; ii++)
                {
                    ReferenceDescription target = references[ii];
                    nodeIds.Add((NodeId)target.NodeId);
                }

                DateTime dateTimeStart = DateTime.Now;

                // 获取所有的值
                // 1行 Type；2行  value；3行 AccessLevel；4行 Name；5行 Description
                DataValue[] dataValues = await Task.Run(() =>
                {
                    return ReadOneNodeFiveAttributes(nodeIds);
                });

                // 测试语句
                //foreach (DataValue dataValue in dataValues)
                //{
                //    Console.WriteLine(dataValue);
                //}

                label_time_spend.Text = (int)(DateTime.Now - dateTimeStart).TotalMilliseconds + " ms";

                // 显示
                for (int jj = 0; jj < dataValues.Length; jj += 5)
                {
                    // 控制台输出测试
                    Console.WriteLine("--------------开始添加行--------------------");
                    AddDataGridViewNewRow(dataValues, jj, index++, nodeIds[jj / 5]);
                    Console.WriteLine("--------------开始行完成--------------------");
                }

            }
            else
            {
                // 子节点没有数据的情况
                try
                {
                    DateTime dateTimeStart = DateTime.Now;
                    DataValue dataValue = m_OpcUaClient.ReadNode(sourceId);

                    if (dataValue.WrappedValue.TypeInfo?.ValueRank == ValueRanks.OneDimension)
                    {
                        // 数组显示
                        Console.WriteLine("--------------开始添加行:子节点无数据-------------------");
                        AddDataGridViewArrayRow(sourceId, out index);
                        Console.WriteLine("--------------开始添加行:子节点无数据--------------------");
                    }
                    else
                    {
                        // 显示单个数本身
                        label_time_spend.Text = (int)(DateTime.Now - dateTimeStart).TotalMilliseconds + " ms";
                        Console.WriteLine("--------------开始添加行:单个数--------------------");
                        AddDataGridViewNewRow(ReadOneNodeFiveAttributes(new List<NodeId>() { sourceId }), 0, index++, sourceId);
                        Console.WriteLine("--------------开始行完成：单个数--------------------");
                    }
                }
                catch (Exception exception)
                {
                    ClientUtils.HandleException(Text, exception);
                    return;
                }
            }
            
            Console.WriteLine("index = {0}", index);
            ClearDataGridViewRows(index);

        }


        private void AddDataGridViewNewRow(DataValue[] dataValues, int startIndex, int index, NodeId nodeId)
        {
            // int index = dataGridView1.Rows.Add();
            while (index >= dataGridView1.Rows.Count)
            {
                dataGridView1.Rows.Add();
            }
            DataGridViewRow dgvr = dataGridView1.Rows[index];
            dgvr.Tag = nodeId;

            if (dataValues[startIndex].WrappedValue.Value == null) return;
            NodeClass nodeclass = (NodeClass)dataValues[startIndex].WrappedValue.Value;

            dgvr.Cells[1].Value = dataValues[3 + startIndex].WrappedValue.Value;
            dgvr.Cells[5].Value = dataValues[4 + startIndex].WrappedValue.Value;
            dgvr.Cells[4].Value = GetDiscriptionFromAccessLevel(dataValues[2 + startIndex]);

            if (nodeclass == NodeClass.Object)
            {
                ///dgvr.Cells[0].Value = Properties.Resources.ClassIcon;
                dgvr.Cells[2].Value = "";
                dgvr.Cells[3].Value = nodeclass.ToString();
            }
            else if (nodeclass == NodeClass.Method)
            {
                ///dgvr.Cells[0].Value = Properties.Resources.Method_636;
                dgvr.Cells[2].Value = "";
                dgvr.Cells[3].Value = nodeclass.ToString();
            }
            else if (nodeclass == NodeClass.Variable)
            {
                DataValue dataValue = dataValues[1 + startIndex];

                if (dataValue.WrappedValue.TypeInfo != null)
                {
                    dgvr.Cells[3].Value = dataValue.WrappedValue.TypeInfo.BuiltInType;
                    // dgvr.Cells[3].Value = dataValue.Value.GetType().ToString();
                    if (dataValue.WrappedValue.TypeInfo.ValueRank == ValueRanks.Scalar)
                    {
                        dgvr.Cells[2].Value = dataValue.WrappedValue.Value;
                       // dgvr.Cells[0].Value = Properties.Resources.Enum_582;
                    }
                    else if (dataValue.WrappedValue.TypeInfo.ValueRank == ValueRanks.OneDimension)
                    {
                        dgvr.Cells[2].Value = dataValue.Value.GetType().ToString();
                        ///dgvr.Cells[0].Value = Properties.Resources.brackets_Square_16xMD;
                    }
                    else if (dataValue.WrappedValue.TypeInfo.ValueRank == ValueRanks.TwoDimensions)
                    {
                        dgvr.Cells[2].Value = dataValue.Value.GetType().ToString();
                        //dgvr.Cells[0].Value = Properties.Resources.Module_648;
                    }
                    else
                    {
                        dgvr.Cells[2].Value = dataValue.Value.GetType().ToString();
                        //dgvr.Cells[0].Value = Properties.Resources.ClassIcon;
                    }
                }
                else
                {
                    //dgvr.Cells[0].Value = Properties.Resources.ClassIcon;
                    dgvr.Cells[2].Value = dataValue.Value;
                    dgvr.Cells[3].Value = "null";
                }
            }
            else
            {
                dgvr.Cells[2].Value = "";
                //dgvr.Cells[0].Value = Properties.Resources.ClassIcon;
                dgvr.Cells[3].Value = nodeclass.ToString();
            }
        }

        private void AddDataGridViewArrayRow(NodeId nodeId, out int index)
        {

            DateTime dateTimeStart = DateTime.Now;
            DataValue[] dataValues = ReadOneNodeFiveAttributes(new List<NodeId>() { nodeId });
            label_time_spend.Text = (int)(DateTime.Now - dateTimeStart).TotalMilliseconds + " ms";

            DataValue dataValue = dataValues[1];

            if (dataValue.WrappedValue.TypeInfo?.ValueRank == ValueRanks.OneDimension)
            {
                string access = GetDiscriptionFromAccessLevel(dataValues[2]);
                BuiltInType type = dataValue.WrappedValue.TypeInfo.BuiltInType;
                object des = dataValues[4].Value ?? "";
                object dis = dataValues[3].Value ?? type;

                Array array = dataValue.Value as Array;
                int i = 0;
                foreach (object obj in array)
                {
                    while (i >= dataGridView1.Rows.Count)
                    {
                        dataGridView1.Rows.Add();
                    }

                    DataGridViewRow dgvr = dataGridView1.Rows[i];

                    dgvr.Tag = null;

                    //dgvr.Cells[0].Value = Properties.Resources.Enum_582;
                    dgvr.Cells[1].Value = $"{dis} [{i++}]";
                    dgvr.Cells[2].Value = obj;
                    dgvr.Cells[3].Value = type;
                    dgvr.Cells[4].Value = access;
                    dgvr.Cells[5].Value = des;
                }
                index = i;
            }
            else
            {
                index = 0;
            }
        }

        private string GetDiscriptionFromAccessLevel(DataValue value)
        {
            if (value.WrappedValue.Value != null)
            {
                switch ((byte)value.WrappedValue.Value)
                {
                    case 0: return "None";
                    case 1: return "CurrentRead";
                    case 2: return "CurrentWrite";
                    case 3: return "CurrentReadOrWrite";
                    case 4: return "HistoryRead";
                    case 8: return "HistoryWrite";
                    case 12: return "HistoryReadOrWrite";
                    case 16: return "SemanticChange";
                    case 32: return "StatusWrite";
                    case 64: return "TimestampWrite";
                    default: return "None";
                }
            }
            else
            {
                return "null";
            }
        }



        #endregion

        #region 订阅刷新块


        private List<string> subNodeIds = new List<string>();
        private bool isSingleValueSub = false;

        private void RemoveAllSubscript()
        {
            m_OpcUaClient?.RemoveAllSubscription();
        }


        private void SubCallBack(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs eventArgs)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, MonitoredItem, MonitoredItemNotificationEventArgs>(SubCallBack), key, monitoredItem, eventArgs);
                return;
            }


            MonitoredItemNotification notification = eventArgs.NotificationValue as MonitoredItemNotification;
            string nodeId = monitoredItem.StartNodeId.ToString();

            int index = subNodeIds.IndexOf(nodeId);
            if (index >= 0)
            {
                if (isSingleValueSub)
                {
                    if (notification.Value.WrappedValue.TypeInfo?.ValueRank == ValueRanks.OneDimension)
                    {
                        Array array = notification.Value.WrappedValue.Value as Array;
                        int i = 0;
                        foreach (object obj in array)
                        {
                            DataGridViewRow dgvr = dataGridView1.Rows[i];
                            dgvr.Cells[2].Value = obj;
                            i++;
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[index].Cells[2].Value = notification.Value.WrappedValue.Value;
                    }
                }
                else
                {
                    dataGridView1.Rows[index].Cells[2].Value = notification.Value.WrappedValue.Value;
                }
            }
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            if (m_OpcUaClient != null)
            {
                RemoveAllSubscript();
                if (uiButton_subscribe.BackColor != Color.LimeGreen)
                {
                    uiButton_subscribe.BackColor = Color.LimeGreen;
                    // 判断当前的选择
                    if (string.IsNullOrEmpty(textBox_nodeId.Text)) return;


                    ReferenceDescriptionCollection references;
                    try
                    {
                        references = await Task.Run(() =>
                        {
                            return GetReferenceDescriptionCollection(new NodeId(textBox_nodeId.Text));
                        });
                    }
                    catch (Exception exception)
                    {
                        ClientUtils.HandleException(Text, exception);
                        return;
                    }

                    subNodeIds = new List<string>();
                    if (references?.Count > 0)
                    {
                        isSingleValueSub = false;
                        // 获取所有要订阅的子节点
                        for (int ii = 0; ii < references.Count; ii++)
                        {
                            ReferenceDescription target = references[ii];
                            subNodeIds.Add(((NodeId)target.NodeId).ToString());
                        }
                    }
                    else
                    {
                        isSingleValueSub = true;
                        // 子节点没有数据的情况
                        subNodeIds.Add(textBox_nodeId.Text);
                    }

                    m_OpcUaClient.AddSubscription("subTest", subNodeIds.ToArray(), SubCallBack);
                }
                else
                {
                    uiButton_subscribe.BackColor = SystemColors.Control;
                }
            }
        }

        #endregion

        #region 点击了表格修改数据

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value is BuiltInType builtInType)
            {
                dynamic value = null;
                if (dataGridView1.Rows[e.RowIndex].Tag is NodeId nodeId)
                {
                    // 节点
                    try
                    {
                        value = GetValueFromString(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), builtInType);
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Input Value");
                        return;
                    }

                    if (!m_OpcUaClient.WriteNode(nodeId.ToString(), value))
                    {
                        MessageBox.Show("Failed to write value");
                    }
                }
                else
                {
                    // 点击了数组修改
                    IList<string> list = new List<string>();

                    for (int jj = 0; jj < dataGridView1.RowCount; jj++)
                    {
                        list.Add(dataGridView1.Rows[jj].Cells[e.ColumnIndex].Value.ToString());
                    }

                    try
                    {
                        value = GetArrayValueFromString(list, builtInType);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Input Value: " + ex.Message);
                        return;
                    }

                    if (!m_OpcUaClient.WriteNode(textBox_nodeId.Text, value))
                    {
                        MessageBox.Show("Failed to write value");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid data type");
            }

            //MessageBox.Show(
            //    "Type:" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.GetType().ToString() + Environment.NewLine +
            //    "Value:" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        private dynamic GetValueFromString(string value, BuiltInType builtInType)
        {
            switch (builtInType)
            {
                case BuiltInType.Boolean:
                    {
                        return bool.Parse(value);
                    }
                case BuiltInType.Byte:
                    {
                        return byte.Parse(value);
                    }
                case BuiltInType.DateTime:
                    {
                        return DateTime.Parse(value);
                    }
                case BuiltInType.Double:
                    {
                        return double.Parse(value);
                    }
                case BuiltInType.Float:
                    {
                        return float.Parse(value);
                    }
                case BuiltInType.Guid:
                    {
                        return Guid.Parse(value);
                    }
                case BuiltInType.Int16:
                    {
                        return short.Parse(value);
                    }
                case BuiltInType.Int32:
                    {
                        return int.Parse(value);
                    }
                case BuiltInType.Int64:
                    {
                        return long.Parse(value);
                    }
                case BuiltInType.Integer:
                    {
                        return int.Parse(value);
                    }
                case BuiltInType.LocalizedText:
                    {
                        return value;
                    }
                case BuiltInType.SByte:
                    {
                        return sbyte.Parse(value);
                    }
                case BuiltInType.String:
                    {
                        return value;
                    }
                case BuiltInType.UInt16:
                    {
                        return ushort.Parse(value);
                    }
                case BuiltInType.UInt32:
                    {
                        return uint.Parse(value);
                    }
                case BuiltInType.UInt64:
                    {
                        return ulong.Parse(value);
                    }
                case BuiltInType.UInteger:
                    {
                        return uint.Parse(value);
                    }
                default: throw new Exception("Not supported data type");
            }
        }


        private dynamic GetArrayValueFromString(IList<string> values, BuiltInType builtInType)
        {
            switch (builtInType)
            {
                case BuiltInType.Boolean:
                    {
                        bool[] result = new bool[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = bool.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Byte:
                    {
                        byte[] result = new byte[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = byte.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.DateTime:
                    {
                        DateTime[] result = new DateTime[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = DateTime.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Double:
                    {
                        double[] result = new double[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = double.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Float:
                    {
                        float[] result = new float[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = float.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Guid:
                    {
                        Guid[] result = new Guid[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = Guid.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Int16:
                    {
                        short[] result = new short[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = short.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Int32:
                    {
                        int[] result = new int[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = int.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Int64:
                    {
                        long[] result = new long[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = long.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Integer:
                    {
                        int[] result = new int[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = int.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.LocalizedText:
                    {
                        return values.ToArray();
                    }
                case BuiltInType.SByte:
                    {
                        sbyte[] result = new sbyte[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = sbyte.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.String:
                    {
                        return values.ToArray();
                    }
                case BuiltInType.UInt16:
                    {
                        ushort[] result = new ushort[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = ushort.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.UInt32:
                    {
                        uint[] result = new uint[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = uint.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.UInt64:
                    {
                        ulong[] result = new ulong[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = ulong.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.UInteger:
                    {
                        uint[] result = new uint[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = uint.Parse(values[i]);
                        }
                        return result;
                    }
                default: throw new Exception("Not supported data type");
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value is BuiltInType builtInType)
            {
                if (
                    builtInType == BuiltInType.Boolean ||
                    builtInType == BuiltInType.Byte ||
                    builtInType == BuiltInType.DateTime ||
                    builtInType == BuiltInType.Double ||
                    builtInType == BuiltInType.Float ||
                    builtInType == BuiltInType.Guid ||
                    builtInType == BuiltInType.Int16 ||
                    builtInType == BuiltInType.Int32 ||
                    builtInType == BuiltInType.Int64 ||
                    builtInType == BuiltInType.Integer ||
                    builtInType == BuiltInType.LocalizedText ||
                    builtInType == BuiltInType.SByte ||
                    builtInType == BuiltInType.String ||
                    builtInType == BuiltInType.UInt16 ||
                    builtInType == BuiltInType.UInt32 ||
                    builtInType == BuiltInType.UInt64 ||
                    builtInType == BuiltInType.UInteger
                    )
                {

                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("Not support the Type of modify value!");
                    return;
                }
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Not support the Type of modify value!");
                return;
            }


            if (!dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Value.ToString().Contains("Write"))
            {
                e.Cancel = true;
                MessageBox.Show("Not support the access of modify value!");
            }
        }

        #endregion

        private void uiButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
