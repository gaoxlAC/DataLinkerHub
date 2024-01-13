using NengHuan.Models;
using NengHuan.Database.SqLite;
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
using NengHuan.Database.VO;
using NengHuan.Database.MySQL.ModelsManage;
using NengHuan.Models.Sjcj;
using NengHuan.Database.MySQL.Service;

namespace NengHuan.Forms.Common
{
    public partial class AddOrConfigDeviceForm : UIEditForm
    {
        #region 属性
        /// <summary>
        /// 获取一个日志记录器
        /// </summary>
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(AddOrConfigDeviceForm));
        /// <summary>
        /// 作为编辑传感器的窗体时，记下修改的传感器
        /// </summary>
        public DeviceInfoVO EditSensor = null;
        #endregion

        public AddOrConfigDeviceForm()
        {
            InitializeComponent();
        }




        #region 表单检查
        /// <summary>
        /// 表单检查
        /// </summary>
        /// <returns></returns>
        protected override bool CheckData()
        {
            bool f1 = CheckEmpty(uiComboBox_NodeDescribe, "点位描述不能为空！")
                   && CheckEmpty(uiTextBox_DeviceName, "设备名称不能为空")
                   && CheckEmpty(uiComboBox_ReadFrequency, "读取频率不能为空！")
                   //&& CheckEmpty(uiTextBox_WriteFrequency, "存储频率不能为空！")
                   && CheckProtocolIsSelected(uiComboBox_Protocol)
                   && CheckSensorRange(uiTextBox_RangeLow, uiTextBox_RangeHigh)
                   && CheckIsWrite(uiComboBox_IsWrite, uiTextBox_WriteFrequency, uiComboBox_WriteFrequencyUnit);
                   //&& CheckEmpty(uiTextBox_Ratio, "系数不能为空！")
                   //&& CheckSensorIDIsExist(uiTextBox_SensorID)
                   //&& CheckSensorRange(uiTextBox_RangeLow, uiTextBox_RangeHigh)
                   //&& CheckEmpty(uiComboBox_RangeUnit, "传感器量程的单位不能为空！")
                   //&& CheckEmpty(uiTextBox_Calibration, "参数不能为空！")
                   //if (!f1) return f1;
            return f1;
            //bool f2 = true;
            //foreach (Control control in uiGroupBox_AcquisitionParams.Controls)
            //{
            //    if (control.Name == "uiTextBox_IPAddress" && control.Text.Trim().Length == 0)
            //    {
            //        this.ShowWarningDialog("IP地址不能为空！");
            //        control.Focus();
            //        f2 = false;
            //        break;
            //    }
            //    if (control.Name == "uiTextBox_Port" && control.Text.Trim().Length == 0)
            //    {
            //        this.ShowWarningDialog("端口号不能为空！");
            //        control.Focus();
            //        f2 = false;
            //        break;
            //    }
            //    if (control.Name == "uiTextBox_SerialPort" && control.Text.Trim().Length == 0)
            //    {
            //        this.ShowWarningDialog("串口号不能为空！");
            //        control.Focus();
            //        f2 = false;
            //        break;
            //    }
            //    if (control.Name == "uiTextBox_BaudRate" && control.Text.Trim().Length == 0)
            //    {
            //        this.ShowWarningDialog("波特率不能为空！");
            //        control.Focus();
            //        f2 = false;
            //        break;
            //    }
            //}
            //if (!f2) return f2;

            //bool f3 = CheckEmpty(uiTextBox_RegisterAddressOffset, "寄存器地址偏移不能为空！")
            //       && CheckEmpty(uiTextBox_RegisterCnt, "寄存器地址个数不能为空！")
            //       && CheckEmpty(UITextBox_AcquisitionInterval, "采集间隔不能为空！")
            //       && CheckEmpty(uiTextBox_Coefficient, "入库间隔不能为空!");
            //return f1 && f2 && f3;
        }


