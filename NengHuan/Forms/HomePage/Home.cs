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

namespace NengHuan.Forms.HomePage
{
    public partial class Home : UIPage
    {
        public Home()
        {
            InitializeComponent();
            w1 = this.Width;//窗口最开始的宽
            h1 = this.Height;//窗口最开始的高
            setTag(this);
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
        /// <param name="scaleX">窗体新的宽</param>
        /// <param name="scaley">窗体新的高</param>
        /// <param name="cons">窗体</param>
        private void setControls(float scaleX, float scaley, Control cons)
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
                        con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * scaleX);//宽度
                        con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * scaley);//高度
                        con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * scaleX);//左边距
                        con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * scaley);//顶边距
                        Single currentSize = System.Convert.ToSingle(mytag[4]) * scaley;//字体大小
                        con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                        if (con.Controls.Count > 0)
                        {
                            setControls(scaleX, scaley, con);
                        }
                    }
                    catch (Exception e)
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
        private void F_Home_SizeChanged(object sender, EventArgs e)
        {
            float scaleX = (this.Width) / w1;
            float scaleY = (this.Height) / h1;
            setControls(scaleX, scaleY, this);
        }
        #endregion
    }
}
