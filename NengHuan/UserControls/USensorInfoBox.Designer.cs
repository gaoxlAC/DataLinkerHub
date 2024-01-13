namespace NengHuan.UserControls
{
    partial class USensorInfoBox
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
            this.lb_SensorName = new Sunny.UI.UITitlePanel();
            this.led_SensorStatus = new Sunny.UI.UILight();
            this.OneButton = new Sunny.UI.UIButton();
            this.txt_SensorLabel = new Sunny.UI.UITextBox();
            this.SensorInfoTextBox = new Sunny.UI.UIRichTextBox();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.lb_SensorName.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_SensorName
            // 
            this.lb_SensorName.Controls.Add(this.led_SensorStatus);
            this.lb_SensorName.Controls.Add(this.OneButton);
            this.lb_SensorName.Controls.Add(this.txt_SensorLabel);
            this.lb_SensorName.Controls.Add(this.SensorInfoTextBox);
            this.lb_SensorName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_SensorName.Location = new System.Drawing.Point(0, 0);
            this.lb_SensorName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lb_SensorName.MinimumSize = new System.Drawing.Size(1, 1);
            this.lb_SensorName.Name = "lb_SensorName";
            this.lb_SensorName.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.lb_SensorName.ShowCollapse = true;
            this.lb_SensorName.ShowText = false;
            this.lb_SensorName.Size = new System.Drawing.Size(450, 245);
            this.lb_SensorName.TabIndex = 37;
            this.lb_SensorName.Text = "传感器名称";
            this.lb_SensorName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // led_SensorStatus
            // 
            this.led_SensorStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.led_SensorStatus.Location = new System.Drawing.Point(122, 3);
            this.led_SensorStatus.MinimumSize = new System.Drawing.Size(1, 1);
            this.led_SensorStatus.Name = "led_SensorStatus";
            this.led_SensorStatus.Radius = 26;
            this.led_SensorStatus.Size = new System.Drawing.Size(26, 27);
            this.led_SensorStatus.TabIndex = 39;
            this.led_SensorStatus.Text = "uiLight2";
            // 
            // OneButton
            // 
            this.OneButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OneButton.Enabled = false;
            this.OneButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OneButton.Location = new System.Drawing.Point(353, 200);
            this.OneButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.OneButton.Name = "OneButton";
            this.OneButton.Size = new System.Drawing.Size(80, 35);
            this.OneButton.TabIndex = 38;
            this.OneButton.Text = "开始采集";
            this.OneButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OneButton.Click += new System.EventHandler(this.OneButton_Click);
            // 
            // txt_SensorLabel
            // 
            this.txt_SensorLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_SensorLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_SensorLabel.Location = new System.Drawing.Point(171, 3);
            this.txt_SensorLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SensorLabel.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_SensorLabel.Name = "txt_SensorLabel";
            this.txt_SensorLabel.Padding = new System.Windows.Forms.Padding(5);
            this.txt_SensorLabel.ReadOnly = true;
            this.txt_SensorLabel.ShowText = false;
            this.txt_SensorLabel.Size = new System.Drawing.Size(231, 27);
            this.txt_SensorLabel.TabIndex = 36;
            this.txt_SensorLabel.Text = "西侧4.2m夹层温度西侧4.2m";
            this.txt_SensorLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_SensorLabel.Watermark = "";
            // 
            // SensorInfoTextBox
            // 
            this.SensorInfoTextBox.FillColor = System.Drawing.Color.White;
            this.SensorInfoTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SensorInfoTextBox.Location = new System.Drawing.Point(4, 42);
            this.SensorInfoTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SensorInfoTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.SensorInfoTextBox.Name = "SensorInfoTextBox";
            this.SensorInfoTextBox.Padding = new System.Windows.Forms.Padding(2);
            this.SensorInfoTextBox.ShowText = false;
            this.SensorInfoTextBox.Size = new System.Drawing.Size(442, 150);
            this.SensorInfoTextBox.TabIndex = 0;
            this.SensorInfoTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.SensorInfoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SensorInfoTextBox_KeyPress);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.lb_SensorName);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(450, 245);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // USensorInfoBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.uiPanel1);
            this.Name = "USensorInfoBox";
            this.Size = new System.Drawing.Size(450, 250);
            this.lb_SensorName.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIDataGridView dataGridView2;
        private Sunny.UI.UIRichTextBox SensorInfoTextBox;
        private Sunny.UI.UITextBox txt_SensorLabel;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILight led_SensorStatus;
        public Sunny.UI.UITitlePanel lb_SensorName;
        public Sunny.UI.UIButton OneButton;
    }
}
