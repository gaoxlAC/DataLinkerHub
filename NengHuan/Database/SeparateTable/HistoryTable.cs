using Mysqlx.Crud;
using NengHuan.Database.MySQL;
using NengHuan.Models.Sjcj;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NengHuan.Database.SeparateTable
{
    /// <summary>
    /// 实时数据分表类
    /// </summary>
    class HistoryTable : DbContext_MySQL<DeviceRealtimeValue>
    {

        /// <summary>
        /// 判断子表名是否存在
        /// </summary>
        /// <param name="tableName">子表名</param>
        /// <returns></returns>
        public bool IsExist(string tableName)
        {
            // 先检查子表名是否存在于数据库中
            string actualTableName = Db.Ado.GetString($"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'");
            bool tableExists = !string.IsNullOrEmpty(actualTableName);
            Console.WriteLine($"{tableName}是否已存在：{tableExists}");
            return tableExists;
        }

        /// <summary>
        /// 动态创建当前系统日期的历史数据表
        /// </summary>
        public void CreateHistoryTable(DateTime storageDate, string subtableName)
        {
            //  按照指定的表名来创建表
            Db.CodeFirst.As<SplitSubtableValue>(subtableName).InitTables<SplitSubtableValue>();

            //// 再判断主表中是否存在
            //List<DeviceNodeSubtable> deviceNodeSubtables = Db.Queryable<DeviceNodeSubtable>().Where(it => it.SubtableName == subtableName && it.DelFlag == false).ToList();

            //// 若主表中存在，则将这些记录删除（设置逻辑删除位）
            //if (deviceNodeSubtables.Count > 0)
            //{
            //    List<DeviceNodeSubtable> logicalDeleteds = new List<DeviceNodeSubtable>();
            //    Console.WriteLine($"子表名{subtableName}已存在");
            //    foreach (DeviceNodeSubtable logicalDeleted in deviceNodeSubtables)
            //    {
            //        logicalDeleted.DelFlag = true;
            //        logicalDeleteds.Add(logicalDeleted);
            //    }
            //    int delRes = Db.Updateable(logicalDeleteds).ExecuteCommand();
            //    Console.WriteLine($"成功逻辑删除了{delRes}条记录");
            //}


            // 将子表名和存储时间插入到DeviceNodeSubtable中
            DeviceNodeSubtable deviceNodeSubtable = new DeviceNodeSubtable
            {
                // 将历史数据表的信息插入到主表中
                SubtableName = subtableName,
                StorageDate = storageDate,
                DelFlag = false,
                Remarks = "历史数据表" + storageDate.ToString()
            };
            int res = Db.Insertable(deviceNodeSubtable).ExecuteCommand();
            if (res <= 0)
            {
                Console.WriteLine($"子表{subtableName}未插入成功");
                return;
            }
            Console.WriteLine($"主表成功插入了{subtableName}{res}条记录");
        }

        /// <summary>
        /// 插入数据到历史表
        /// </summary>
        /// <param name="deviceRealtimeValues">插入的实时数据</param>
        /// <param name="storageDate">插入子表的存储日期</param>
        /// <param name="subtableName">子表名</param>
        /// <returns></returns>
        public bool InsertDataToHistoryTable(List<DeviceRealtimeValue> deviceRealtimeValues, DateTime storageDate, string subtableName)
        {
            // 再插入实时数据
            // 实时数据为空，则返回false
            if (deviceRealtimeValues.Count <= 0) return false;
            try
            {
                // 将实时数据存储到历史数据实体类中
                List<SplitSubtableValue> splitSubtableValues = new List<SplitSubtableValue>();
                foreach (DeviceRealtimeValue realTimeValue in deviceRealtimeValues)
                {
                    SplitSubtableValue splitSubtableValue = new SplitSubtableValue();
                    splitSubtableValue.Passage = realTimeValue.Passage;
                    splitSubtableValue.DeviceName = realTimeValue.DeviceName;
                    splitSubtableValue.NodeDescribe = realTimeValue.NodeDescribe;
                    splitSubtableValue.Value = realTimeValue.Value;
                    splitSubtableValue.CollectTime = realTimeValue.CollectTime;
                    splitSubtableValue.State = realTimeValue.State;
                    splitSubtableValues.Add(splitSubtableValue);
                }
                // 插入到指定子表中
                int res = Db.Storageable(splitSubtableValues).As(subtableName).ExecuteCommand();
                Console.WriteLine($"插入的数据的行数：{res}");
            }
            catch (Exception e)
            {
                MessageBox.Show("历史数据插入失败" + e.Message);

            }
            return true;
        }
    }
}
