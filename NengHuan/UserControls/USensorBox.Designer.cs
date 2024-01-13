namespace NengHuan.UserControls
{
    partial class USensorBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_SensorName = new Sunny.UI.UILabel();
            this.led_SensorStatus = new Sunny.UI.UILedBulb();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.lb_SensorValue_Unit = new Sunny.UI.UILabel();
            this.txt_SensorLocation = new Sunny.UI.UITextBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.lb_DateTime = new Sunny.UI.UILabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pB_SensorTypeImg = new System.Windows.Forms.PictureBox();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_SensorTypeImg)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_SensorName
            // 
            this.lb_SensorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.lb_SensorName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_SensorName.Location = new System.Drawing.Point(-1, 0);
            this.lb_SensorName.Name = "lb_SensorName";
            this.lb_SensorName.Size = new System.Drawing.Size(200, 30);
            this.lb_SensorName.Style = Sunny.UI.UIStyle.Custom;
            this.lb_SensorName.TabIndex = 1;
            this.lb_SensorName.Text = "二氧化碳浓度";
            this.lb_SensorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // led_SensorStatus
            // 
            this.led_SensorStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(140)))));
            this.led_SensorStatus.Location = new System.Drawing.Point(174, 3);
            this.led_SensorStatus.Name = "led_SensorStatus";
            this.led_SensorStatus.Size = new System.Drawing.Size(20, 20);
            this.led_SensorStatus.TabIndex = 2;
            this.led_SensorStatus.Text = "uiLedBulb1";
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.pictureBox2);
            this.uiPanel1.Controls.Add(this.lb_DateTime);
            this.uiPanel1.Controls.Add(this.txt_SensorLocation);
            this.uiPanel1.Controls.Add(this.lb_SensorValue_Unit);
            this.uiPanel1.Controls.Add(this.led_SensorStatus);
            this.uiPanel1.Controls.Add(this.pB_SensorTypeImg);
            this.uiPanel1.Controls.Add(this.lb_SensorName);
            this.uiPanel1.Controls.Add(this.uiLine1);
            this.uiPanel1.FillColor = System.Drawing.Color.Red;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(4, 5);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(300, 210);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.TabIndex = 7;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_SensorValue_Unit
            // 
            this.lb_SensorValue_Unit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_SensorValue_Unit.Location = new System.Drawing.Point(50, 49);
            this.lb_SensorValue_Unit.Name = "lb_SensorValue_Unit";
            this.lb_SensorValue_Unit.Size = new System.Drawing.Size(149, 34);
            this.lb_SensorValue_Unit.Style = Sunny.UI.UIStyle.Custom;
            this.lb_SensorValue_Unit.TabIndex = 7;
            this.lb_SensorValue_Unit.Text = "1000.2345 ppm";
            this.lb_SensorValue_Unit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_SensorLocation
            // 
            this.txt_SensorLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_SensorLocation.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_SensorLocation.Location = new System.Drawing.Point(28, 91);
            this.txt_SensorLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SensorLocation.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_SensorLocation.Name = "txt_SensorLocation";
            this.txt_SensorLocation.Padding = new System.Windows.Forms.Padding(5);
            this.txt_SensorLocation.ShowText = false;
            this.txt_SensorLocation.Size = new System.Drawing.Size(171, 31);
            this.txt_SensorLocation.Style = Sunny.UI.UIStyle.Custom;
            this.txt_SensorLocation.TabIndex = 9;
            this.txt_SensorLocation.Text = "西侧4.2m夹层二氧化碳浓度西侧4.2m夹层二氧化碳浓度";
            this.txt_SensorLocation.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine1.Location = new System.Drawing.Point(0, 111);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(200, 29);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 10;
            // 
            // lb_DateTime
            // 
            this.lb_DateTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_DateTime.Location = new System.Drawing.Point(0, 127);
            this.lb_DateTime.Name = "lb_DateTime";
            this.lb_DateTime.Size = new System.Drawing.Size(195, 20);
            this.lb_DateTime.Style = Sunny.UI.UIStyle.Custom;
            this.lb_DateTime.TabIndex = 11;
            this.lb_DateTime.Text = "2021/07/30 17:23:30";
            this.lb_DateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::NengHuan.Properties.Resources.location;
            this.pictureBox2.Location = new System.Drawing.Point(6, 107);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 15);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pB_SensorTypeImg
            // 
            this.pB_SensorTypeImg.Image = global::NengHuan.Properties.Resources.pressure;
            this.pB_SensorTypeImg.Location = new System.Drawing.Point(3, 43);
            this.pB_SensorTypeImg.Name = "pB_SensorTypeImg";
            this.pB_SensorTypeImg.Size = new System.Drawing.Size(40, 40);
            this.pB_SensorTypeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_SensorTypeImg.TabIndex = 6;
            this.pB_SensorTypeImg.TabStop = false;
            // 
            // USensorBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.uiPanel1);
            this.Name = "USensorBox";
            this.Size = new System.Drawing.Size(300, 210);
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_SensorTypeImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Sunny.UI.UILabel lb_SensorName;
        public Sunny.UI.UILedBulb led_SensorStatus;
        public System.Windows.Forms.PictureBox pB_SensorTypeImg;
        private Sunny.UI.UIPanel uiPanel1;
        public Sunny.UI.UILabel lb_DateTime;
        public Sunny.UI.UITextBox txt_SensorLocation;
        public Sunny.UI.UILabel lb_SensorValue_Unit;
        private Sunny.UI.UILine uiLine1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
