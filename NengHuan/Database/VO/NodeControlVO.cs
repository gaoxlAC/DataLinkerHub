using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.VO
{
    public class NodeControlVO
    {
        /// <summary>
        /// 通道.设备.点位描述
        /// </summary>
        public string PassageDeviceNode { get; set; }

        /// <summary>
        /// 点位状态值
        /// </summary>
        public string Value { get; set; }
    }
}
