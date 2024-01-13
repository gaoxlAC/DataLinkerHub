using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using NengHuan.Models.Sjcj;
using NengHuan.Database.MySQL.Service;
using NengHuan.Database.VO;
using Sunny.UI;
using NengHuan.UI;

namespace NengHuan.UserControls
{
    public partial class USensorInfoBox : UserControl
    {
        /// <summary>
        /// 节点对象
        /// </summary>
        public DeviceInfoVO Node { get; set; }

        // 在 USensorInfoBox 中定义一个字段来保存滚动位置
        private static int savedVerticalScrollPosition = 0;


        public bool isStarted;

        public USensorInfoBox()
        {
            InitializeComponent();
            
            isStarted = false;

            RefreshData();

        }


        // 保存滚动位置的方法
        private void SaveScrollPosition()
        {
            savedVerticalScrollPosition = SensorInfoTextBox.VerticalScroll.Value;
        }

        // 还原滚动位置的方法
        private void RestoreScrollPosition()
        {
            SensorInfoTextBox.VerticalScroll.Value = savedVerticalScrollPosition;
        }

        // 方法用于更新 OneButton 的状态
        public void UpdateOneButtonState(bool isConnected, bool isStarted)
        {
            // 根据连接状态和启动状态更新 OneButton 的状态
            if (!isConnected)
            {
                OneButton.Enabled = false;
            }
            else
            {
                OneButton.Enabled = true;

            }
        }

        /// <summary>
        /// 设置传感器盒子数据源
        /// </summary>
        /// <param name="sensor"></param>
        public void SetDataSource(DeviceInfoVO node, bool setLed)
        {
            // 保存滚动位置
            SaveScrollPosition();
            this.SensorInfoTextBox.Font = new Font("Courier New", 10);  // 设置等宽字体
            this.Node = node;
            this.lb_SensorName.Text = node.DeviceName;
            if (setLed == true) this.SetLedColor(node.IsCollection);


            //// 设备所处位置
            //this.txt_SensorLabel.Text = node.Location;

            //// 添加设备信息
            //this.SensorInfoTextBox.Text += $"设备序号：{node.Sort}\n";

            //// 添加点位信息表格头部
            //this.SensorInfoTextBox.Text += "\n点位信息：\n";
            //this.SensorInfoTextBox.Text += "-------------------------------------------------\n";
            //this.SensorInfoTextBox.Text += "描述\t\t值\t\t单位\t\t采集时间\n";
            //this.SensorInfoTextBox.Text += "-------------------------------------------------\n";

            //// 遍历添加点位信息
            //foreach (var nodeInfo in node.NodeInfos)
            //{
            //    // 处理数值
            //    if (double.TryParse(nodeInfo.Value, out double numericValue))
            //    {
            //        // 如果可以转为数值，保留两位小数
            //        nodeInfo.Value = numericValue.ToString("F2");
            //    }
            //    // 处理状态
            //    else if (bool.TryParse(nodeInfo.Value, out bool booleanValue))
            //    {
            //        // 如果可以转为状态，转为中文
            //        nodeInfo.Value = booleanValue ? "正常" : "故障";
            //    }
            //    // 使用 PadRight 确保每列占用相同的宽度
            //    if(nodeInfo.Value != null && nodeInfo.Unit != null)
            //    {
            //        this.SensorInfoTextBox.Text += $"{nodeInfo.NodeDescribe.PadRight(20)}{nodeInfo.Value.PadRight(10)}{nodeInfo.Unit.PadRight(10)}{nodeInfo.CollectTime}\n";
            //    }
            //    else if(nodeInfo.Value != null)
            //    {
            //        this.SensorInfoTextBox.Text += $"{nodeInfo.NodeDescribe.PadRight(20)}{nodeInfo.Value.PadRight(20)}{nodeInfo.CollectTime}\n";
            //    }
            //    else
            //    {
            //        this.SensorInfoTextBox.Text += $"{nodeInfo.NodeDescribe.PadRight(35)}{nodeInfo.CollectTime}\n";
            //    }
            //}
            //// 添加表格底部
            //this.SensorInfoTextBox.Text += "-------------------------------------------------\n";
            // 使用 StringBuilder 构建文本内容
            StringBuilder sb = new StringBuilder();

            // 设备所处位置
            this.txt_SensorLabel.Text = node.Location;

            // 添加设备信息
            sb.AppendLine($"设备序号：{node.Sort}");

            // 添加点位信息表格头部
            // 设置固定宽度
            int columnWidth = 20;
            sb.AppendLine("\n点位信息：");
            sb.AppendLine(new string('-', columnWidth * 4));
            sb.AppendLine($"{"描述".PadRight(columnWidth)}{"值".PadRight(columnWidth)}{"单位".PadRight(columnWidth)}{"采集时间"}");
            sb.AppendLine(new string('-', columnWidth * 4));

            // 遍历添加点位信息
            foreach (var nodeInfo in node.NodeInfos)
            {
                // 处理数值
                if (double.TryParse(nodeInfo.Value, out double numericValue))
                {
                    // 如果可以转为数值，保留两位小数
                    nodeInfo.Value = numericValue.ToString("F2");
                }
                // 处理状态
                else if (bool.TryParse(nodeInfo.Value, out bool booleanValue))
                {
                    // 如果可以转为状态，转为中文
                    nodeInfo.Value = booleanValue ? "正常" : "故障";
                }

                // 使用 StringBuilder 构建每一行的文本
                StringBuilder line = new StringBuilder();

                // 使用 AppendFormat 添加格式化的文本
                // 该点位是有值且有单位（数值型）
                if (nodeInfo.Value != null && nodeInfo.Unit != null)
                {
                    // 使用 AppendFormat 添加格式化的文本，PadRight 保证宽度不超过 columnWidth
                    line.AppendFormat("{0,-" + columnWidth + "}{1,-" + columnWidth + "}{2,-" + columnWidth + "}{3}",
                          nodeInfo.NodeDescribe, nodeInfo.Value, nodeInfo.Unit, nodeInfo.CollectTime);
                }
                // 该点位有值无单位（状态型）
                else if (nodeInfo.Value != null)
                {
                    line.AppendFormat("{0,-13}{1,-40}{2}", nodeInfo.NodeDescribe, nodeInfo.Value, nodeInfo.CollectTime);
                }
                // 该点位只有点位描述，无任何状态位
                else
                {
                    line.AppendFormat("{0,-50}{1}", nodeInfo.NodeDescribe, nodeInfo.CollectTime);
                }
                // 将这一行添加到总的文本内容中
                sb.AppendLine(line.ToString());
            }

            // 添加表格底部
            sb.AppendLine(new string('-', columnWidth * 4));

            // 一次性设置文本框内容
            this.SensorInfoTextBox.Text = sb.ToString();
            RestoreScrollPosition();
        }

