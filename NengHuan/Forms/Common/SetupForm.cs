using log4net;
using NengHuan.Database;
using NengHuan.Models.System;
using NengHuan.UI;
using SqlSugar;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NengHuan.Forms.Common
{
    public partial class SetupForm : UIEditForm
    {
        //数据库连接字符串
        public static String conStr = "user id=root;password=123456;database=yethannyhj;server=127.0.0.1;port=3306;charset=utf8"; 
        /// <summary>
        /// 获取一个日志记录器
        /// </summary>
        ///private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(SetupForm));
        public SetupForm()
        {
            InitializeComponent();
        }

        private void F_SelectProtocol_Load(object sender, EventArgs ea)
        {

        }

        protected override bool CheckData()
        {
            return CheckEmpty(this.tBdbName, "数据库名称不能为空！")
                   && CheckEmpty(this.tBdbServer, "域名不能为空！")
                   && CheckEmpty(this.tBdbPort, "端口号不能为空！")
                   && CheckEmpty(this.tBdbUsername, "用户名不能为空！")
                   && CheckEmpty(this.tBdbPassword, "密码不能为空！");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                conStr = string.Format("user id={0};password={1};database={2};server={3};port={4};charset=utf8", tBdbUsername.Text, tBdbPassword.Text, tBdbName.Text, tBdbServer.Text, tBdbPort.Text);
                MessageBox.Show("保存成功！");
                this.Close();
            }
        }
    }
}

