using SqlSugar;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Data;
using System.Windows.Forms;

namespace NengHuan.Database
{
    // Mysql数据库连接测试类，用于测试数据库是否连接成功
    public class MysqlConn
    {
        // 从配置文件中读取数据库连接字符串
        private string connectionString;
        
        // 返回数据库连接对象
        public SqlSugarClient GetConnection()
        {
            // 从配置文件中读取数据库连接字符串，异常判断
            try
            {
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("数据库连接失败: " + ex.Message);
            }
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = SqlSugar.DbType.MySql,
                IsAutoCloseConnection = false
            });
            return db;
        }

        // 测试数据库是否连接成功
        public bool TestConnection()
        {
            // 指定配置文件的位置
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = "Database\\DbConnection.config";

            // 打开配置文件
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            // 从配置文件中读取数据库连接字符串，异常判断
            try
            {
                connectionString = config.ConnectionStrings.ConnectionStrings["MySqlConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = SqlSugar.DbType.MySql,
                IsAutoCloseConnection = true
            });
            Console.WriteLine("这一步能通过");

            // 创建ILog对象
            ILog log = LogManager.GetLogger("SqlSugarLogger");

            // 注册OnLogExecuting事件
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                // 打印sql语句和参数
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine("");
            };

            try
            {
                var result = db.Ado.GetDataTable("select * from device");

                // 打印结果
                // 遍历查询结果的行集合
                foreach (DataRow row in result.Rows)
                {
                    // 打印每一行的内容
                    Console.WriteLine(row["id"] + "\t" + row["name"] + "\t" + row["brand"] + "\t" + row["production_date"] + "\t" + row["price"]);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
