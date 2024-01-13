using NengHuan.Forms.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NengHuan.UserControls
{
    public partial class UCBtnAddDevice : UserControl
    {
        public UCBtnAddDevice()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 自定义属性：文本，重写实现Text即可
        /// </summary>
        [Browsable(true)]//出现在属性栏（必要的）
        [Category("Appearance")]//分类
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]//指示设计器是否自动生成代码（必要的）
        [Description("文本")]
        public override string Text
        {
            get
            {
                return label1.Text;
            }
            set
            {
                //label1.Text = value;
            }
        }
        /// <summary>
        /// 自定义属性：图片
        /// </summary>
        [Browsable(true)]//出现在属性栏（必要的）
        [Category("Appearance")]//分类（外观）
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]//指示设计器是否自动生成代码（必要的）
        [Description("图片/图标")]
        public Image Image
        {
            get
            {
                return pictureBox1.Image;
            }
            set
            {
                pictureBox1.Image = value;
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.White;
            pictureBox1.Image = Properties.Resources.add2;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(75, 87, 97);
            pictureBox1.Image = Properties.Resources.add1;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.White;
            pictureBox1.Image = Properties.Resources.add2;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(75, 87, 97);
            pictureBox1.Image = Properties.Resources.add1;
        }
        /// <summary>
        /// 自定义事件：添加设备
        /// </summary>
        [Category("添加设备")]
        public event EventHandler AddDevice;
        private void label1_Click(object sender, EventArgs e)
        {
            AddDevice?.Invoke(this, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddDevice?.Invoke(this, e);
            AddOrConfigDeviceForm addOr = new AddOrConfigDeviceForm();
            addOr.ShowDialog();
            Console.WriteLine("添加传感器");
        }
    }

}
