using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Models.System
{
    [SugarTable("database_conn_info", TableDescription = "数据采集系统信息")]//数据库表名称
    class Sys : Base
    {
        [SugarColumn(ColumnName = "db_id", ColumnDataType = "varchar", Length = 20)]
        public string DbId { get; set; } // 数据库配置信息编号

        [SugarColumn(ColumnName = "db_server", ColumnDataType = "varchar", Length = 255)]
        public string DbServer { get; set; } // 数据库的主机名

        [SugarColumn(ColumnName = "db_port", ColumnDataType = "varchar", Length = 255)]
        public string DbPort { get; set; } // 数据库端口号

        [SugarColumn(ColumnName = "db_name", ColumnDataType = "varchar", Length = 255)]
        public string DbName { get; set; } // 数据库名称

        [SugarColumn(ColumnName = "db_username", ColumnDataType = "varchar", Length = 255)]
        public string DbUsername { get; set; } // 数据库用户名

        [SugarColumn(ColumnName = "db_password", ColumnDataType = "varchar", Length = 255)]
        public string DbPassword { get; set; } // 数据库密码

        [SugarColumn(ColumnName = "del_flag")]
        public bool DelFlag { get; set; } // 逻辑删除，1表示删除，0表示未删除，默认为0

        public Sys()
        {
            this.DbId = Guid.NewGuid().ToString("N");
        }
    }
}