        /// <summary>
        /// 选择通讯协议
        /// </summary>
        /// <param name="uiComboBox_SensorType"></param>
        /// <returns></returns>
        private bool CheckProtocolIsSelected(UIComboBox uiComboBox_Protocol)
        {
            if (uiComboBox_Protocol.SelectedIndex == -1)
            {
                this.ShowErrorDialog("通信协议不能为空");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检查传感器编号是否重复
        /// </summary>
        /// <param name="uiTextBox_SensorID"></param>
        /// <returns></returns>
     /*   private bool CheckSensorIDIsExist(UITextBox uiTextBox_SensorID)
        {
            if (this.Text.Contains("编辑传感器") && uiTextBox_SensorID.Text == this.EditSensor.SId)
            {
                return true;
            }

            LocalSensor sensor = new LocalSensorManage().GetBySensorId(uiTextBox_SensorID.Text.Trim());
            if (!(sensor is null))
            {
                this.ShowWarningDialog("传感器编号已存在！");
                return false;
            }
            return true;
        }*/

        /// <summary>
        /// 检查传感器名称是否重复
        /// </summary>
        /// <param name="uiTextBox_SensorName"></param>
        /// <returns></returns>
        //private bool CheckPTNameIsExist(UITextBox uiTextBox_SensorName)
        //{
        //    if (this.Text.Contains("编辑传感器") && uiTextBox_SensorName.Text == this.EditSensor.NodeInfos[0].NodeDescribe)
        //    {
        //        return true;
        //    }

        //    DeviceInfoVO sensor = new BaseDataNodeManages().GetList(uiTextBox_SensorName.Text.Trim());
        //    if (!(sensor is null))
        //    {
        //        this.ShowWarningDialog("点位已存在！");
        //        return false;
        //    }
        //    return true;
        //}

        /// <summary>
        /// 检查信号值量程的合理性
        /// </summary>
        /// <param name="uiTextBox_SensorRangeL"></param>
        /// <param name="uiTextBox_SensorRangeH"></param>
        /// <returns></returns>
        private bool CheckSensorRange(UITextBox uiTextBox_SensorRangeL, UITextBox uiTextBox_SensorRangeH)
        {
            string strSensorRangeL = uiTextBox_SensorRangeL.Text.Trim();
            string strSensorRangeH = uiTextBox_SensorRangeH.Text.Trim();
            bool f1 = CheckEmpty(uiTextBox_SensorRangeL, "信号值量程下限不能为空！")
                     && CheckEmpty(uiTextBox_SensorRangeL, "信号值量程上限不能为空！");
            if (!f1) return f1;

            double SensorRangeL = double.Parse(strSensorRangeL);
            double SensorRangeH = double.Parse(strSensorRangeH);
            bool f2 = true;
            if (SensorRangeL >= SensorRangeH)
            {
                this.ShowWarningDialog("传感器量程上、下限不合理！");
                f2 = false;
                uiTextBox_SensorRangeL.Focus();
            }
            return f1 && f2;
        }
        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            //MessageBox.Show(e.KeyChar.ToString());
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)46 && e.KeyChar != (char)'-')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 检查读写频率的合理性
        /// </summary>
        /// <param name="uiComboBox_IsWrite"></param>
        /// <param name="uiTextBox_WriteFrequency"></param>
        /// <param name="uiComboBox_WriteFrequencyUnit"></param>
        /// <returns></returns>
        private bool CheckIsWrite(UIComboBox uiComboBox_IsWrite, UITextBox uiTextBox_WriteFrequency, UIComboBox uiComboBox_WriteFrequencyUnit)
        {
            bool f1=true;
            bool f2 = true;
            string IsWrite = uiComboBox_IsWrite.Text.Trim();
            string WriteFrequency = uiTextBox_WriteFrequency.Text.Trim();
            string WriteFrequencyUnit = uiComboBox_WriteFrequencyUnit.Text.Trim();
            if (IsWrite == "是")
            {
                    f1 = CheckEmpty(uiTextBox_WriteFrequency, "读写频率不能为空！")
                     && CheckEmpty(uiComboBox_WriteFrequencyUnit, "读写频率单位不能为空！");
                Console.Write("是");
            }
            else
            {
                Console.Write("否");
            }
            
            return f1&f2 ;
        }

