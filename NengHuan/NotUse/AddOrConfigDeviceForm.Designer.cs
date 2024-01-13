namespace NengHuan.Forms.Common
{
    partial class AddOrConfigDeviceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiLabel_NodeDescribe = new Sunny.UI.UILabel();
            this.uiGroupBox4 = new Sunny.UI.UIGroupBox();
            this.uiComboBox_ReadOrWrite = new Sunny.UI.UIComboBox();
            this.uiTextBox_RangeHigh = new Sunny.UI.UITextBox();
            this.uiComboBox_DataType = new Sunny.UI.UIComboBox();
            this.uiLabel_DataType = new Sunny.UI.UILabel();
            this.uiTextBox_RangeLow = new Sunny.UI.UITextBox();
            this.uiLabel__Range = new Sunny.UI.UILabel();
            this.uiLabel_ReadOrWrite = new Sunny.UI.UILabel();
            this.uiLabel_To = new Sunny.UI.UILabel();
            this.uiComboBox_Unit = new Sunny.UI.UIComboBox();
            this.uiTextBox_DeviceName = new Sunny.UI.UITextBox();
            this.uiGroupBox_AcquisitionParams = new Sunny.UI.UIGroupBox();
            this.uiLabel_WriteFrequency = new Sunny.UI.UILabel();
            this.uiComboBox_ReadFrequency = new Sunny.UI.UITextBox();
            this.uiTextBox_Calibration = new Sunny.UI.UITextBox();
            this.uiComboBox_ReadFrequencyUnit = new Sunny.UI.UIComboBox();
            this.uiLabel_Calibration = new Sunny.UI.UILabel();
            this.uiComboBox_IsWrite = new Sunny.UI.UIComboBox();
            this.uiTextBox_Ratio = new Sunny.UI.UITextBox();
            this.uiComboBox_WriteFrequencyUnit = new Sunny.UI.UIComboBox();
            this.uiLabel_ReadFrequency = new Sunny.UI.UILabel();
            this.uiTextBox_WriteFrequency = new Sunny.UI.UITextBox();
            this.uiLabel_IsWrite = new Sunny.UI.UILabel();
            this.uiLabel_Ratio = new Sunny.UI.UILabel();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.uiComboBox_Protocol = new Sunny.UI.UIComboBox();
            this.uiLabel_Protocol = new Sunny.UI.UILabel();
            this.uiLabel_DeviceName = new Sunny.UI.UILabel();
            this.uiComboBox_NodeDescribe = new Sunny.UI.UITextBox();
            this.pnlBtm.SuspendLayout();
            this.uiGroupBox4.SuspendLayout();
            this.uiGroupBox_AcquisitionParams.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 645);
            this.pnlBtm.Size = new System.Drawing.Size(625, 55);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(497, 12);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(382, 12);
            // 
            // uiLabel_NodeDescribe
            // 
            this.uiLabel_NodeDescribe.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel_NodeDescribe.Location = new System.Drawing.Point(18, 46);
            this.uiLabel_NodeDescribe.Name = "uiLabel_NodeDescribe";
            this.uiLabel_NodeDescribe.Size = new System.Drawing.Size(143, 34);
            this.uiLabel_NodeDescribe.TabIndex = 6;
            this.uiLabel_NodeDescribe.Text = "点位描述：";
            this.uiLabel_NodeDescribe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.Controls.Add(this.uiComboBox_ReadOrWrite);
            this.uiGroupBox4.Controls.Add(this.uiTextBox_RangeHigh);
            this.uiGroupBox4.Controls.Add(this.uiComboBox_DataType);
            this.uiGroupBox4.Controls.Add(this.uiLabel_DataType);
            this.uiGroupBox4.Controls.Add(this.uiTextBox_RangeLow);
            this.uiGroupBox4.Controls.Add(this.uiLabel__Range);
            this.uiGroupBox4.Controls.Add(this.uiLabel_ReadOrWrite);
            this.uiGroupBox4.Controls.Add(this.uiLabel_To);
            this.uiGroupBox4.Controls.Add(this.uiComboBox_Unit);
            this.uiGroupBox4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox4.Location = new System.Drawing.Point(10, 26);
            this.uiGroupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox4.Size = new System.Drawing.Size(541, 149);
            this.uiGroupBox4.TabIndex = 0;
            this.uiGroupBox4.Text = "基本信息";
            this.uiGroupBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox4.TitleAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uiComboBox_ReadOrWrite
            // 
            this.uiComboBox_ReadOrWrite.DataSource = null;
            this.uiComboBox_ReadOrWrite.FillColor = System.Drawing.Color.White;
            this.uiComboBox_ReadOrWrite.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox_ReadOrWrite.Items.AddRange(new object[] {
            "读",
            "写",
            "读/写"});
            this.uiComboBox_ReadOrWrite.Location = new System.Drawing.Point(404, 97);
            this.uiComboBox_ReadOrWrite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_ReadOrWrite.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_ReadOrWrite.Name = "uiComboBox_ReadOrWrite";
            this.uiComboBox_ReadOrWrite.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_ReadOrWrite.Size = new System.Drawing.Size(101, 39);
            this.uiComboBox_ReadOrWrite.TabIndex = 25;
            this.uiComboBox_ReadOrWrite.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_ReadOrWrite.Watermark = "";
            // 
            // uiTextBox_RangeHigh
            // 
            this.uiTextBox_RangeHigh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_RangeHigh.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTextBox_RangeHigh.Location = new System.Drawing.Point(292, 37);
            this.uiTextBox_RangeHigh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_RangeHigh.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox_RangeHigh.Name = "uiTextBox_RangeHigh";
            this.uiTextBox_RangeHigh.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_RangeHigh.ShowText = false;
            this.uiTextBox_RangeHigh.Size = new System.Drawing.Size(90, 39);
            this.uiTextBox_RangeHigh.TabIndex = 2;
            this.uiTextBox_RangeHigh.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_RangeHigh.Watermark = "";
            // 
            // uiComboBox_DataType
            // 
            this.uiComboBox_DataType.DataSource = null;
            this.uiComboBox_DataType.FillColor = System.Drawing.Color.White;
            this.uiComboBox_DataType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox_DataType.Items.AddRange(new object[] {
            "int",
            "float",
            "boolean",
            "double"});
            this.uiComboBox_DataType.Location = new System.Drawing.Point(134, 97);
            this.uiComboBox_DataType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_DataType.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_DataType.Name = "uiComboBox_DataType";
            this.uiComboBox_DataType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_DataType.Size = new System.Drawing.Size(92, 39);
            this.uiComboBox_DataType.TabIndex = 6;
            this.uiComboBox_DataType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_DataType.Watermark = "";
            // 
            // uiLabel_DataType
            // 
            this.uiLabel_DataType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel_DataType.Location = new System.Drawing.Point(7, 94);
            this.uiLabel_DataType.Name = "uiLabel_DataType";
            this.uiLabel_DataType.Size = new System.Drawing.Size(136, 42);
            this.uiLabel_DataType.TabIndex = 0;
            this.uiLabel_DataType.Text = "数据类型：";
            this.uiLabel_DataType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox_RangeLow
            // 
            this.uiTextBox_RangeLow.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_RangeLow.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTextBox_RangeLow.Location = new System.Drawing.Point(133, 35);
            this.uiTextBox_RangeLow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_RangeLow.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox_RangeLow.Name = "uiTextBox_RangeLow";
            this.uiTextBox_RangeLow.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_RangeLow.ShowText = false;
            this.uiTextBox_RangeLow.Size = new System.Drawing.Size(90, 39);
            this.uiTextBox_RangeLow.TabIndex = 1;
            this.uiTextBox_RangeLow.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_RangeLow.Watermark = "";
            // 
            // uiLabel__Range
            // 
            this.uiLabel__Range.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel__Range.Location = new System.Drawing.Point(15, 35);
            this.uiLabel__Range.Name = "uiLabel__Range";
            this.uiLabel__Range.Size = new System.Drawing.Size(108, 41);
            this.uiLabel__Range.TabIndex = 22;
            this.uiLabel__Range.Text = "量   程：";
            this.uiLabel__Range.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel_ReadOrWrite
            // 
            this.uiLabel_ReadOrWrite.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel_ReadOrWrite.Location = new System.Drawing.Point(286, 92);
            this.uiLabel_ReadOrWrite.Name = "uiLabel_ReadOrWrite";
            this.uiLabel_ReadOrWrite.Size = new System.Drawing.Size(108, 46);
            this.uiLabel_ReadOrWrite.TabIndex = 24;
            this.uiLabel_ReadOrWrite.Text = "读/写：";
            this.uiLabel_ReadOrWrite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel_To
            // 
            this.uiLabel_To.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel_To.Location = new System.Drawing.Point(236, 38);
            this.uiLabel_To.Name = "uiLabel_To";
            this.uiLabel_To.Size = new System.Drawing.Size(49, 36);
            this.uiLabel_To.TabIndex = 23;
            this.uiLabel_To.Text = "至";
            this.uiLabel_To.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiComboBox_Unit
            // 
            this.uiComboBox_Unit.DataSource = null;
            this.uiComboBox_Unit.FillColor = System.Drawing.Color.White;
            this.uiComboBox_Unit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox_Unit.Items.AddRange(new object[] {
            "ppm",
            "m/s",
            "Pa",
            "KPa",
            "MPa",
            "m",
            "℃",
            "L/s",
            "m³/h"});
            this.uiComboBox_Unit.Location = new System.Drawing.Point(404, 35);
            this.uiComboBox_Unit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_Unit.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_Unit.Name = "uiComboBox_Unit";
            this.uiComboBox_Unit.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_Unit.Size = new System.Drawing.Size(104, 39);
            this.uiComboBox_Unit.TabIndex = 20;
            this.uiComboBox_Unit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_Unit.Watermark = "单位";
            // 
            // uiTextBox_DeviceName
            // 
            this.uiTextBox_DeviceName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_DeviceName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTextBox_DeviceName.Location = new System.Drawing.Point(137, 98);
            this.uiTextBox_DeviceName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_DeviceName.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox_DeviceName.Name = "uiTextBox_DeviceName";
            this.uiTextBox_DeviceName.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_DeviceName.ShowText = false;
            this.uiTextBox_DeviceName.Size = new System.Drawing.Size(415, 39);
            this.uiTextBox_DeviceName.TabIndex = 25;
            this.uiTextBox_DeviceName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_DeviceName.Watermark = "";
            // 
            // uiGroupBox_AcquisitionParams
            // 
            this.uiGroupBox_AcquisitionParams.Controls.Add(this.uiLabel_WriteFrequency);
            this.uiGroupBox_AcquisitionParams.Controls.Add(this.uiComboBox_ReadFrequency);
            this.uiGroupBox_AcquisitionParams.Controls.Add(this.uiTextBox_Calibration);
            this.uiGroupBox_AcquisitionParams.Controls.Add(this.uiComboBox_ReadFrequencyUnit);
            this.uiGroupBox_AcquisitionParams.Controls.Add(this.uiLabel_Calibration);
            this.uiGroupBox_AcquisitionParams.Controls.Add(this.uiComboBox_IsWrite);
            this.uiGroupBox_AcquisitionParams.Controls.Add(this.uiTextBox_Ratio);
            this.uiGroupBox_AcquisitionParams.Controls.Add(this.uiComboBox_WriteFrequencyUnit);
            this.uiGroupBox_AcquisitionParams.Controls.Add(this.uiLabel_ReadFrequency);
            this.uiGroupBox_AcquisitionParams.Controls.Add(this.uiTextBox_WriteFrequency);
            this.uiGroupBox_AcquisitionParams.Controls.Add(this.uiLabel_IsWrite);
            this.uiGroupBox_AcquisitionParams.Controls.Add(this.uiLabel_Ratio);
            this.uiGroupBox_AcquisitionParams.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox_AcquisitionParams.Location = new System.Drawing.Point(10, 185);
            this.uiGroupBox_AcquisitionParams.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox_AcquisitionParams.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox_AcquisitionParams.Name = "uiGroupBox_AcquisitionParams";
            this.uiGroupBox_AcquisitionParams.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox_AcquisitionParams.Size = new System.Drawing.Size(541, 250);
            this.uiGroupBox_AcquisitionParams.TabIndex = 26;
            this.uiGroupBox_AcquisitionParams.Text = "采集参数";
            this.uiGroupBox_AcquisitionParams.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox_AcquisitionParams.TitleAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uiLabel_WriteFrequency
            // 
            this.uiLabel_WriteFrequency.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel_WriteFrequency.Location = new System.Drawing.Point(7, 135);
            this.uiLabel_WriteFrequency.Name = "uiLabel_WriteFrequency";
            this.uiLabel_WriteFrequency.Size = new System.Drawing.Size(120, 39);
            this.uiLabel_WriteFrequency.TabIndex = 38;
            this.uiLabel_WriteFrequency.Text = "存储频率:";
            this.uiLabel_WriteFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiComboBox_ReadFrequency
            // 
            this.uiComboBox_ReadFrequency.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiComboBox_ReadFrequency.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox_ReadFrequency.Location = new System.Drawing.Point(133, 37);
            this.uiComboBox_ReadFrequency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_ReadFrequency.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiComboBox_ReadFrequency.Name = "uiComboBox_ReadFrequency";
            this.uiComboBox_ReadFrequency.Padding = new System.Windows.Forms.Padding(5);
            this.uiComboBox_ReadFrequency.ShowText = false;
            this.uiComboBox_ReadFrequency.Size = new System.Drawing.Size(249, 39);
            this.uiComboBox_ReadFrequency.TabIndex = 37;
            this.uiComboBox_ReadFrequency.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_ReadFrequency.Watermark = "";
            // 
            // uiTextBox_Calibration
            // 
            this.uiTextBox_Calibration.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_Calibration.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTextBox_Calibration.Location = new System.Drawing.Point(407, 184);
            this.uiTextBox_Calibration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_Calibration.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox_Calibration.Name = "uiTextBox_Calibration";
            this.uiTextBox_Calibration.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_Calibration.ShowText = false;
            this.uiTextBox_Calibration.Size = new System.Drawing.Size(101, 39);
            this.uiTextBox_Calibration.TabIndex = 36;
            this.uiTextBox_Calibration.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_Calibration.Watermark = "";
            // 
            // uiComboBox_ReadFrequencyUnit
            // 
            this.uiComboBox_ReadFrequencyUnit.DataSource = null;
            this.uiComboBox_ReadFrequencyUnit.FillColor = System.Drawing.Color.White;
            this.uiComboBox_ReadFrequencyUnit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox_ReadFrequencyUnit.Items.AddRange(new object[] {
            "s",
            "ms"});
            this.uiComboBox_ReadFrequencyUnit.Location = new System.Drawing.Point(407, 37);
            this.uiComboBox_ReadFrequencyUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_ReadFrequencyUnit.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_ReadFrequencyUnit.Name = "uiComboBox_ReadFrequencyUnit";
            this.uiComboBox_ReadFrequencyUnit.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_ReadFrequencyUnit.Size = new System.Drawing.Size(101, 39);
            this.uiComboBox_ReadFrequencyUnit.TabIndex = 2;
            this.uiComboBox_ReadFrequencyUnit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_ReadFrequencyUnit.Watermark = "单位";
            // 
            // uiLabel_Calibration
            // 
            this.uiLabel_Calibration.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel_Calibration.Location = new System.Drawing.Point(286, 185);
            this.uiLabel_Calibration.Name = "uiLabel_Calibration";
            this.uiLabel_Calibration.Size = new System.Drawing.Size(139, 33);
            this.uiLabel_Calibration.TabIndex = 35;
            this.uiLabel_Calibration.Text = "参数校准：";
            this.uiLabel_Calibration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiComboBox_IsWrite
            // 
            this.uiComboBox_IsWrite.DataSource = null;
            this.uiComboBox_IsWrite.FillColor = System.Drawing.Color.White;
            this.uiComboBox_IsWrite.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox_IsWrite.Items.AddRange(new object[] {
            "是",
            "否"});
            this.uiComboBox_IsWrite.Location = new System.Drawing.Point(134, 86);
            this.uiComboBox_IsWrite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_IsWrite.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_IsWrite.Name = "uiComboBox_IsWrite";
            this.uiComboBox_IsWrite.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_IsWrite.Size = new System.Drawing.Size(248, 39);
            this.uiComboBox_IsWrite.TabIndex = 34;
            this.uiComboBox_IsWrite.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_IsWrite.Watermark = "";
            // 
            // uiTextBox_Ratio
            // 
            this.uiTextBox_Ratio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_Ratio.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTextBox_Ratio.Location = new System.Drawing.Point(133, 184);
            this.uiTextBox_Ratio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_Ratio.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox_Ratio.Name = "uiTextBox_Ratio";
            this.uiTextBox_Ratio.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_Ratio.ShowText = false;
            this.uiTextBox_Ratio.Size = new System.Drawing.Size(131, 39);
            this.uiTextBox_Ratio.TabIndex = 2;
            this.uiTextBox_Ratio.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_Ratio.Watermark = "";
            // 
            // uiComboBox_WriteFrequencyUnit
            // 
            this.uiComboBox_WriteFrequencyUnit.DataSource = null;
            this.uiComboBox_WriteFrequencyUnit.FillColor = System.Drawing.Color.White;
            this.uiComboBox_WriteFrequencyUnit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox_WriteFrequencyUnit.Items.AddRange(new object[] {
            "s",
            "ms",
            "变化时记录"});
            this.uiComboBox_WriteFrequencyUnit.Location = new System.Drawing.Point(407, 135);
            this.uiComboBox_WriteFrequencyUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_WriteFrequencyUnit.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_WriteFrequencyUnit.Name = "uiComboBox_WriteFrequencyUnit";
            this.uiComboBox_WriteFrequencyUnit.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_WriteFrequencyUnit.Size = new System.Drawing.Size(101, 39);
            this.uiComboBox_WriteFrequencyUnit.TabIndex = 31;
            this.uiComboBox_WriteFrequencyUnit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_WriteFrequencyUnit.Watermark = "单位";
            // 
            // uiLabel_ReadFrequency
            // 
            this.uiLabel_ReadFrequency.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel_ReadFrequency.Location = new System.Drawing.Point(7, 39);
            this.uiLabel_ReadFrequency.Name = "uiLabel_ReadFrequency";
            this.uiLabel_ReadFrequency.Size = new System.Drawing.Size(143, 37);
            this.uiLabel_ReadFrequency.TabIndex = 15;
            this.uiLabel_ReadFrequency.Text = "读取频率：";
            this.uiLabel_ReadFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox_WriteFrequency
            // 
            this.uiTextBox_WriteFrequency.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_WriteFrequency.EnterAsTab = true;
            this.uiTextBox_WriteFrequency.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTextBox_WriteFrequency.Location = new System.Drawing.Point(134, 135);
            this.uiTextBox_WriteFrequency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_WriteFrequency.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox_WriteFrequency.Name = "uiTextBox_WriteFrequency";
            this.uiTextBox_WriteFrequency.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_WriteFrequency.ShowText = false;
            this.uiTextBox_WriteFrequency.Size = new System.Drawing.Size(248, 39);
            this.uiTextBox_WriteFrequency.TabIndex = 1;
            this.uiTextBox_WriteFrequency.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_WriteFrequency.Watermark = "";
            // 
            // uiLabel_IsWrite
            // 
            this.uiLabel_IsWrite.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel_IsWrite.Location = new System.Drawing.Point(7, 76);
            this.uiLabel_IsWrite.Name = "uiLabel_IsWrite";
            this.uiLabel_IsWrite.Size = new System.Drawing.Size(108, 49);
            this.uiLabel_IsWrite.TabIndex = 27;
            this.uiLabel_IsWrite.Text = "存   储：";
            this.uiLabel_IsWrite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel_Ratio
            // 
            this.uiLabel_Ratio.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel_Ratio.Location = new System.Drawing.Point(7, 184);
            this.uiLabel_Ratio.Name = "uiLabel_Ratio";
            this.uiLabel_Ratio.Size = new System.Drawing.Size(101, 33);
            this.uiLabel_Ratio.TabIndex = 14;
            this.uiLabel_Ratio.Text = "系  数：";
            this.uiLabel_Ratio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.uiGroupBox_AcquisitionParams);
            this.uiGroupBox3.Controls.Add(this.uiGroupBox4);
            this.uiGroupBox3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox3.Location = new System.Drawing.Point(24, 199);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Size = new System.Drawing.Size(574, 442);
            this.uiGroupBox3.TabIndex = 35;
            this.uiGroupBox3.Text = "点位信息";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiComboBox_Protocol
            // 
            this.uiComboBox_Protocol.DataSource = null;
            this.uiComboBox_Protocol.FillColor = System.Drawing.Color.White;
            this.uiComboBox_Protocol.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox_Protocol.Items.AddRange(new object[] {
            "ModbusRTU",
            "ModbusTCP",
            "ModbusRTU转TCP",
            "OPCUA"});
            this.uiComboBox_Protocol.Location = new System.Drawing.Point(137, 150);
            this.uiComboBox_Protocol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_Protocol.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_Protocol.Name = "uiComboBox_Protocol";
            this.uiComboBox_Protocol.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_Protocol.Size = new System.Drawing.Size(415, 39);
            this.uiComboBox_Protocol.TabIndex = 36;
            this.uiComboBox_Protocol.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_Protocol.Watermark = "";
            // 
            // uiLabel_Protocol
            // 
            this.uiLabel_Protocol.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel_Protocol.Location = new System.Drawing.Point(18, 152);
            this.uiLabel_Protocol.Name = "uiLabel_Protocol";
            this.uiLabel_Protocol.Size = new System.Drawing.Size(139, 37);
            this.uiLabel_Protocol.TabIndex = 37;
            this.uiLabel_Protocol.Text = "通信协议：";
            this.uiLabel_Protocol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel_DeviceName
            // 
            this.uiLabel_DeviceName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel_DeviceName.Location = new System.Drawing.Point(18, 97);
            this.uiLabel_DeviceName.Name = "uiLabel_DeviceName";
            this.uiLabel_DeviceName.Size = new System.Drawing.Size(135, 40);
            this.uiLabel_DeviceName.TabIndex = 26;
            this.uiLabel_DeviceName.Text = "设备名称：";
            this.uiLabel_DeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiComboBox_NodeDescribe
            // 
            this.uiComboBox_NodeDescribe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiComboBox_NodeDescribe.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox_NodeDescribe.Location = new System.Drawing.Point(137, 46);
            this.uiComboBox_NodeDescribe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_NodeDescribe.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiComboBox_NodeDescribe.Name = "uiComboBox_NodeDescribe";
            this.uiComboBox_NodeDescribe.Padding = new System.Windows.Forms.Padding(5);
            this.uiComboBox_NodeDescribe.ShowText = false;
            this.uiComboBox_NodeDescribe.Size = new System.Drawing.Size(415, 39);
            this.uiComboBox_NodeDescribe.TabIndex = 38;
            this.uiComboBox_NodeDescribe.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_NodeDescribe.Watermark = "";
            // 
            // AddOrConfigDeviceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(627, 703);
            this.Controls.Add(this.uiComboBox_NodeDescribe);
            this.Controls.Add(this.uiTextBox_DeviceName);
            this.Controls.Add(this.uiLabel_DeviceName);
            this.Controls.Add(this.uiComboBox_Protocol);
            this.Controls.Add(this.uiLabel_Protocol);
            this.Controls.Add(this.uiGroupBox3);
            this.Controls.Add(this.uiLabel_NodeDescribe);
            this.Name = "AddOrConfigDeviceForm";
            this.Text = "添加设备";
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 805, 450);
            this.ButtonOkClick += new System.EventHandler(this.AddOrConfigDeviceForm_ButtonOkClick);
            this.Controls.SetChildIndex(this.uiLabel_NodeDescribe, 0);
            this.Controls.SetChildIndex(this.uiGroupBox3, 0);
            this.Controls.SetChildIndex(this.uiLabel_Protocol, 0);
            this.Controls.SetChildIndex(this.uiComboBox_Protocol, 0);
            this.Controls.SetChildIndex(this.uiLabel_DeviceName, 0);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.uiTextBox_DeviceName, 0);
            this.Controls.SetChildIndex(this.uiComboBox_NodeDescribe, 0);
            this.pnlBtm.ResumeLayout(false);
            this.uiGroupBox4.ResumeLayout(false);
            this.uiGroupBox_AcquisitionParams.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILabel uiLabel_NodeDescribe;
        private Sunny.UI.UIGroupBox uiGroupBox4;
        public Sunny.UI.UITextBox uiTextBox_DeviceName;
        public Sunny.UI.UITextBox uiTextBox_RangeHigh;
        public Sunny.UI.UIComboBox uiComboBox_DataType;
        private Sunny.UI.UILabel uiLabel_DataType;
        public Sunny.UI.UITextBox uiTextBox_RangeLow;
        private Sunny.UI.UILabel uiLabel__Range;
        private Sunny.UI.UILabel uiLabel_ReadOrWrite;
        private Sunny.UI.UILabel uiLabel_To;
        public Sunny.UI.UIComboBox uiComboBox_Unit;
        public Sunny.UI.UIGroupBox uiGroupBox_AcquisitionParams;
        private Sunny.UI.UIComboBox uiComboBox_ReadFrequencyUnit;
        private Sunny.UI.UILabel uiLabel_Calibration;
        public Sunny.UI.UIComboBox uiComboBox_IsWrite;
        public Sunny.UI.UITextBox uiTextBox_Ratio;
        public Sunny.UI.UIComboBox uiComboBox_WriteFrequencyUnit;
        private Sunny.UI.UILabel uiLabel_ReadFrequency;
        public Sunny.UI.UITextBox uiTextBox_WriteFrequency;
        private Sunny.UI.UILabel uiLabel_IsWrite;
        private Sunny.UI.UILabel uiLabel_Ratio;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        public Sunny.UI.UIComboBox uiComboBox_Protocol;
        private Sunny.UI.UILabel uiLabel_Protocol;
        private Sunny.UI.UILabel uiLabel_DeviceName;
        public Sunny.UI.UIComboBox uiComboBox_ReadOrWrite;
        public Sunny.UI.UITextBox uiTextBox_Calibration;
        public Sunny.UI.UITextBox uiComboBox_NodeDescribe;
        public Sunny.UI.UITextBox uiComboBox_ReadFrequency;
        private Sunny.UI.UILabel uiLabel_WriteFrequency;
    }
}