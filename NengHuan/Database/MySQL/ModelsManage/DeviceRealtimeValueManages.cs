using NengHuan.Models.Sjcj;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.MySQL.ModelsManage
{
    class DeviceRealtimeValueManages : DbContext_MySQL<DeviceRealtimeValue>
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
            Db.CodeFirst.InitTables(typeof(DeviceRealtimeValue));
        }

        // 获取实时数据点位信息
        public override List<DeviceRealtimeValue> GetList()
        {
            return Db.Queryable<DeviceRealtimeValue>().Where(it => it.DelFlag == false || it.DelFlag == null).OrderBy(it => it.Sid).ToList();
        }
        
        /// <summary>
        /// 批量插入实时数据信息
        /// </summary>
        /// <param name="deviceRealtimeValues"></param>
        /// <returns></returns>
        public int InsertBatches(List<DeviceRealtimeValue> deviceRealtimeValues)
        {
            int v = 0;
            try
            {
                v = Db.Insertable(deviceRealtimeValues).UseParameter().ExecuteCommand();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"InsertBatches：异常 {ex}");
            }
            return v;
      
        }
        /// <summary>
        /// 批量更新实时数据信息
        /// </summary>
        /// <param name="deviceRealtimeValues"></param>
        /// <returns></returns>
        public int UpdateBatches(List<DeviceRealtimeValue> deviceRealtimeValues)
        {
            return Db.Updateable(deviceRealtimeValues).WhereColumns(it => new { it.Sid }).ExecuteCommand();
        }

        /// <summary>
        /// 清空实时数据信息
        /// </summary>
        /// <param name="deviceRealtimeValues"></param>
        /// <returns></returns>
        public int DeleteBatches(List<DeviceRealtimeValue> deviceRealtimeValues)
        {
            return Db.Deleteable(deviceRealtimeValues).ExecuteCommand();
        }

    }
}