        public BaseDataNode GetNodeInfo()
        {
            BaseDataNode nodeInfoRes = new BaseDataNode();

            // 设备名称和点位描述
            nodeInfoRes.DeviceName = this.uiTextBox_DeviceName.Text.Trim();
            nodeInfoRes.NodeDescribe = this.uiComboBox_NodeDescribe.Text.Trim();

            // 判断string是否可以转为int类型
            try
            {
                // 读取频率
                if(this.uiComboBox_ReadFrequencyUnit.Text.Trim() == "s")
                {
                    nodeInfoRes.ScanFrequency = int.Parse(this.uiComboBox_ReadFrequency.Text.Trim()) * 1000;
                }
                else
                {
                    nodeInfoRes.ScanFrequency = int.Parse(this.uiComboBox_ReadFrequency.Text.Trim());
                }                
            }
            catch (Exception)
            {
                this.ShowWarningDialog("扫描频率必须为整数");
                return null;
            }

            // 存储频率和单位
            try
            {
                // 存储频率
                if (this.uiComboBox_WriteFrequencyUnit.Text.Trim() == "s")
                {                   
                    nodeInfoRes.WriteFrequency = (int.Parse(this.uiTextBox_WriteFrequency.Text.Trim()) * 1000).ToString();
                }
                else if(this.uiComboBox_WriteFrequencyUnit.Text.Trim() == "ms")
                {
                    nodeInfoRes.ScanFrequency = int.Parse(this.uiComboBox_ReadFrequency.Text.Trim());
                }
                else nodeInfoRes.WriteFrequency = this.uiTextBox_WriteFrequency.Text.Trim();
            }
            catch (Exception)
            {
                this.ShowWarningDialog("所选单位的存储频率必须为整数");
                return null;
            }
            // 单位
            nodeInfoRes.Unit = this.uiComboBox_Unit.Text.Trim();
            
            // 量程
            if((this.uiTextBox_RangeLow.Text.Trim() != null && this.uiTextBox_RangeLow.Text.Trim() != ""))
            {
                nodeInfoRes.Range = this.uiTextBox_RangeLow.Text.Trim() + "_" + this.uiTextBox_RangeHigh.Text.Trim();                        
            }
            else if((this.uiTextBox_RangeHigh.Text.Trim() != null && this.uiTextBox_RangeHigh.Text.Trim() != ""))
            {
                nodeInfoRes.Range = "_" + this.uiTextBox_RangeHigh.Text.Trim();
            }

            // 数据类型
            nodeInfoRes.DataType = this.uiComboBox_DataType.Text.Trim();

            // 判断string是否可以转为decimal类型
            if (this.uiTextBox_Ratio.Text.Trim() != null && this.uiTextBox_Ratio.Text.Trim() != "")
            {
                try
                {
                    // 系数
                    nodeInfoRes.Ratio = Decimal.Parse(this.uiTextBox_Ratio.Text.Trim());
                }
                catch (Exception)
                {

                    this.ShowWarningDialog("系数必须为数值类型");
                    return null;
                }
            }

            if (this.uiTextBox_Calibration.Text.Trim() != null && this.uiTextBox_Calibration.Text.Trim() != "")
            {
                try
                {
                    // 参数校准
                    nodeInfoRes.Calibration = Decimal.Parse(this.uiTextBox_Calibration.Text.Trim());
                }
                catch (Exception)
                {

                    this.ShowWarningDialog("参数校准必须为数值类型");
                    return null;
                }
            }

            // 协议名称
            nodeInfoRes.ProtocolName = this.uiComboBox_Protocol.Text.Trim();

            // 读写
            string readOrWrite = this.uiComboBox_ReadOrWrite.Text.Trim();
            if (readOrWrite != null && readOrWrite != "")
            {
                if(readOrWrite == "读") nodeInfoRes.ReadWrite = 0;
                else if (readOrWrite == "写") nodeInfoRes.ReadWrite = 1;
                else if(readOrWrite == "读/写") nodeInfoRes.ReadWrite=2;
                else nodeInfoRes.ReadWrite=-1;
            }
            
            // 是否存储
            string isWrite = this.uiComboBox_IsWrite.Text.Trim();
            if(isWrite !=null && isWrite != "")
            {
                if (isWrite == "是") nodeInfoRes.IsWrite = true;
                else if(isWrite == "否") nodeInfoRes.IsWrite= false;
            }
            return nodeInfoRes;
        }

        private void AddOrConfigDeviceForm_ButtonOkClick(object sender, EventArgs e)
        {
            BaseDataNode baseDataNode = GetNodeInfo();
            NodeManageService nodeManageService = new NodeManageService();
            MessageBox.Show(nodeManageService.InsertNodeInfo(baseDataNode));
            Console.WriteLine("点击确认");
        }

        private void AddOrConfigDeviceForm_ButtonCancelClick(object sender, EventArgs e)
        {
            Console.WriteLine("点击取消");
            
        }


        #endregion





