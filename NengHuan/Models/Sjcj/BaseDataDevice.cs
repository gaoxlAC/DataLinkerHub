using SqlSugar;
using SqlSugar.DistributedSystem.Snowflake;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Models.Sjcj
{
    [SugarTable("base_data_device")]
    public class BaseDataDevice : Base
    {
        // 继承自Base类的属性字段无需重新定义，已经满足命名规则
        [SugarColumn(IsNullable = true, ColumnName = "system_id", ColumnDataType = "varchar", Length = 20)]
        public string SystemId { get; set; } // 设备编号

        [SugarColumn(IsNullable = true, ColumnName = "system_name", ColumnDataType = "varchar", Length = 50)]
        public string SystemName { get; set; } // 所属系统名称

        [SugarColumn(IsNullable = true, ColumnName = "device_id", ColumnDataType = "varchar", Length = 20)]
        public string DeviceId { get; set; } // 设备编号

        [SugarColumn(IsNullable = true, ColumnName = "device_name", ColumnDataType = "varchar", Length = 50)]
        public string DeviceName { get; set; } // 设备名称

        [SugarColumn(IsNullable = true, ColumnName = "parent_dev_id", ColumnDataType = "varchar", Length = 20)]
        public string ParentDeviceId { get; set; } // 所属设备id

        [SugarColumn(IsNullable = true, ColumnName = "parent_dev_name", ColumnDataType = "varchar", Length = 50)]
        public string ParentDeviceName { get; set; } // 所属设备名称

        [SugarColumn(IsNullable = true, ColumnName = "type_id", ColumnDataType = "varchar", Length = 20)]
        public string TypeId { get; set; } // 设备类型编号，关联dict_devicetype的Typeid

        [SugarColumn(IsNullable = true, ColumnName = "type_name", ColumnDataType = "varchar", Length = 50)]
        public string TypeName { get; set; } // 设备类型名称

        [SugarColumn(IsNullable = true, ColumnName = "node_id", ColumnDataType = "varchar", Length = 20)]
        public string NodeId { get; set; } // 点位id

        [SugarColumn(IsNullable = true, ColumnName = "node_describe", ColumnDataType = "varchar", Length = 50)]
        public string NodeDescribe { get; set; } // 点位描述

        [SugarColumn(IsNullable = true, ColumnName = "location", ColumnDataType = "varchar", Length = 200)]
        public string Location { get; set; } // 安装位置

        [SugarColumn(ColumnName = "del_flag")]
        public bool? DelFlag { get; set; } // 逻辑删除字段，0-否 1-是

        [SugarColumn(IsNullable = true, ColumnName = "remarks", ColumnDataType = "varchar", Length = 500)]
        public string Remarks { get; set; } // 备注

        [SugarColumn(ColumnName = "date")]
        public DateTime? Date { get; set; } // 配置日期        
    }
}
