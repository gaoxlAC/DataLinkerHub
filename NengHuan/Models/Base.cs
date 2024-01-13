using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Models
{
    /// <summary>
    /// 实体类的基类，每个数据库表中都含有以下字段
    /// </summary>
    public class Base
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "sid")]
        public int Sid { get; set; } // 序号，自增字段

        [SugarColumn(IsNullable = true, DefaultValue = "CURRENT_TIMESTAMP", IsOnlyIgnoreInsert = true,ColumnName = "create_time")]
        public DateTime CreateTime { get; set; } // 创建时间

        [SugarColumn(IsNullable = true, ColumnName = "create_user_id", ColumnDataType = "varchar", Length = 20)]
        public string CreateUserId { get; set; } // 创建人ID

        [SugarColumn(IsNullable = true, ColumnName = "create_user", ColumnDataType = "varchar", Length = 40)]
        public string CreateUser { get; set; } // 创建人姓名

        [SugarColumn(IsNullable = true, ColumnName = "create_ip", ColumnDataType = "varchar", Length = 50)]
        public string CreateIp { get; set; } // 创建IP

        [SugarColumn(IsNullable = true, ColumnName = "modify_user_id", ColumnDataType = "varchar", Length = 20)]
        public string ModifyUserId { get; set; } // 最后更新人工号

        [SugarColumn(IsNullable = true, ColumnName = "modify_user", ColumnDataType = "varchar", Length = 40)]
        public string ModifyUser { get; set; } // 最后更新姓名

        [SugarColumn(IsNullable = true, DefaultValue = "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP", IsOnlyIgnoreInsert = true, ColumnName = "modify_time")]
        public DateTime ModifyTime { get; set; } // 最后更新时间

        [SugarColumn(IsNullable = true, ColumnName = "modify_ip", ColumnDataType = "varchar", Length = 50)]
        public string ModifyIp { get; set; } // 最后更新IP

    }
}
