using NengHuan.OPCUA;
using Opc.Ua;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NengHuan.Forms.Common
{
    public partial class FormConnectSelect : UIEditForm
    {
        public FormConnectSelect(OpcUaClient opcUaClient)
        {
            InitializeComponent();
            this.m_OpcUaClient = opcUaClient;
        }

        private OpcUaClient m_OpcUaClient;

        private void uiButton4_Click(object sender, EventArgs e)
        {
            string dir = "";
            if (DirEx.SelectDirEx("扩展打开文件夹", ref dir))
            {
                UIMessageTip.ShowOk(dir);
            }
        }

        protected override bool CheckData()
        {
            return (CheckEmpty(this.tBuserName, "用户名称不能为空！")
                   && CheckEmpty(this.tBuserPassword, "密码不能为空！"))
             || (CheckEmpty(this.tBCertificate, "证书不能为空！")
             && CheckEmpty(this.tBzsPassword, "密码不能为空！"));
        }

        private void btn_NameLogin_Click(object sender, EventArgs e)
        {
            //用户名密码登录
            if (tBuserName.Text.Trim().Equals(""))
            {
                this.ShowWarningDialog("用户名称不能为空！");
                return;
                
            }
            if(tBuserPassword.Text.Trim().Equals(""))
            {
                this.ShowWarningDialog("密码不能为空！");
            }
           else
            {
                m_OpcUaClient.UserIdentity = new UserIdentity(tBuserName.Text, tBuserPassword.Text);
                DialogResult = DialogResult.OK;
                return;
            }
        }

        private void btn_CertificateLogin_Click(object sender, EventArgs e)
        {

            if (tBCertificate.Text.Trim().Equals(""))
            {
                this.ShowWarningDialog("证书不能为空！");
                return ;

            }
            if (tBzsPassword.Text.Trim().Equals(""))
            {
                this.ShowWarningDialog("密码不能为空！");
                return;
            }
            else
            {
                X509Certificate2 certificate = new X509Certificate2("[证书的路径]", "[密钥]", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                m_OpcUaClient.UserIdentity = new UserIdentity(certificate);
                DialogResult = DialogResult.OK;
                return;
            }
        }

        private void btn_AnonymousLogin_Click(object sender, EventArgs e)
        {
            //匿名登陆
            m_OpcUaClient.UserIdentity = new UserIdentity(new AnonymousIdentityToken());
            DialogResult = DialogResult.OK;
            return;
        }
    }
}
