using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Models.Sjcj
{ 
    public class SplitSubtableValue : Base
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "sid")]
        public int Sid { get; set; } // 序号，自增字段

        [SugarColumn(IsNullable = true, ColumnName = "passage", ColumnDataType = "varchar", Length = 20)]
        public string Passage { get; set; } // 序号，自增字段

        [SugarColumn(IsNullable=true, ColumnName = "node_id", ColumnDataType = "varchar", Length = 20)]
        public string NodeId { get; set; } // 点位id

        [SugarColumn(IsNullable = true, ColumnName = "node_describe", ColumnDataType = "varchar", Length = 200)]
        public string NodeDescribe { get; set; } // 点位描述

        [SugarColumn(IsNullable = true, ColumnName = "device_type_id", ColumnDataType = "varchar", Length = 20)]
        public string DeviceTypeId { get; set; } // 设备类型id

        [SugarColumn(IsNullable = true, ColumnName = "device_type_name", ColumnDataType = "varchar", Length = 50)]
        public string DeviceTypeName { get; set; } // 设备类型名称

        [SugarColumn(IsNullable = true, ColumnName = "device_id", ColumnDataType = "varchar", Length = 20)]
        public string DeviceId { get; set; } // 设备编号

        [SugarColumn(IsNullable = true, ColumnName = "device_name", ColumnDataType = "varchar", Length = 50)]
        public string DeviceName { get; set; } // 设备名称

        [SugarColumn(IsNullable = true, ColumnName = "value", ColumnDataType = "varchar", Length = 50)]
        public string Value { get; set; } // 信号值

        [SugarColumn(IsNullable = true, ColumnName = "value_type", ColumnDataType = "varchar", Length = 50)]
        public string ValueType { get; set; } // 信号值属性

        [SugarColumn(IsNullable = true, ColumnName = "collect_time")]
        public DateTime? CollectTime { get; set; } // 采集时间

        [SugarColumn(IsNullable = true, ColumnName = "state")]
        public bool? State { get; set; }  // 是否有效，0-无效，1-有效

        [SugarColumn(IsNullable = true, ColumnName = "del_flag")]
        public bool DelFlag { get; set; }  // 逻辑删除字段，0-否，1-是

        [SugarColumn(IsNullable = true, ColumnName = "remarks", ColumnDataType = "varchar", Length = 500)]
        public string Remarks { get; set; } // 备注
    }
}
