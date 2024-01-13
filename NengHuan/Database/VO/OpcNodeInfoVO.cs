using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.VO
{
    /// <summary>
    /// OPC点位信息
    /// </summary>
    public class OpcNodeInfoVO
    {
        /// <summary>
        /// NodeId：这里的NodeId是OPC服务器的NodeId，和数据库中的node_id格式不同
        /// </summary>
        public string NodeId { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 信号值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 采集时间戳
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// 数据是否有效
        /// </summary>
        public string Quality { get; set; }

    }
}
