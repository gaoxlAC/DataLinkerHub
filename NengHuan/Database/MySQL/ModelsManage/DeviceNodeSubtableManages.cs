using NengHuan.Models.Sjcj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.MySQL.ModelsManage
{
    class DeviceNodeSubtableManages : DbContext_MySQL<DeviceNodeSubtable>
    {
        // 判断表是否存在
        public bool IsExist()
        {
            try
            {
                CurrentDb.GetList();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        // 创建表
        public void CreateTable()
        {
            Db.CodeFirst.InitTables(typeof(DeviceNodeSubtable));
        }
        // 获取所有历史数据表信息
        public override List<DeviceNodeSubtable> GetList()
        {
            return Db.Queryable<DeviceNodeSubtable>().Where(it => it.DelFlag == false || it.DelFlag == null).OrderBy(it => it.Sid).ToList();
        }
    }
}
