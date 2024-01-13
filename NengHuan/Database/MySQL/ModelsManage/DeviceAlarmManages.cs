using NengHuan.Models.Sjcj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.MySQL.ModelsManage
{
    class DeviceAlarmManages : DbContext_MySQL<DeviceAlarm>
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
            Db.CodeFirst.InitTables(typeof(DeviceAlarm));
        }

        // 获取所有预警点位信息
        public override List<DeviceAlarm> GetList()
        {
            return Db.Queryable<DeviceAlarm>().Where(it => it.DelFlag == false || it.DelFlag == null).OrderBy(it => it.Sid).ToList();
        }
    }
}
