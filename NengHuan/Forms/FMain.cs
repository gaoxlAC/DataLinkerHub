using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using NengHuan.Database;
using NengHuan.Database.MySQL.ModelsManage;
using NengHuan.Database.MySQL.Service;
using NengHuan.Database.SeparateTable;
using NengHuan.Database.SqLite;
using NengHuan.Database.VO;
using NengHuan.Forms;
using NengHuan.Forms.Common;
using NengHuan.Forms.HomePage;
using NengHuan.Models.Sjcj;
using NengHuan.Models.System;
using NengHuan.OPCUA;
using NengHuan.UserControls;
using Opc.Ua;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace NengHuan.UI
{
    public partial class FMain : UIForm
    {
        #region 属性
        /// <summary>
        /// 表达式体成员
        /// </summary>
        protected UITabControl MainTabControl => MainContainer;
        /// <summary>
        /// Opc客户端的核心类
        /// </summary>
        private OpcUaClient m_OpcUaClient;
        /// <summary>
        /// 首页
        /// </summary>
        private Home home { get; set; } = new Home();
        /// <summary>
        /// 获取一个日志记录器
        /// </summary>
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(FMain));
        public static DeviceDataService deviceDataService { get; set; }
        public static bool ButtonState = false;   // 连接状态初始化为未连接
        public static bool startState = false;

        private Timer timer;
        // 声明一个事件处理开始采集和停止采集按键的委托
        public event Action<bool, bool> UpdateSensorListButtons;

        // 存储传感器列表的字段
        public static Dictionary<string, Type_SensorListForm> SensorBoxListPages = new Dictionary<string, Type_SensorListForm>();

        // 传没有采集的设备
        public static Dictionary<string, DeviceTypeInfoVO> DeviceTypeInfos = new Dictionary<string, DeviceTypeInfoVO>();

        // 存实时数据库的点位信息的列表，用来初始化窗口中的盒子信息
        public List<DeviceInfoVO> sensors;
        
        // 创建一个对设备操作的实例
        public DeviceManageService deviceManageService = new DeviceManageService();

        // 静态变量来记录是否全部开始
        public static int isAll = 0;

        // 窗体编号
        public static int FormIndex = 0;

        // 存放之前状态的控制点位状态
        public static List<NodeControlVO> nodeControlVOs = new List<NodeControlVO>();

        // 数据库配置界面
        public static SetupForm setupForm = new SetupForm();
        #endregion
        #region 主窗体构造
        public FMain()
        {
            ThreadPool.SetMaxThreads(8, 8);
            InitializeComponent();
            MainContainer.BringToFront();
            //设置关联
            Aside.TabControl = MainTabControl;

            this.home.PageIndex = 10000;
            MainContainer.AddPage(this.home);
            Aside.CreateNode("首页", 57460, 27, this.home.PageIndex);

            btn_ConnectServer.Text = "连接";
            UpdateSensorListButtons?.Invoke(false, false); // 初始化为不可选状态

            // 触发定时器
            timer = new Timer();
            timer.Interval = CalculateInterval();
            //timer.Interval = 5000;
            timer.Tick += Timer_Tick;

            // 启动 Timer 控件
            timer.Start();


            //显示默认界面
            //Application.Run(new Home());
            //选中第一个节点
            Aside.SelectPage(this.home.PageIndex);
           
            ThreadPool.SetMaxThreads(20, 20);//使用线程池来
        }
        #endregion

        private void FMain_Load(object sender, EventArgs e)
        {
            uiLight2.OnColor = Color.Gray;

            // 加载之前先要拿到传感器类型的信息
            //DeviceTypeInfos = deviceManageService.GetRealTimeDeviceInfoByType();

            // 从数据库加载传感器
            //this.LoadSensorFromDB();
            this.StartButton.Enabled = false;
            this.EndButton.Enabled = false;
            // 弹出数据库配置界面
            setupForm.ShowDialog();
        }

        private void Header_MenuItemClick(string itemText, int menuIndex, int pageIndex)
        {
            switch (menuIndex)
            {
                case 4:
                    UIStyle style = (UIStyle)pageIndex;
                    if (style != UIStyle.Colorful)
                        StyleManager.Style = style;
                    else
                        SelectPage(pageIndex);

                    break;
                default:
                    Aside.SelectPage(pageIndex);
                    break;
            }
        }
        #region 服务器配置

        /// <summary>
        /// 通过URL连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 服务器配置toolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormBrowseServer frm = new FormBrowseServer("Opc.tcp://127.0.0.1:49320");
            frm.ShowDialog();
        }
        /// <summary>
        /// 获取已经连接的客户端对象
        /// </summary>
        /// <returns></returns>

        #endregion

        #region 数据库配置
        private void 传感器数据库配置toolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            setupForm.ShowDialog();
        }
        #endregion

        #region 传感器查询
        private void 传感器管理toolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDeviceInfo fDeviceInfo = new FDeviceInfo();
            fDeviceInfo.ShowDialog();
        }
        #endregion

        #region 添加设备
        private void ucBtnAddDevice1_Click(object sender, EventArgs e)
        {
            AddOrConfigDeviceForm addOrConfigDeviceForm = new AddOrConfigDeviceForm();
            addOrConfigDeviceForm.ShowDialog();    
        }

        /// <summary>
        /// 添加传感器时，左侧菜单添加节点类型
        /// </summary>
        /// <param name="deviceTypeInfo"></param>
        private void AddSensorType(DeviceTypeInfoVO deviceTypeInfo)
        {
            // 先创建一个名为“传感器列表”的父节点
            // 再创建对应传感器类型的二级节点，该节点要对应一个页面
            TreeNode sensorListParentNode = null;
            bool f1 = false;
            foreach (TreeNode node in Aside.Nodes)
            {
                if (node.Text == "传感器列表")
                {
                    sensorListParentNode = node;
                    f1 = true;
                    break;
                }
            }
            // 初始化时没有传感器列表，则创建传感器列表
            if (f1 == false)
            {
                sensorListParentNode = Aside.CreateNode("传感器列表", 61643, 24, 20000);
                TreeNode sensorTypeNode = this.CreateSensorTypeNode(sensorListParentNode, deviceTypeInfo);  // 创建该类型结点
                foreach (var deviceInfos in deviceTypeInfo.Devices)
                {
                    this.CreateSensorBoxLoop(sensorTypeNode, deviceInfos);
                }
            }
            // 存在传感器列表则按照类型添加传感器
            else
            {
                TreeNode sensorTypeNode = this.CreateSensorTypeNode(sensorListParentNode, deviceTypeInfo);
                foreach (var deviceInfos in deviceTypeInfo.Devices)
                {
                    this.CreateSensorBoxLoop(sensorTypeNode, deviceInfos);
                }
            }
        }
        /// <summary>
        /// 添加传感器时，左侧菜单添加节点类型 
        /// </summary>
        /// <param name="newSensor"></param>
        private void AddSensor(DeviceInfoVO newSensor)
        {
            // 先创建一个名为“传感器列表”的父节点
            // 再创建对应传感器类型的二级节点，该节点要对应一个页面
            TreeNode sensorListParentNode = null;
            bool f1 = false;
            foreach (TreeNode node in Aside.Nodes)
            {
                //Console.WriteLine("传感器列表：{0}", node.Text);
                if (node.Text == "传感器列表")
                {
                    sensorListParentNode = node;
                    f1 = true;
                    break;
                }
            }
            if (!f1)
            {
                sensorListParentNode = Aside.CreateNode("传感器列表", 61643, 24, 20000);
                TreeNode sensorTypeNode1 = this.CreateSensorTypeNode1(sensorListParentNode, newSensor);
                this.CreateSensorBox(sensorTypeNode1, newSensor);


            }
            else
            {
                bool f2 = false;
                TreeNode sensorTypeNode = null;

                foreach (TreeNode node in sensorListParentNode.Nodes)
                {
                    if (node.Text == newSensor.TypeName)
                    {
                        Console.WriteLine("传感器类型：");
                        Console.WriteLine(newSensor.TypeName);
                        sensorTypeNode = node;
                        f2 = true;
                        break;
                    }

                }
                if (!f2)
                {
                    sensorTypeNode = this.CreateSensorTypeNode1(sensorListParentNode, newSensor);
                    this.CreateSensorBox(sensorTypeNode, newSensor);
                }
                else
                {
                    this.CreateSensorBox(sensorTypeNode, newSensor);
                }
            }
        }

        /// <summary>
        /// 创建传感器类型节点
        /// </summary>
        /// <param name="ParentNode"></param>
        /// <param name="newSensor"></param>
        /// <returns></returns>
        private TreeNode CreateSensorTypeNode(TreeNode ParentNode, DeviceTypeInfoVO newSensorType)
        {
            Type_SensorListForm page = new Type_SensorListForm();      // 新建一个供显示数据用的页面
            page.SensorTypeName.Text = newSensorType.DeviceTypeName;   // newSensor.DeviceTypeName    
            page.PageIndex = ++FormIndex;                             // 页面id
            page.Text = newSensorType.DeviceTypeName;                // 获取类型名称
            //page.AddSensorType += this.AddSensorType;                       // 用一个委托让其他类在不创建本类对象的情况下操作本类的控件
            page.FreComboBox.Text = newSensorType.ReadFrequency.ToString();
            SensorBoxListPages.Add(newSensorType.DeviceTypeName, page);
            foreach (var item in SensorBoxListPages)
            {
                Console.WriteLine("字典的键值对：{0}----->{1}", item.Key, item.Value);
            }
            MainContainer.AddPage(page);
            return Aside.CreateChildNode(ParentNode, newSensorType.DeviceTypeName, page.PageIndex);
        }


        /// <summary>
        /// 创建传感器类型节点
        /// </summary>
        /// <param name="ParentNode"></param>
        /// <param name="newSensorType"></param>
        /// <returns></returns>
        private TreeNode CreateSensorTypeNode1(TreeNode ParentNode, DeviceInfoVO newSensor)
        {
            Type_SensorListForm page = new Type_SensorListForm();      // 新建一个供显示数据用的页面
            page.SensorTypeName.Text = newSensor.TypeName;   // newSensor.DeviceTypeName
            page.PageIndex = ++FormIndex;                             // 页面id
            page.Text = newSensor.TypeName;                // 获取类型名称
            page.AddSensor += this.AddSensor;                       // 用一个委托让其他类在不创建本类对象的情况下操作本类的控件

            SensorBoxListPages.Add(newSensor.TypeName, page);
            foreach (var item in SensorBoxListPages)
            {
                Console.WriteLine("字典的键值对：{0}", item);
            }
            MainContainer.AddPage(page);
            return Aside.CreateChildNode(ParentNode, newSensor.TypeName, page.PageIndex);
        }


        /// <summary>
        /// 创建传感器节点，父节点为相应的传感器类型的节点
        /// </summary>
        /// <param name="sensorTypeNode"></param>
        /// <param name="newSensor"></param>
        private void CreateSensorBox(TreeNode ParentNode, DeviceInfoVO newSensor)
        {
            int pageIndex = SensorBoxListPages[newSensor.TypeName].PageIndex;
            // TreeNode nowNode = Aside.CreateChildNode(ParentNode, 57364, 24, newSensor.SName, pageIndex);
            // ModbusUtil.SensorBoxListPages[newSensor.Type].Sensors.Add(newSensor);// Sensors没用
            SensorBoxListPages[newSensor.TypeName].AddSensorBox(newSensor);
            // ModbusUtil.SensorListPages[newSensor.Type].RefreshData();

            Aside.SelectedNode = ParentNode;
            Aside.SelectPage(pageIndex);
        }

        /// <summary>
        /// 循环添加盒子
        /// </summary>
        /// <param name="ParentNode"></param>
        /// <param name="newSensor"></param>
        private void CreateSensorBoxLoop(TreeNode ParentNode, DeviceInfoVO newSensor)
        {
            int pageIndex = SensorBoxListPages[newSensor.TypeName].PageIndex;
            SensorBoxListPages[newSensor.TypeName].AddSensorBox(newSensor);
            Aside.SelectedNode = ParentNode;
            Aside.SelectPage(pageIndex);
        }

        #region 从数据库加载传感器

        private void LoadSensorFromDB()
        {
            //加载前，先把所有的pageIndex重置为0
            //new DictDeviceTypeManages().SetAllPageIndexTo0();
            //把MainContainer的页面清空
            MainContainer.TabPages.Clear();

            //把Aside的节点清空,除了首页
            foreach (TreeNode node in Aside.Nodes)
            {
                if (node.Text != "首页")
                {
                    node.Nodes.Clear();
                    Aside.Nodes.Remove(node);
                }
            }

            //把页面列表清空
            SensorBoxListPages.Clear();

            //遍历DeviceTypeInfos
            foreach (DeviceTypeInfoVO deviceTypeInfo in DeviceTypeInfos.Values)
            {
                this.AddSensorType(deviceTypeInfo);
            }
            Aside.CollapseAll();
        }
        #endregion



        #region 添加新的节点

        private void ucBtnAddDevice2_Click(object sender, EventArgs e)
        {
            AddOrConfigDeviceForm addOr = new AddOrConfigDeviceForm();
            addOr.ShowDialog();
            Console.WriteLine("添加传感器");
            if (addOr.IsOK)
            {
                addOr.ShowDialog();
                BaseDataNode baseDataNode = addOr.GetNodeInfo();
                NodeManageService nodeManageService = new NodeManageService();
                MessageBox.Show(nodeManageService.InsertNodeInfo(baseDataNode));
            }
        }
        #endregion


        #region 连接服务器

        private async void btn_ConnectServer_Click(object sender, EventArgs e)
        {
            if (ButtonState == false)   // 如果是非连接状态，ButtonState = false
            {
                // 连接opc服务器之前确定已经保存数据库连接信息
                
                m_OpcUaClient = new OpcUaClient();
                // connect to server
                FormConnectSelect formConnectSelect = new FormConnectSelect(m_OpcUaClient);

                if (formConnectSelect.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 从配置文件中获取服务器地址并填入进文本框中
                        await m_OpcUaClient.ConnectServer(uiipTextBox.Text);

                        // opc服务器连接成功
                        if (m_OpcUaClient != null)
                        {
                            uiLight2.OnColor = Color.LimeGreen;
                            btn_ConnectServer.Text = "断开连接";
                            SetButtonTextForAllSensorBoxes("开始采集", true);
                            new ServiceConnect().SetOpcUaClient(m_OpcUaClient);
                            this.StartButton.Enabled = true;//开始采集可选
                            this.EndButton.Enabled = false;//停止采集不可选

                            // 开始调用控制功能
                            //new DeviceDataService().StartControlLoop();
                        }

                    }
                    catch (Exception ex)
                    {
                        ClientUtils.HandleException(Text, ex);
                    }
                    ButtonState = !ButtonState;
                }

            }
            else  // 如果是连接状态想要断开连接
            //disconnect
            {
                m_OpcUaClient.Disconnect();
                uiLight2.OnColor = Color.FromArgb(140, 140, 140);
                btn_ConnectServer.Text = "连接";
                SetButtonTextForAllSensorBoxes("开始采集", false);
                this.StartButton.Enabled = false;//开始采集不可选
                this.EndButton.Enabled = false;//停止采集不可选
                ButtonState = !ButtonState;
            }
        }



        #endregion

        #endregion

        #region 实时数据显示
        /// <summary>
        /// 取消任务对象
        /// </summary>
        public CancellationTokenSource CTS;

        /// <summary>
        /// 读取实时数据库的任务
        /// </summary>
        public Task ReadRealTimeTask;
        /// <summary>
        /// 异步实时数据显示
        /// </summary>
        private async Task RealTimeShow()
        {
            
            try
            {
                // 如果数据表不为空则异步读取数据库
                if (DeviceTypeInfos == null) return;

                // 设置一个读取的标记
                CTS = new CancellationTokenSource();
                ReadRealTimeTask = Task.Run(() => Show(CTS.Token),CTS.Token);
            }
            catch 
            {
                MessageBox.Show("实时数据显示失败，请检查数据库是否正常连接！");
            }
           
        }
        /// <summary>
        /// 停止实时数据得显示
        /// </summary>
        private void StopReadlTimeShow()
        {
            try
            {
                // 判断取消任务对象是否为空，不为空则取消任务
                if (CTS != null)
                {
                    CTS.Cancel();//取消任务
                    CTS = null;
                    ReadRealTimeTask = null;
                }
            }
            catch
            {
                // 窗口输出读取点位信息失败
                MessageBox.Show("停止读取失败！");
            }
        }
        /// <summary>
        /// 异步显示实时数据
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task Show(CancellationToken token)
        {
            try
            {
                while(true)
                {
                    // 标记取消，则停止显示
                    if(token.IsCancellationRequested)
                    {
                        break;
                    }
                    // 从数据库中读取
                    DeviceTypeInfos = deviceManageService.GetRealTimeDeviceInfoByType();

                    // 遍历DeviceTypeInfos，按照类型显示数据
                    foreach (var deviceInfo in DeviceTypeInfos.Values) 
                    {
                        SetTextForSensorTypeBoxes(deviceInfo);
                    }

                }
            }
            catch 
            {
                await Task.Run(() => MessageBox.Show("实时显示任务出现故障！"));
            }
        }

        private void SetTextForSensorTypeBoxes(DeviceTypeInfoVO deviceTypeInfo)
        {
            //Console.WriteLine("进入到了SetTextForSensorTypeBoxes");
            foreach (var sensorListForm in SensorBoxListPages.Values)
            {
                // 窗体类型与传入的类型进行匹配
                if(sensorListForm.SensorTypeName.Text == deviceTypeInfo.DeviceTypeName)
                {
                    // 在每个 SensorListForm 中找到 flp_SensorBoxList 控件
                    var flpSensorBoxList = sensorListForm.Controls.Find("flp_SensorBoxList", true).FirstOrDefault();

                    // 如果找到了 flp_SensorBoxList，递归设置其中按钮的 Text
                    if (flpSensorBoxList != null)
                    {
                        // 遍历该类型下的设备名，按照设备名更新该类型下的sensorBox
                        // 找到 flowLayoutPanel 下的 USensorInfoBox
                        // 遍历 flp_SensorBoxList 中的每个控件
                        foreach (Control flpControl in flpSensorBoxList.Controls)
                        {
                            // 在 flp_SensorBoxList 列表中找到 FlowLayoutPanel 控件
                            if (flpControl is FlowLayoutPanel flowLayoutPanel)
                            {
                                foreach (DeviceInfoVO deviceInfoVO in deviceTypeInfo.Devices)
                                {
                                    // 遍历 FlowLayoutPanel 中的每个控件找到 USensorInfoBox
                                    foreach (Control control in flowLayoutPanel.Controls)  // 遍历 FlowLayoutPanel 中的每个控件（USensorInfoBox）
                                    {
                                        if (control is USensorInfoBox sensorBox)
                                        {
                                            if (sensorBox.lb_SensorName.Text == deviceInfoVO.DeviceName)
                                            {
                                                sensorBox.SetDataSource(deviceInfoVO, true);  // 刷新数据
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("无相关设备，请添加设备");
                    }
                    break;
                }
            }
        }

        #endregion

        #region 开始采集和停止采集


        /// <summary>
        /// 全部开始事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!startState)
            {
                this.StartButton.Enabled = false;
                this.EndButton.Enabled = true;
                startState = !startState;
                isAll = 1;  // 全部开始标记设置为1
                SetButtonTextForAllSensorBoxes("停止采集", true);
                deviceDataService = new DeviceDataService();

                deviceDataService.RealTimeToDB();

                // 并行运行两个任务
                //Task dbTask = deviceDataService.RealTimeToDBAsync();  // 先入库
                //Task showTask = RealTimeShow();  // 再显示

                // 等待两个任务完成
                //await Task.WhenAll(dbTask, showTask);
            }
        }

        /// <summary>
        /// 全部停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndButton_Click(object sender, EventArgs e)
        {
            this.StartButton.Enabled = true;
            this.EndButton.Enabled = false;
            SetButtonTextForAllSensorBoxes("开始采集",true);
            startState = !startState;
            isAll = 0; // 全部开始标记设置为0
            deviceDataService.StopRealTimeToDBAsync();  // 停止数据入库
            StopReadlTimeShow(); // 停止实时数据显示

        }

        /// <summary>
        /// 设置每个盒子按钮的状态信息
        /// </summary>
        /// <param name="newText"></param>
        /// <param name="ButtonState"></param>
        private void SetButtonTextForAllSensorBoxes(string newText, bool buttonState)
        {
            foreach (var sensorListForm in SensorBoxListPages.Values)
            {
                // 在每个 SensorListForm 中找到 flp_SensorBoxList 控件
                var flpSensorBoxList = sensorListForm.Controls.Find("flp_SensorBoxList", true).FirstOrDefault();
                //Console.WriteLine($"SensorListForm: {sensorListForm.Name}");

                //foreach (Control control in sensorListForm.Controls)
                //{
                //    Console.WriteLine($"    Control Name: {control.Name}, Type: {control.GetType().FullName}");

                //    // 如果 control 是容器类型，检查其中的子控件
                //    if (control is ContainerControl container)
                //    {
                //        foreach (Control childControl in container.Controls)
                //        {
                //            Console.WriteLine($"        Child Control Name: {childControl.Name}, Type: {childControl.GetType().FullName}");
                //        }
                //    }
                //}

                //如果找到了 flp_SensorBoxList，递归设置其中按钮的 Text
                if (flpSensorBoxList != null)
                {
                    // 遍历 flp_SensorBoxList 中的每个控件
                    foreach (Control control in flpSensorBoxList.Controls)
                    {
                        // 在每个 flp_SensorBoxList 中找到 FlowLayoutPanel 控件
                        if (control is FlowLayoutPanel flowLayoutPanel)
                        {
                            // 遍历 FlowLayoutPanel 中的每个控件找到 USensorInfoBox（盒子组成的集合）
                            foreach (Control controlFlow in flowLayoutPanel.Controls)
                            {
                                if (controlFlow is USensorInfoBox sensorBox)
                                {
                                    if (buttonState == true)
                                    {
                                        sensorBox.OneButton.Enabled = true;
                                        sensorBox.OneButton.Text = newText;
                                    }
                                    else
                                    {
                                        sensorBox.OneButton.Enabled = false;
                                        sensorBox.OneButton.Text = newText;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 定时将实时数据库中数据存入历史数据库并清空实时数据库

        private int CalculateInterval()
        {
            // 获取目标时间
            DateTime targetTime = GetBackTime();
            // 计算时间间隔
            TimeSpan timeUntilTarget = targetTime - DateTime.Now;

            Console.WriteLine($"下一次备份时间：{targetTime} \n距离下一次备份操作还有：{timeUntilTarget}");

            // 返回计算的时间间隔
            return (int)timeUntilTarget.TotalMilliseconds;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("触发了Timer事件");

                // 先判断是否设置了链接字符串
                if (string.IsNullOrEmpty(SetupForm.conStr))
                {
                    MessageBox.Show("请先保存数据库连接字符串，否则数据无法备份");
                    return;
                }
                // 获取实时数据库的数据
                List<DeviceRealtimeValue> deviceRealtimeValues = new DeviceRealtimeValueManages().GetList();

                // 将实时数据库数据迁移到历史数据库
                DateTime collectDate = DateTime.Now.Date;      // 获取当前系统日期
                string subTableName = $"subtable_value{collectDate:yyyyMMdd}"; // 获取表名
                HistoryTable historyTable = new HistoryTable();
                // 首先判断历史数据库名是否存在
                if (!historyTable.IsExist(subTableName))
                {
                    // 如果不存在，创建历史数据库
                    historyTable.CreateHistoryTable(collectDate, subTableName);
                }
                // 迁移数据，使用插入历史数据接口，要求传递的参数：实时数据、子表的存储日期、子表名
                if (deviceRealtimeValues.Count > 0)
                {
                    historyTable.InsertDataToHistoryTable(deviceRealtimeValues, collectDate, subTableName);

                    //将实时数据库清空
                    DeviceRealtimeValueManages deviceRealtimeValueManages = new DeviceRealtimeValueManages();
                    deviceRealtimeValueManages.DeleteBatches(deviceRealtimeValues);
                }
                else Console.WriteLine("实时数据为空");

                // 计算下一次备份时间和时间间隔
                DateTime targetTime = GetBackTime();
                TimeSpan timeUntilTarget = targetTime - DateTime.Now;
                Console.WriteLine($"下一次备份时间：{targetTime} \n距离下一次备份操作还有：{timeUntilTarget}");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("定时事件失败:" + ex.Message);
            }
            
        }

        /// <summary>
        /// 获取备份时间
        /// </summary>
        /// <returns></returns>
        private DateTime GetBackTime()
        {
            // 计算距离明天特定时刻的时间间隔
            DateTime targetTime = DateTime.Today.AddHours(3); // 设置为每天凌晨3点触发
            //DateTime targetTime = DateTime.Parse(DateTime.Now.ToString()); //测试

            // 确认最终的备份时间
            if (DateTime.Now > targetTime)
            {
                targetTime = targetTime.AddDays(1); // 如果目标时刻已经过去，则设置为明天同一时刻
                //targetTime = targetTime.AddSeconds(60); //测试s
                //targetTime = targetTime.AddMinutes(1); //测试m
            }
            return targetTime;
        }
        #endregion

    }
}

