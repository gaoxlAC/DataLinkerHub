using NengHuan.Database.MySQL.ModelsManage;
using NengHuan.Database.MySQL.Service;
using NengHuan.Database.VO;
using NengHuan.Forms.Common;
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

namespace NengHuan.Forms
{
    public partial class FDeviceInfo : UIForm
    {


        public FDeviceInfo()
        {
            InitializeComponent();


           
        }

      

        // 查询
        private void btn_Inquire_Click(object sender, EventArgs e)
        {
            SensorTypeManageForm sensorTypeManageForm = new SensorTypeManageForm();
            sensorTypeManageForm.ShowDialog();
        }

        private void FDeviceInfo_Load(object sender, EventArgs e)
        {

            // 判断表是否存在，不存在则创建
            if(!new BaseDataDeviceManages().IsExist())
            {
                new BaseDataDeviceManages().CreateTable();
            }
            this.RefreshData();
        }

        #region 刷新数据
        public void RefreshData()
        {

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("设备名称", typeof(string));
            dataTable.Columns.Add("设备类型", typeof(string));
            dataTable.Columns.Add("点位描述", typeof(string));
            dataTable.Columns.Add("父设备名称", typeof(string));
            dataTable.Columns.Add("所属系统名称", typeof(string));
            dataTable.Columns.Add("安装位置", typeof(string));
            dataTable.Columns.Add("创建时间", typeof(string));
            dataTable.Columns.Add("最后更新时间", typeof(string));
            dataGridView1.DataSource = dataTable;

            List<BaseDataDevice> baseDataDevices = new List<BaseDataDevice>();
            baseDataDevices = new BaseDataDeviceManages().GetList();
            foreach(BaseDataDevice device in baseDataDevices)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["设备名称"] = device.DeviceName;
                dataRow["设备类型"] = device.TypeName;
                dataRow["点位描述"] = device.NodeDescribe;
                dataRow["父设备名称"] = device.ParentDeviceName;
                dataRow["所属系统名称"] = device.SystemName;
                dataRow["安装位置"] = device.Location;
                dataRow["创建时间"] = device.CreateTime;
                dataRow["最后更新时间"] = device.ModifyTime;
                dataTable.Rows.Add(dataRow);
            }
           
            //this.dataGridView1.Columns[1].HeaderText = "序号";
            //this.dataGridView1.Columns[2].HeaderText = "设备名称";
            //this.dataGridView1.Columns[3].HeaderText = "设备类型";
            //this.dataGridView1.Columns[4].HeaderText = "节点描述";
            //this.dataGridView1.Columns[5].HeaderText = "父设备名称";
            //this.dataGridView1.Columns[6].HeaderText = "所属系统名称";
            //this.dataGridView1.Columns[7].HeaderText = "安装位置";
            //this.dataGridView1.Columns[8].HeaderText = "创建时间";
            //this.dataGridView1.Columns[9].HeaderText = "最后更新时间";
            //调整列宽，以适合该列中的所有单元格的内容，包括标题单元格。
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        #endregion

        private void uiButton1_Click(object sender, EventArgs e)
        {
            Type_SensorListForm type_SensorListForm = new Type_SensorListForm();
            type_SensorListForm.Show();
        }
    }
}
