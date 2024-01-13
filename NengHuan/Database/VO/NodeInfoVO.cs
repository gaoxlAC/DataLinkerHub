using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.VO
{
    /// <summary>
    /// 需要设备信息表base_data_device、点位信息表base_data_node、设备状态表device_data_state、实时数据表device_realtime_value
    /// </summary>
    public class NodeInfoVO
    {

        /// <summary>
        /// 点位id
        /// </summary>
        public string NodeId { get; set; }

        /// <summary>
        /// 点位描述
        /// </summary>
        public string NodeDescribe { get; set; }

        /// <summary>
        /// 监测值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 监测单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 最近的采集时间
        /// </summary>
        public DateTime? CollectTime { get; set; }
    }
}
