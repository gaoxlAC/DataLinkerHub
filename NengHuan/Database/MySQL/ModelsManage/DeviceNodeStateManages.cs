using NengHuan.Models.Sjcj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.MySQL.ModelsManage
{
    class DeviceNodeStateManages : DbContext_MySQL<DeviceNodeState>
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
            Db.CodeFirst.InitTables(typeof(DeviceNodeState));
        }
        // 获取所有其他状态点位信息
        public override List<DeviceNodeState> GetList()
        {
            return Db.Queryable<DeviceNodeState>().Where(it => it.DelFlag == false || it.DelFlag == null).OrderBy(it => it.Sid).ToList();
        }
    }
}
