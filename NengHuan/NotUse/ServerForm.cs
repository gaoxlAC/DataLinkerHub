using NengHuan.OPCUA;
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
    public partial class ServerForm : UIEditForm
    {
        public ServerForm()
        {
            InitializeComponent();
            uiLight.OnColor = Color.White;
        }

        List<string> nodeList = new List<string>();
        private DataTable dataTable;

        private void Form1_Load(object sender, EventArgs e)
        {
            // 节点
            // C1.D1
            nodeList.Add("ns=2;s=C1.D1.t1");
            nodeList.Add("ns=2;s=C1.D1.t2");
            nodeList.Add("ns=2;s=C1.D1.t3");
            nodeList.Add("ns=2;s=C1.D1.t4");
            nodeList.Add("ns=2;s=C1.D1.t5");
            nodeList.Add("ns=2;s=C1.D1.t6");
            nodeList.Add("ns=2;s=C1.D1.t7");
            // C1.D2
            nodeList.Add("ns=2;s=C1.D2.t1");
            nodeList.Add("ns=2;s=C1.D2.t2");
            nodeList.Add("ns=2;s=C1.D2.t3");
            nodeList.Add("ns=2;s=C1.D2.t4");
            nodeList.Add("ns=2;s=C1.D2.t5");
            // C2.D1
            nodeList.Add("ns=2;s=C2.D1.t1");
            nodeList.Add("ns=2;s=C2.D1.t2");
            nodeList.Add("ns=2;s=C2.D1.t3");
            nodeList.Add("ns=2;s=C2.D1.t4");
            nodeList.Add("ns=2;s=C2.D1.t5");
            // C2.D2
            nodeList.Add("ns=2;s=C2.D2.t1");
            nodeList.Add("ns=2;s=C2.D2.t2");
            nodeList.Add("ns=2;s=C2.D2.t3");
            nodeList.Add("ns=2;s=C2.D2.t4");
            nodeList.Add("ns=2;s=C2.D2.t5");

  

        }
        /// <summary>
        /// 客户端对象
        /// </summary>
        private static OpcUaClient m_OpcUaClient = null;

        #region 连接服务器
        private async void btn_ConnectServer_Click(object sender, EventArgs e)
        {
            /*this.btn_ConnectServer.BackColor = Color.LightGreen;*/
            uiLight.OnColor = Color.LightGreen;
            if(m_OpcUaClient == null) m_OpcUaClient = new OpcUaClient();
            Console.WriteLine("ServerForm.m_OpcUaClient(btn_ConnectServer_Click):{0}", m_OpcUaClient.ToString());
            try
            {
                // 连接服务器有三种方式：匿名、用户名与密码、证书。该方式为匿名方式
                await m_OpcUaClient.ConnectServer(this.txt_ServerAddress.Text);
                MessageBox.Show(string.Format("连接成功！"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("连接失败！{0}", ex.Message));
            }
        }

        /// <summary>
        /// 获取已经连接的客户端对象
        /// </summary>
        /// <returns></returns>
        public OpcUaClient GetOpcUaClient()
        {
            if (m_OpcUaClient == null)
            {
                Console.WriteLine("ServerForm.m_OpcUaClient(GetOpcUaClient()):null");
            }
            else Console.WriteLine("ServerForm.m_OpcUaClient(GetOpcUaClient()):{0}", m_OpcUaClient.ToString());
            return m_OpcUaClient;
        }
        #endregion

        private void btn_BrowseServer_Click(object sender, EventArgs e)
        {
            //节点浏览器
            FormBrowseServer frm = new FormBrowseServer("Opc.tcp://127.0.0.1:49320");
            frm.ShowDialog();

        }

       
    }
}
