using NengHuan.Models.Sjcj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.MySQL.ModelsManage
{
    class DeviceRealtimeValueWriteManages : DbContext_MySQL<DeviceRealtimeValueWrite>
    {
        // 获取实时数据写入opc服务器
        public override List<DeviceRealtimeValueWrite> GetList()
        {
            return Db.Queryable<DeviceRealtimeValueWrite>().Where(it => it.DelFlag == false || it.DelFlag == null).OrderBy(it => it.Sid).ToList();
        }
    }
}
