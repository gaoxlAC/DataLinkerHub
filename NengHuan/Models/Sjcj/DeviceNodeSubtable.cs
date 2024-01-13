using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Models.Sjcj
{
    // 定义设备节点分表实体类
    [SugarTable("device_node_subtable")]
    public class DeviceNodeSubtable : Base
    {
        [SugarColumn(IsNullable = true, ColumnName = "subtable_name", ColumnDataType = "varchar", Length = 50)]
        public string SubtableName { get; set; } // 子表名

        [SugarColumn(ColumnName = "storage_date", ColumnDataType = "datetime")]
        public DateTime? StorageDate { get; set; }  // 存储时间

        [SugarColumn(ColumnName = "del_flag")]
        public bool? DelFlag { get; set; } // 逻辑删除字段，0-否 1-是

        [SugarColumn(IsNullable = true, ColumnName = "remarks", ColumnDataType = "varchar", Length = 200)]
        public string Remarks { get; set; } // 备注
    }
}
