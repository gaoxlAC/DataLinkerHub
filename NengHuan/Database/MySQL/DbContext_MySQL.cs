using NengHuan.Database.SqLite;
using NengHuan.Forms.Common;
using NengHuan.Models.System;
using NengHuan.UI;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NengHuan.Database.MySQL
{
    class DbContext_MySQL<T> where T : class, new()//泛型约束：是类，且可以new
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(DbContext_MySQL<T>));
        public SetupForm setupForm = FMain.setupForm;
        //public string ConnStr = "server=mysql.coderwjy.icu;port=9306;user id=root;password=woaimysql;database=sjcj;charset=utf8";
        /// <summary>
        /// 构造方法
        /// </summary>
        public DbContext_MySQL()
        {
            //Console.WriteLine($"数据库连接字符串为：{SetupForm.conStr}");
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                //ConnectionString = ConnStr,
                ConnectionString = SetupForm.conStr,
                DbType = DbType.MySql,
                InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息，这是一个自定义特性，用于注释字段
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样
            });

            //调式代码 用来打印SQL，开发中可以删掉这个代码
            //Db.Aop.OnLogExecuting = (sql, pars) =>
            //{
            //    //this.Logger.Info(string.Format("\r\nSqlSugar:\r\n{0}\r\n{1}", sql, Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value))));

            //    Console.WriteLine("SqlSugar: ");
            //    Console.WriteLine(sql + "\r\n" +
            //        Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            //    Console.WriteLine();
            //};

        }
        //注意：不能写成静态的
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来处理T表的常用操作
        public virtual T GetById(string id)
        {
            return CurrentDb.GetById(id);
        }
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetList()
        {
            return CurrentDb.GetList();
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(dynamic id)
        {
            return CurrentDb.Delete(id);
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual bool Insert(T obj)
        {
            return CurrentDb.Insert(obj);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public virtual bool InsertRange(T[] objs)
        {
            return CurrentDb.InsertRange(objs);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Update(T obj)
        {
            return CurrentDb.Update(obj);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool UpdateRange(T[] objs)
        {
            return CurrentDb.UpdateRange(objs);
        }

    }
}
