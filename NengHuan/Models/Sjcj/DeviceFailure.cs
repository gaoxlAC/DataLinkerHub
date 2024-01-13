using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Models.Sjcj
{
    [SugarTable("device_failure")]
    public class DeviceFailure : Base
    {
        // 定义实体类，与数据库表对应
        [SugarColumn(IsNullable = true, ColumnName = "device_id", ColumnDataType = "varchar", Length = 20)]
        public string DeviceId { get; set; } // 设备编号

        [SugarColumn(IsNullable = true, ColumnName = "device_name", ColumnDataType = "varchar", Length = 50)]
        public string DeviceName { get; set; } // 设备名称

        [SugarColumn(IsNullable = true, ColumnName = "node_id", ColumnDataType = "varchar", Length = 20)]
        public string NodeId { get; set; } // 点位id

        [SugarColumn(IsNullable = true, ColumnName = "node_describe", ColumnDataType = "varchar", Length = 200)]
        public string NodeDescribe { get; set; } // 点位描述

        [SugarColumn(IsNullable = true, ColumnName = "failure_value", ColumnDataType = "varchar", Length = 2)]
        public string FailureValue { get; set; } // 故障值

        [SugarColumn(IsNullable = true, ColumnName = "type", ColumnDataType = "varchar", Length = 10)]
        public string Type { get; set; } // 读写类型

        [SugarColumn(ColumnName = "collect_time", ColumnDataType = "datetime")]
        public DateTime? CollectTime { get; set; } // 采集时间

        [SugarColumn(IsNullable = true, ColumnName = "remarks", ColumnDataType = "varchar", Length = 200)]
        public string Remarks { get; set; } // 备注

        [SugarColumn(ColumnName = "del_flag")]
        public bool? DelFlag { get; set; } // 逻辑删除字段，0-否 1-是
    }
}
