using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Models.Sjcj
{
    [SugarTable("base_data_node")]
    public class BaseDataNode :Base
    {
        [SugarColumn(IsNullable = true, ColumnName = "node_id", ColumnDataType = "varchar", Length = 20)]
        public string NodeId { get; set; } // 点位id

        [SugarColumn(IsNullable = true, ColumnName = "node_describe", ColumnDataType = "varchar", Length = 200)]
        public string NodeDescribe { get; set; } // 点位描述

        [SugarColumn(IsNullable = true, ColumnName = "device_id", ColumnDataType = "varchar", Length = 20)]
        public string DeviceId { get; set; } // 被测的设备编号，关联base_data_device中的Deviceid

        [SugarColumn(IsNullable = true, ColumnName = "device_name", ColumnDataType = "varchar", Length = 50)]
        public string DeviceName { get; set; } // 设备名称

        [SugarColumn(IsNullable = true, ColumnName = "protocol_id", ColumnDataType = "varchar", Length = 20)]
        public string ProtocolId { get; set; } // 协议Id

        [SugarColumn(IsNullable = true, ColumnName = "protocol_name", ColumnDataType = "varchar", Length = 50)]
        public string ProtocolName { get; set; } // 协议名称

        [SugarColumn(IsNullable = true, ColumnName = "data_type", ColumnDataType = "varchar", Length = 20)]
        public string DataType { get; set; } // 数据类型

        [SugarColumn(ColumnName = "read_write")]
        public int? ReadWrite { get; set; } // 0:读,1:写,2:读写

        [SugarColumn(ColumnName = "ratio")]
        public decimal? Ratio { get; set; } // 系数

        [SugarColumn(ColumnName = "is_write")]
        public bool? IsWrite { get; set; } // 是否存储，0-否 1-是

        [SugarColumn(IsNullable = true, ColumnName = "write_frequency", ColumnDataType = "varchar", Length = 50)]
        public string WriteFrequency { get; set; } // 存储频率

        [SugarColumn(ColumnName = "scan_frequency")]
        public int? ScanFrequency { get; set; } // 读取频率

        [SugarColumn(ColumnName = "calibration")]
        public decimal? Calibration { get; set; } // 参数校准

        [SugarColumn(IsNullable = true, ColumnName = "range", ColumnDataType = "varchar", Length = 200)]
        public string Range { get; set; } // 量程，如-5_+5

        [SugarColumn(IsNullable = true, ColumnName = "unit", ColumnDataType = "varchar", Length = 200)]
        public string Unit { get; set; } // 计量单位

        [SugarColumn(IsNullable = true, ColumnName = "remarks", ColumnDataType = "varchar", Length = 500)]
        public string Remarks { get; set; } // 备注

        [SugarColumn(ColumnName = "del_flag")]
        public bool? DelFlag { get; set; } // 逻辑删除字段，0-否 1-是
    }
}