        #region 刷新数据
        public void RefreshData()
        {
            /*for (int i = 0; i < 10; i++)
            {
                Data data = new Data();
                data.Column1 = "Data" + i.ToString("D2");
                data.Column2 = i.Mod(2) == 0 ? "20" : "33";
                data.Column3 = i.Mod(2) == 0 ? "℃" : "m/s";
                data.Column4 = System.DateTime.Now.ToString("g");
                datas.Add(data);
            }
            dataGridView.DataSource = datas;
            //调整列宽，以适合该列中的所有单元格的内容，包括标题单元格。
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
*/
            SensorInfoTextBox.Text = "First Line" + System.Environment.NewLine + "Second Line" + System.Environment.NewLine + "Third Line";
        }

        #endregion
        /// <summary>
        /// 设置传感器led灯的颜色
        /// </summary>
        /// <param name="status"></param>
        private void SetLedColor(bool status)
        {
            if (status)
            {
                this.led_SensorStatus.Enabled= true;
            }
            else
            {
                this.led_SensorStatus.Enabled = false;
            }
        }
        /// <summary>
        /// 自定义事件：右击控件
        /// </summary>
        [Category("SuGar-Control")]
        public event MouseEventHandler BoxMouseClick;
        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            this.BoxMouseClick?.Invoke(this, e);
        }

        /// <summary>
        /// 自定义事件：指针进入控件可见部分
        /// </summary>
        [Category("SuGar-Control")]
        public event EventHandler BoxMouseEnter;
        private void Control_MouseEnter(object sender, EventArgs e)
        {
            this.BoxMouseEnter?.Invoke(this, e);
        }

        /// <summary>
        /// 自定义事件：指针离开控件可见部分
        /// </summary>
        [Category("SuGar-Control")]
        public event EventHandler BoxMouseLeave;
        private void Control_MouseLeave(object sender, EventArgs e)
        {
            this.BoxMouseLeave?.Invoke(this, e);
        }

        private void SensorInfoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //禁止用户编辑
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                OneButton.Text = "停止采集";
                isStarted = !isStarted;
            }
            else
            {
                OneButton.Text = "开始采集";
                isStarted = !isStarted;
            }
        }
    }
}
