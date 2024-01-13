using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.VO
{
    /// <summary>
    /// 按照设备类型存设备，按照设备存其下的点位信息
    /// </summary>
    public class DeviceTypeInfoVO
    {
        /// <summary>
        /// 设备类型名称
        /// </summary>
        public string DeviceTypeName { get; set; }

        /// <summary>
        /// 读取频率
        /// <summary>
        public int ReadFrequency { get; set; }

        /// <summary>
        /// 设备及其点位信息
        /// <summary>
        public List<DeviceInfoVO> Devices { get; set; }
    }
}
