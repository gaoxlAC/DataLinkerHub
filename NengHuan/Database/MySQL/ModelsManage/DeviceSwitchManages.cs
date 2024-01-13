using NengHuan.Models.Sjcj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.MySQL.ModelsManage
{
    class DeviceSwitchManages : DbContext_MySQL<DeviceSwitch>
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
            Db.CodeFirst.InitTables(typeof(DeviceSwitch));
        }
        // 获取所有开关点位信息
        public override List<DeviceSwitch> GetList()
        {
            return Db.Queryable<DeviceSwitch>().Where(it => it.DelFlag == false || it.DelFlag == null).OrderBy(it => it.Sid).ToList();
        }
    }
}
