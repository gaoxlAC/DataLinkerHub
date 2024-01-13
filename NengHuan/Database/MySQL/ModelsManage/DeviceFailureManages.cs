using NengHuan.Models.Sjcj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.MySQL.ModelsManage
{
    class DeviceFailureManages : DbContext_MySQL<DeviceFailure>
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
            Db.CodeFirst.InitTables(typeof(DeviceFailure));
        }

        // 获取所有故障点位信息
        public override List<DeviceFailure> GetList()
        {
            return Db.Queryable<DeviceFailure>().Where(it => it.DelFlag == false || it.DelFlag == null).OrderBy(it => it.Sid).ToList();
        }
    }
}
