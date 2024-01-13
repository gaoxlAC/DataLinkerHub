using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Models.Sjcj
{
    [SugarTable("dict_devicetype")]
    public class DictDeviceType : Base
    {
        
        [SugarColumn(IsNullable = true, ColumnName = "type_id", ColumnDataType = "varchar", Length = 50)]
        public string TypeId { get; set; } // 设备类型编号

        [SugarColumn(IsNullable = true, ColumnName = "type_name", ColumnDataType = "varchar", Length = 50)]
        public string TypeName { get; set; } // 设备类型名称

        [SugarColumn(IsNullable = true, ColumnName = "remarks", ColumnDataType = "varchar", Length = 500)]
        public string Remarks { get; set; } // 备注

        // TypeId使用雪花算法
        public DictDeviceType()
        {
            this.TypeId = IdHelper.GenerateId().ToString();
        }


    }
}
