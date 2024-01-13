using NengHuan.Database.MySQL.ModelsManage;
using NengHuan.Models.Sjcj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NengHuan.Database.MySQL.Service
{
    /// <summary>
    /// 用于对节点这一层级进行操作，通过读到节点的入库
    /// </summary>
    public class NodeManageService
    {
        /// <summary>
        /// 添加单个点位信息
        /// </summary>
        /// <param name="baseDataNode"></param>
        public string InsertNodeInfo(BaseDataNode baseDataNode)
        {
            if (baseDataNode == null)  return "添加点位信息为空"; 
            // 从数据库中查询是否存在该设备名称：点位描述
            List<BaseDataNode> baseDataNodes = new BaseDataNodeManages().GetList();
            foreach (BaseDataNode node in baseDataNodes)
            {
                if(node.DeviceName == baseDataNode.DeviceName && node.NodeDescribe == baseDataNode.NodeDescribe)
                {
                    return "已存在该设备名称和点位描述";
                }
            }
            // 再检查该设备名称是否存在BaseDataDevice中
            List<BaseDataDevice> baseDataDevices = new BaseDataDeviceManages().GetList();
            // 在baseDataDevices中到该设备名称的记录
            BaseDataDevice baseDataDevice = baseDataDevices.Where(d => d.DeviceName == baseDataNode.DeviceName).FirstOrDefault();
            if (baseDataDevice == null)
            {
                return "不存在设备名称:"+baseDataNode.DeviceName+"\n请添加";
            }
            else
            {
                baseDataNode.DeviceId = baseDataDevice.DeviceId;
            }

            // 没有则插入该点位信息
            BaseDataNodeManages baseDataNodeManages = new BaseDataNodeManages();
            return baseDataNodeManages.InsertNodeInfo(baseDataNode);
        }
    }
}
