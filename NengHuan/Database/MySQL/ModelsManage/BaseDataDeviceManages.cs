using NengHuan.Models.Sjcj;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.MySQL.ModelsManage
{
    // 对设备的一些基本操作
    class BaseDataDeviceManages : DbContext_MySQL<BaseDataDevice>
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
            Db.CodeFirst.InitTables(typeof(BaseDataDevice));
        }

        #region 根据条件获取设备信息
        /// <summary>
        /// 获取所有设备信息
        /// </summary>
        /// <returns></returns>
        public override List<BaseDataDevice> GetList()
        {
            return Db.Queryable<BaseDataDevice>().Where(it => it.DelFlag == false || it.DelFlag == null).OrderBy(it => it.Sid).ToList();
        }

        /// <summary>
        /// 通过id获取设备信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override BaseDataDevice GetById(string id)
        {
            return Db.Queryable<BaseDataDevice>().Where(it => it.DelFlag == false || it.DelFlag == null).Where(it => it.DeviceId == id).First();
        }

        /// <summary>
        /// 通过设备类型id获取设备信息
        /// </summary>
        /// <param name="DeviceTypeId"></param>
        /// <returns></returns>
        internal BaseDataDevice GetByName(string DeviceTypeId)
        {
            return Db.Queryable<BaseDataDevice>().Where(it => it.DelFlag == false || it.DelFlag == null).Where(it => it.TypeId == DeviceTypeId).First();
        }

        /// <summary>
        /// 获取所有未删除的设备名称（去重）
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllDeviceNameExist()
        {
            var list = Db.Queryable<BaseDataDevice>().Where(it => it.DelFlag == false || it.DelFlag == null).Distinct().Select(it => it.DeviceName).ToList();
            return list;
        }

        #endregion
    }
}
