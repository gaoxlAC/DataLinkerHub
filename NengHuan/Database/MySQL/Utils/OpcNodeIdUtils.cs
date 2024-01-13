using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.MySQL.Utils
{
    /// <summary>
    /// 关于OpcNodeId的处理，主要是拆分NodeId，方便入库
    /// </summary>
    public class OpcNodeIdUtils
    {
        /// <summary>
        /// 根据传入的 nodeId 获取父设备的 DeviceId
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public string GetParentDeviceId(string nodeId)
        {
            // 根据传入的 nodeId 获取父设备的 DeviceId
            var parts = nodeId.Split('.');
            if (parts.Length >= 2)
            {
                return string.Join(".", parts.Take(parts.Length - 1));
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取通道名称
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public string GetPassageName(string nodeId)
        {
            // NodeId : ns=2;s=Channel1.Device1.Tag1
            var parts = nodeId.Split('.');
            if (parts.Length >= 2)
            {
                var passString = parts[0].Split('='); // 取第一部分有关通道名称的字符串
                return passString[2];
            }

            return string.Empty;
        }

        /// <summary>
        /// 根据传入的 nodeId 获取设备的名称
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public string GetDeviceName(string nodeId)
        {
            // NodeId : ns=2;s=Channel1.Device1.Tag1
            var parts = nodeId.Split('.');
            if (parts.Length >= 2)
            {
                return parts[1]; // 设备名称位于第二部分
            }

            return string.Empty;
        }
        /// <summary>
        /// 根据传入的 nodeId 获取节点的描述
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public string GetNodeDescription(string nodeId)
        {
            // // NodeId : ns=2;s=Channel1.Device1.Tag1
            var parts = nodeId.Split('.');
            if (parts.Length >= 1)
            {
                return parts.Last(); // 最后一个部分即为节点描述
            }

            return string.Empty;
        }
    }
}
