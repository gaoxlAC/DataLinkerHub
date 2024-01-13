using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Models.TestModles
{
    // 使用SqlSugar创建实体类
    // 1.在Nuget中安装SqlSugar
    // 2.在项目中添加引用
    // 3.在项目中添加文件夹Models
    // 4.在Models文件夹中添加类TestModel
    // 连接数据库

    [SugarTable("device")]
    public class TestModel
    {
        public TestModel()
        {
            this.Id = IdHelper.GenerateId(); // 生成雪花id
        }
        [SugarColumn(ColumnName = "id")]
        public string Id { get; set; }

        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }

        [SugarColumn(ColumnName = "brand")]
        public int Brand { get; set; }

        [SugarColumn(ColumnName = "production_date")]
        public DateTime ProductionDate { get; set; }

        [SugarColumn(ColumnName = "price")]
        public decimal Price { get; set; }
    }
}
