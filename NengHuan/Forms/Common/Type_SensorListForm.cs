using NengHuan.UserControls;
using NengHuan.Models.Sjcj;
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
using NengHuan.Database.MySQL.Service;
using NengHuan.OPCUA;
using NengHuan.Database.VO;
using NengHuan.UI;
using System.Threading;

namespace NengHuan.Forms.Common
{
    public partial class Type_SensorListForm : UIPage
    {
        #region 属性
        /// <summary>
        /// 获取一个日志记录器
        /// </summary>
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(Type_SensorListForm));
        /// <summary>
        /// 页面上的传感器模型列表（没啥用）
        /// </summary>
        //public List<LocalSensor> Sensors { get; set; } = new List<LocalSensor>();
        /// <summary>
        /// 选中的传感器(这个选择数据库还要改！！！）
        /// </summary>
        public BaseDataNode SelectedSensor { get; set; }
        /// <summary>
        /// 选中的传感器盒子
        /// </summary>
        public List<USensorInfoBox> SelectSensorBox { get; set; }
        /// <summary>
        /// 设备采集状态
        /// </summary>
        public static DeviceDataService deviceDataService { get; set; }
        

        #endregion

        public Type_SensorListForm()
        {
            InitializeComponent();

            #region 大小自适应
            w1 = this.Width;//窗口最开始的宽
            h1 = this.Height;//窗口最开始的高
            this.setTag(this);
            


            #endregion
        }     

        #region 控件大小随窗体大小等比例缩放
        private float w1;
        private float h1;

        /// <summary>
        /// 获取窗口或父控件中的控件的属性（位置和尺寸），每个控件都有一个tag属性，而且是空的，这里可以拿来用
        /// </summary>
        /// <param name="cons">窗体</param>
        private void setTag(Control cons)
        {
            //遍历子控件
            foreach (Control con in cons.Controls)
            {
                //将子控件的宽、高、左边坐标、顶部坐标以及字号存在控件的tag属性中
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }

        /// <summary>
        /// 用于在窗体大小变化后设置控件的位置即大小
        /// </summary>
        /// <param name="scalex">窗体新的宽</param>
        /// <param name="scaley">窗体新的高</param>
        /// <param name="cons">窗体</param>
        private void setControls(float scalex, float scaley, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    try
                    {
                        //取出控件的tag属性中的宽、高、左边坐标、顶部坐标以及字号
                        string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                        //根据窗体缩放的比例确定控件的值
                        con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * scalex);//宽度
                        con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * scaley);//高度
                        con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * scalex);//左边距
                        con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * scaley);//顶边距
                        if (con.Name != "rtxt_ShowMsg")
                        {
                            Single currentSize = System.Convert.ToSingle(mytag[4]) * scaley;//字体大小
                            con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                        }
                        if (con.Controls.Count > 0)
                        {
                            setControls(scalex, scaley, con);
                        }
                    }
                    catch (Exception)
                    {
                        //最小化时会报异常，在此处理
                        ;
                    }
                }
            }
        }

        /// <summary>
        /// 窗体大小改变事件
        /// </summary>
        private void Type_SensorListForm_SizeChanged(object sender, EventArgs e)
        {
            float scaleX = (this.Width) / w1;
            float scaleY = (this.Height) / h1;
            setControls(scaleX, scaleY, this);
        }

        #endregion

        #region 加快控件绘制
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        #endregion

        #region 添加传感器并刷新


        /// <summary>
        /// 添加传感器盒子到盒子列表
        /// </summary>
        /// <param name="newSensor"></param>
        internal void AddSensorBox(DeviceInfoVO newSensor)
        {
   
            USensorInfoBox sensorBox = new USensorInfoBox();
            sensorBox.SetDataSource(newSensor,true);

            sensorBox.Show();
            sensorBox.Margin = new Padding(10, 10, 10, 10);
            //sensorBox.BoxMouseClick += new MouseEventHandler(this.SensorBox_MouseRightDown);
            //sensorBox.BoxMouseEnter += new EventHandler(this.SensorBox_MouseEnter);
            //sensorBox.BoxMouseLeave += new EventHandler(this.SensorBox_MouseLeave);
            this.flp_SensorBoxList.Controls.Add(sensorBox);
        }

        #endregion

        /// <summary>
        /// 委托：用于操作Main页面的侧边菜单
        /// </summary>
        public event Action<DeviceInfoVO> AddSensor;  // 用于之前的AddSensor方法

        public event Action<DeviceTypeInfoVO> AddSensorType; // 用于现在的AddSensorType方法

        #region 下拉框频率选取
        private void FreComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string seneorKey = SensorTypeName.Text;
            //Console.WriteLine(seneorKey);
            FMain.DeviceTypeInfos[seneorKey].ReadFrequency = int.Parse(FreComboBox.Text);
            Console.WriteLine(FMain.DeviceTypeInfos[seneorKey].DeviceTypeName+ FMain.DeviceTypeInfos[seneorKey].ReadFrequency);
        }
        #endregion
    }

}

