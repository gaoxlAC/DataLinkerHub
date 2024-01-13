using SqlSugar.DistributedSystem.Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Models
{
    // 生成id的帮助类
    public class IdHelper
    {
        private static IdWorker _idWorker = new IdWorker(2, 2);

        // 通过雪花算法生成id
        public static string GenerateId()
        {
            return _idWorker.NextId().ToString();
        }
    }
}
