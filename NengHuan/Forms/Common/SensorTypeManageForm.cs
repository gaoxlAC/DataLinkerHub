using NengHuan.Database.MySQL.ModelsManage;
using NengHuan.Database.MySQL.Service;
using NengHuan.Database.SqLite;
using NengHuan.Forms.Common;
using NengHuan.Models;
using NengHuan.Models.Sjcj;
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
    public partial class SensorTypeManageForm : UIForm
    {
        public SensorTypeManageForm()
        {
            InitializeComponent();
        }

        private void F_SensorTypeManage_Load(object sender, EventArgs e)
        {
            new BaseDataDeviceManages().CreateTable();
            this.RefreshData();
        }

        #region 添加传感器类型
        private void btnAddSensorType_Click(object sender, EventArgs e)
        {
            AddOrEditSensorTypeForm f_AddOrEditSensorType = new AddOrEditSensorTypeForm();
            f_AddOrEditSensorType.Text = "添加传感器类型";
            f_AddOrEditSensorType.ShowDialog();
            if (f_AddOrEditSensorType.IsOK)
            {
                BaseDataDevice deviceInfoManage = new BaseDataDevice();
                DictDeviceType deviceTypeManage = new DictDeviceType();
                deviceTypeManage.TypeName = f_AddOrEditSensorType.tBSensorId.Text.Trim();
                deviceInfoManage.DeviceName = f_AddOrEditSensorType.tBSensorName.Text.Trim();
                deviceInfoManage.CreateUser = "管理员";
                new SensorTypeManage().Insert(deviceInfoManage);
                this.RefreshData();
            }
        }
        #endregion

        #region 删除传感器类型
        private void btnDeleteSensorType_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 修改传感器类型
        private void btnEditSensorType_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count != 0 && this.dataGridView1.SelectedRows.Count == 1)
            {
                AddOrEditSensorTypeForm f_AddOrEditSensorType = new AddOrEditSensorTypeForm();
                f_AddOrEditSensorType.Text = "修改传感器类型";
                f_AddOrEditSensorType.tBSensorId.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                f_AddOrEditSensorType.tBSensorName.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                f_AddOrEditSensorType.tBSensorLocation.Text = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                f_AddOrEditSensorType.tBSensorInstallCode.Text = this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                f_AddOrEditSensorType.tBEquipmentSensorName.Text = this.dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                ///f_AddOrEditSensorType.tBSensorType.Text = this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                f_AddOrEditSensorType.ShowDialog();
                if (f_AddOrEditSensorType.IsOK)
                {
                    BaseDataDevice deviceInfoManage = new SensorTypeManage().GetById(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    DictDeviceType deviceTypeManage = new DictDeviceType();
                    //更新类型对应的数据库表名称
                    deviceTypeManage.TypeName = f_AddOrEditSensorType.tBSensorId.Text.Trim();
                    deviceInfoManage.DeviceName = f_AddOrEditSensorType.tBSensorName.Text.Trim();
                    deviceInfoManage.CreateUser = "管理员";
                    new SensorTypeManage().Update(deviceInfoManage);
                    this.RefreshData();
                }
            }

        }
        #endregion

        #region 刷新数据
        public void RefreshData()
        {
         
            dataGridView1.DataSource = new DeviceManageService().ShowDeviceInfos();
            this.dataGridView1.Columns[0].HeaderText = "序号";
            this.dataGridView1.Columns[1].HeaderText = "设备名称";
            this.dataGridView1.Columns[2].HeaderText = "设备类型";
            this.dataGridView1.Columns[3].HeaderText = "节点描述";
            this.dataGridView1.Columns[4].HeaderText = "父设备名称";
            this.dataGridView1.Columns[5].HeaderText = "所属系统名称";
            this.dataGridView1.Columns[6].HeaderText = "安装位置";
            this.dataGridView1.Columns[7].HeaderText = "创建时间";
            this.dataGridView1.Columns[8].HeaderText = "最后更新时间";
        }

        #endregion

        #region 显示选中的行数
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //this.lbSelectedRowNum.Text = string.Format("选中：{0}", this.dataGridView1.SelectedRows.Count);
        }
        #endregion
    }
}
