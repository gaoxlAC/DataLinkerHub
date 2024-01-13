namespace NengHuan.Forms.Common
{
    partial class SetupForm
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
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.tBdbName = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.tBdbPassword = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.tBdbUsername = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.tBdbPort = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.tBdbServer = new Sunny.UI.UITextBox();
            this.pnlBtm.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 321);
            this.pnlBtm.Size = new System.Drawing.Size(468, 55);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(340, 12);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(225, 12);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.uiLabel5);
            this.uiGroupBox2.Controls.Add(this.tBdbName);
            this.uiGroupBox2.Controls.Add(this.uiLabel4);
            this.uiGroupBox2.Controls.Add(this.tBdbPassword);
            this.uiGroupBox2.Controls.Add(this.uiLabel2);
            this.uiGroupBox2.Controls.Add(this.tBdbUsername);
            this.uiGroupBox2.Controls.Add(this.uiLabel1);
            this.uiGroupBox2.Controls.Add(this.tBdbPort);
            this.uiGroupBox2.Controls.Add(this.uiLabel3);
            this.uiGroupBox2.Controls.Add(this.tBdbServer);
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox2.Location = new System.Drawing.Point(1, 40);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(444, 262);
            this.uiGroupBox2.TabIndex = 2;
            this.uiGroupBox2.Text = "传感器数据库连接";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(26, 44);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(163, 31);
            this.uiLabel5.TabIndex = 55;
            this.uiLabel5.Text = "数据库名称：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBdbName
            // 
            this.tBdbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBdbName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tBdbName.Location = new System.Drawing.Point(220, 36);
            this.tBdbName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBdbName.MinimumSize = new System.Drawing.Size(1, 1);
            this.tBdbName.Name = "tBdbName";
            this.tBdbName.Padding = new System.Windows.Forms.Padding(5);
            this.tBdbName.Radius = 8;
            this.tBdbName.ShowText = false;
            this.tBdbName.Size = new System.Drawing.Size(137, 39);
            this.tBdbName.TabIndex = 2;
            this.tBdbName.Text = "yethannyhj";
            this.tBdbName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tBdbName.Watermark = "";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(53, 207);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(89, 39);
            this.uiLabel4.TabIndex = 51;
            this.uiLabel4.Text = "密码：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBdbPassword
            // 
            this.tBdbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBdbPassword.DoubleValue = 123456D;
            this.tBdbPassword.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tBdbPassword.IntValue = 123456;
            this.tBdbPassword.Location = new System.Drawing.Point(220, 207);
            this.tBdbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBdbPassword.MinimumSize = new System.Drawing.Size(1, 1);
            this.tBdbPassword.Name = "tBdbPassword";
            this.tBdbPassword.Padding = new System.Windows.Forms.Padding(5);
            this.tBdbPassword.PasswordChar = '*';
            this.tBdbPassword.Radius = 8;
            this.tBdbPassword.ShowText = false;
            this.tBdbPassword.Size = new System.Drawing.Size(137, 39);
            this.tBdbPassword.TabIndex = 9;
            this.tBdbPassword.Text = "123456";
            this.tBdbPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tBdbPassword.Watermark = "";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(50, 162);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(110, 42);
            this.uiLabel2.TabIndex = 49;
            this.uiLabel2.Text = "用户名：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBdbUsername
            // 
            this.tBdbUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBdbUsername.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tBdbUsername.Location = new System.Drawing.Point(220, 165);
            this.tBdbUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBdbUsername.MinimumSize = new System.Drawing.Size(1, 1);
            this.tBdbUsername.Name = "tBdbUsername";
            this.tBdbUsername.Padding = new System.Windows.Forms.Padding(5);
            this.tBdbUsername.Radius = 8;
            this.tBdbUsername.ShowText = false;
            this.tBdbUsername.Size = new System.Drawing.Size(137, 39);
            this.tBdbUsername.TabIndex = 8;
            this.tBdbUsername.Text = "root";
            this.tBdbUsername.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tBdbUsername.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(50, 124);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(92, 39);
            this.uiLabel1.TabIndex = 47;
            this.uiLabel1.Text = "端口：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBdbPort
            // 
            this.tBdbPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBdbPort.DoubleValue = 3306D;
            this.tBdbPort.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tBdbPort.IntValue = 3306;
            this.tBdbPort.Location = new System.Drawing.Point(220, 126);
            this.tBdbPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBdbPort.MinimumSize = new System.Drawing.Size(1, 1);
            this.tBdbPort.Name = "tBdbPort";
            this.tBdbPort.Padding = new System.Windows.Forms.Padding(5);
            this.tBdbPort.Radius = 8;
            this.tBdbPort.ShowText = false;
            this.tBdbPort.Size = new System.Drawing.Size(70, 39);
            this.tBdbPort.TabIndex = 7;
            this.tBdbPort.Text = "3306";
            this.tBdbPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tBdbPort.Watermark = "";
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(50, 85);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(92, 39);
            this.uiLabel3.TabIndex = 45;
            this.uiLabel3.Text = "域名：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBdbServer
            // 
            this.tBdbServer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBdbServer.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tBdbServer.Location = new System.Drawing.Point(220, 85);
            this.tBdbServer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBdbServer.MinimumSize = new System.Drawing.Size(1, 1);
            this.tBdbServer.Name = "tBdbServer";
            this.tBdbServer.Padding = new System.Windows.Forms.Padding(5);
            this.tBdbServer.Radius = 8;
            this.tBdbServer.ShowText = false;
            this.tBdbServer.Size = new System.Drawing.Size(176, 39);
            this.tBdbServer.TabIndex = 5;
            this.tBdbServer.Text = "127.0.0.1";
            this.tBdbServer.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tBdbServer.Watermark = "";
            // 
            // SetupForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(470, 379);
            this.Controls.Add(this.uiGroupBox2);
            this.Name = "SetupForm";
            this.Text = "传感器数据库配置";
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 300, 381);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.uiGroupBox2, 0);
            this.pnlBtm.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UILabel uiLabel5;
        public Sunny.UI.UITextBox tBdbName;
        private Sunny.UI.UILabel uiLabel4;
        public Sunny.UI.UITextBox tBdbPassword;
        private Sunny.UI.UILabel uiLabel2;
        public Sunny.UI.UITextBox tBdbUsername;
        private Sunny.UI.UILabel uiLabel1;
        public Sunny.UI.UITextBox tBdbPort;
        private Sunny.UI.UILabel uiLabel3;
        public Sunny.UI.UITextBox tBdbServer;
    }
}
