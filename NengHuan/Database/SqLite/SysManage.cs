using NengHuan.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NengHuan.Database.SqLite
{
    class SysManage : DbContext_Sqlite<Sys>
    {

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

        public void CreateTable()
        {

            //创建系统信息表
            Db.CodeFirst.InitTables(typeof(Sys));

            //如果sys表是空的插入一条记录（初始化系统信息）
            if (this.GetSysInfo().Count == 0)
            {
                Sys sys = new Sys();
                sys.CreateUser = "管理员";
                sys.CreateTime = DateTime.Now;
                //默认没有使用任何通信协议
                this.Insert(sys);
            }
        }
        /// <summary>
        /// 获取全部系统信息（其实只有一条）
        /// </summary>
        /// <returns></returns>
        public List<Sys> GetSysInfo()
        {
            return CurrentDb.GetList();
        }
        /// <summary>
        /// 更新系统信息
        /// </summary>
        /// <param name="protocol"></param>
        /// <returns></returns>
        public bool UpdateSysInfo(Sys sys)
        {
            return CurrentDb.Update(sys);
        }

    }
}
