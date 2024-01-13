using MySqlX.XDevAPI;
using NengHuan.Forms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NengHuan.OPCUA
{
    /// <summary>
    /// 整个系统都使用这个服务器连接对象
    /// </summary>
    public class ServiceConnect
    {
        // 创建OpcUaClient静态对象
        public static OpcUaClient s_OpcUaClient = null;
        public string ConnStr = "Opc.tcp://127.0.0.1:49320";
        #region 服务器连接和关闭
        /// <summary>
        /// 从服务器配置获取已经连接的客户端对象
        /// </summary>
        /// <returns></returns>
        public OpcUaClient GetOpcUaClient()
        {
            // 从配置文件Connecttion.config中读取服务器地址
            if (s_OpcUaClient == null)
            {
                Console.WriteLine("服务器未连接");
            }                          
            return s_OpcUaClient;
        }

        /// <summary>
        /// 设置OPC客户端
        /// </summary>
        /// <param name="opcUaClient"></param>
        /// <returns></returns>
        public void SetOpcUaClient(OpcUaClient opcUaClient)
        {
            s_OpcUaClient = opcUaClient;
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <returns></returns>
        public OpcUaClient DisConnect()
        {
            s_OpcUaClient.Disconnect();
            s_OpcUaClient = null;
            return s_OpcUaClient;
        }
        #endregion
    }
}
