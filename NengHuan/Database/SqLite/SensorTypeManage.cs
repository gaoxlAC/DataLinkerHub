using NengHuan.Models.Sjcj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengHuan.Database.SqLite
{
    class SensorTypeManage : DbContext_Sqlite<BaseDataDevice>
    {
        //*/public bool IsExist()
        //{
        //    try
        //    {
        //        CurrentDb.GetList();
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        //public void CreateTable()
        //{
        //    Db.CodeFirst.InitTables(typeof(DeviceInfoManage));
        //}

        //internal void DeleteById(string id)
        //{
        //    CurrentDb.Delete(it => it.Id == id);
        //}

        //// 获取所有设备信息
        //public override List<DeviceInfoManage> GetList()
        //{
        //    return Db.Queryable<DeviceInfoManage>().OrderBy(it => it.DeviceTypeId).ToList();
        //}

        //public override DeviceInfoManage GetById(string id)
        //{
        //    return Db.Queryable<DeviceInfoManage>().Where(it => it.Id == id).First();
        //}

        //internal DeviceInfoManage GetByName(string DeviceTypeId)
        //{
        //    return Db.Queryable<DeviceInfoManage>().Where(it => it.DeviceTypeId == DeviceTypeId).First();
        //}

        //* internal int GetPageIndex()
   /*      {
             //将目前所有传感器类型查出，按页面id排序
             List<DeviceInfoManage> types = Db.Queryable<DeviceInfoManage>().OrderBy(it => it.pageIndex).ToList();
             //取最大的id+1作为返回值
             List<int> pageIndexs = new List<int>();
             foreach (DeviceInfoManage type in types)
             {
                 pageIndexs.Add((int)type.pageIndex);
             }
             return pageIndexs.Max() + 1;
         }*/

      /*   internal int UpdatePageIndexByTypeName(string type, int pageIndex)
{
    DateTime now = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
    DeviceInfoManage deviceInfoManage = this.GetByName(type);
    deviceInfoManage.pageIndex = pageIndex;
    return Db.Updateable(deviceInfoManage).ExecuteCommand();
}
/// <summary>
/// 重置所有的pageIndex为0
/// </summary>
internal void SetAllPageIndexTo0()
{
    List<DeviceInfoManage> sensorTypes = this.GetList().Where(it => it.pageIndex != 0).ToList();
    foreach (DeviceInfoManage sensorType in sensorTypes)
    {
        sensorType.pageIndex = 0;
        this.Update(sensorType);
    }
}*/
    }
}
