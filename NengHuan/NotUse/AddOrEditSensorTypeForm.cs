using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NengHuan.Forms.Common
{
    public partial class AddOrEditSensorTypeForm : UIEditForm
    {
        public AddOrEditSensorTypeForm()
        {
            InitializeComponent();
        }

        private void F_AddOrEditSensorType_Load(object sender, EventArgs e)
        {

        }

        protected override bool CheckData()
        {
            return CheckEmpty(tBSensorId, "设备编号不能为空！") && CheckEmpty(tBSensorName, "设备名称不能为空！") && CheckEmpty(tBSensorLocation, "设备安装位置不能为空！") && CheckEmpty(tBSensorInstallCode, "设备安装代码不能为空！") && CheckEmpty(tBEquipmentSensorName, "所属设备名称不能为空！") && CheckEmpty(tBSensorType, "设备类型名称不能为空！");
        }
    }
}
