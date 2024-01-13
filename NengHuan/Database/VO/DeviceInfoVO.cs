using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.VO
{
    // 返回展示到界面的设备信息相关的字段
    public class DeviceInfoVO
    {
        /// <summary>
        /// 设备序号
        /// </summary>
        public int Sort { get; set; }


        /// <summary>
        /// 设备编码
        /// </summary>
        public string DeviceId { get; set; }


        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 设备类型编码
        /// </summary>
        public string TypeId { get; set; }

        /// <summary>
        /// 设备类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 设备下的所有点位信息
        /// </summary>
        public List<NodeInfoVO> NodeInfos { get; set; }

        /// <summary>
        /// 所属父设备名称
        /// </summary>
        public string ParentDeviceName { get; set; }

        /// <summary>
        /// 所属系统名称
        /// </summary>
        public string ParentSystemName { get; set; }

        /// <summary>
        /// 安装位置
        /// </summary>
        public string Location { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 是否正在采集
        /// </summary>
        public bool IsCollection { get; set; }
    }
}