        /*#region 添加设备（弃用）
        /// <summary>
        /// 把设备信息写入数据库
        /// </summary>
        public void InsertDeviceIntoDb()
        {
            int deviceType_index = this.uiComboBox_DeviceType.SelectedIndex;
            switch (deviceType_index)
            {
                case 0:
                    this.InsertSensor();
                    break;
            }
        }
        /// <summary>
        /// 委托：用于操作Main页面的侧边菜单
        /// </summary>
        public event Action<LocalSensor> AddSensor;

        #region 添加传感器
        /// <summary>
        /// 添加传感器
        /// </summary>
        public void InsertSensor()
        {
            LocalSensor localSensor = new LocalSensor();
            localSensor.SName = this.uiTextBox_SensorName.Text.Trim();
            localSensor.Address = this.uiTextBox_SensorAddress.Text.Trim();
            localSensor.Type = this.uiComboBox_SensorType.SelectedText;
            localSensor.SId = this.uiTextBox_SensorID.Text.Trim();
            localSensor.Label = this.uiTextBox_SensorLabel.Text.Trim();
            localSensor.RangeL = double.Parse(this.uiTextBox_SensorRangeL.Text.Trim());
            localSensor.RangeH = double.Parse(this.uiTextBox_SensorRangeH.Text.Trim());
            localSensor.Unit = this.uiComboBox_SensorUnit.Text.Trim();
            localSensor.DbTabName = this.uiComboBox_SensorType.SelectedValue.ToString();

            localSensor.RegisterOffset = int.Parse(this.uiTextBox_RegisterAddressOffset.Text.Trim());
            localSensor.RegisterCnt = int.Parse(this.uiTextBox_RegisterCnt.Text.Trim());
            localSensor.AcquisitionInterval = double.Parse(this.UITextBox_AcquisitionInterval.Text.Trim());
            localSensor.AcquisitionIntervalUnit = this.GetTimeUnit(this.uiComboBox_AcquisitionIntervalUnit.SelectedIndex);
            localSensor.SaveInterval = double.Parse(this.uiTextBox_SaveInterval.Text.Trim());
            localSensor.SaveIntervalUnit = this.GetTimeUnit(this.uiComboBox_SaveIntervalUnit.SelectedIndex);
            localSensor.ParseMethod = this.uiComboBox_ParseMethod.SelectedText == "" ? this.uiComboBox_ParseMethod.Text : this.uiComboBox_ParseMethod.SelectedText;
            localSensor.ConvertMethod = this.uiComboBox_ConvertMethod.SelectedText == "" ? this.uiComboBox_ConvertMethod.Text : this.uiComboBox_ConvertMethod.SelectedText;
            localSensor.createBy = "管理员";
            localSensor.createTime = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            localSensor.updateBy = localSensor.createBy;
            localSensor.updateTime = localSensor.createTime;
            localSensor.Status = "停止采集";
            localSensor.LatestACQTime = localSensor.createTime;
            localSensor.LatestSaveTime = localSensor.createTime;

            //try
            //{
            //先在侧边菜单创建传感器列表父节点，并创建相应的传感器节点(用了委托)
            this.AddSensor(localSensor);
            //传感器信息写入数据库
            new LocalSensorManage().Insert(localSensor);

            Logger.Info($"【添加传感器{localSensor.SName}成功！】");
            this.ShowInfoTip($"【添加传感器{localSensor.SName}成功！】");
            //}
            //catch (Exception e)
            //{
            //    Logger.Error($"【添加传感器{localSensor.SName}失败！】\n{e.GetType().Name}:{e.Message}");
            //    this.ShowErrorDialog($"【添加传感器{localSensor.SName}失败！】\n{e.GetType().Name}:{e.Message}");
            //}
        }
        /// <summary>
        /// 根据下拉框选中的序号确定时间单位
        /// </summary>
        /// <param name="selectedIndex"></param>
        /// <returns></returns>
        public string GetTimeUnit(int selectedIndex)
        {
            string unit = "";
            switch (selectedIndex)
            {
                case 0:
                    unit = "sec";
                    break;
                case 1:
                    unit = "min";
                    break;
                case 2:
                    unit = "hour";
                    break;
            }
            return unit;
        }
        /// <summary>
        /// 获取采集参数组中的控件的文本
        /// </summary>
        /// <param name="controlName"></param>
        /// <returns></returns>
        public string GetControlText(string controlName)
        {
            foreach (Control control in this.uiGroupBox_AcquisitionParams.Controls)
            {
                if (control.Name == controlName)
                {
                    return control.Text;
                }
            }
            return "";
        }
        #endregion

        #endregion*/

    }
}
