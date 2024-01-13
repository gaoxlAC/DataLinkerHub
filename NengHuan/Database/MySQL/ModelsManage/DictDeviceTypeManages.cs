using NengHuan.Models.Sjcj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.MySQL.ModelsManage
{
    class DictDeviceTypeManages : DbContext_MySQL<DictDeviceType>
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
            Db.CodeFirst.InitTables(typeof(DictDeviceType));
        }
        // 通过id删除表
        internal void DeleteById(string id)
        {
            CurrentDb.Delete(it => it.TypeId == id);
        }

        // 获取所有设备类型
        public override List<DictDeviceType> GetList()
        {
            return Db.Queryable<DictDeviceType>().OrderBy(it => it.Sid).ToList();
        }

       // 获取所有的设备类型名称
       public List<string> GetAllDeviceTypes()
        {
            List<string> types = Db.Queryable<DictDeviceType>().Select(it => it.TypeName).Distinct().ToList();
            return types;
        }


        /// <summary>
        /// 重置所有的pageIndex为0
        /// </summary>
        //internal void SetAllPageIndexTo0()
        //{
        //    List<BaseDataDevice> sensorTypes = this.GetList().Where(it => it.Sid != 0).ToList();
        //    foreach (BaseDataDevice sensorType in sensorTypes)
        //    {
        //        //sensorType.TypeId = 0;
        //        sensorType.Sid = 0;
        //        this.Update(sensorType);
        //    }
        //}
    }
}
