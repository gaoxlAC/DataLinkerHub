namespace NengHuan.Forms.Common
{
    partial class ServerForm
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
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiLight = new Sunny.UI.UILight();
            this.txt_ServerAddress = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.btn_BrowseServer = new Sunny.UI.UIButton();
            this.btn_ConnectServer = new Sunny.UI.UIButton();
            this.pnlBtm.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 229);
            this.pnlBtm.Size = new System.Drawing.Size(546, 62);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(418, 12);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(303, 12);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiLight);
            this.uiGroupBox1.Controls.Add(this.txt_ServerAddress);
            this.uiGroupBox1.Controls.Add(this.uiLabel6);
            this.uiGroupBox1.Controls.Add(this.btn_BrowseServer);
            this.uiGroupBox1.Controls.Add(this.btn_ConnectServer);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(5, 40);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(520, 183);
            this.uiGroupBox1.TabIndex = 2;
            this.uiGroupBox1.Text = "服务器配置";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLight
            // 
            this.uiLight.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLight.Location = new System.Drawing.Point(183, 125);
            this.uiLight.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLight.Name = "uiLight";
            this.uiLight.Radius = 35;
            this.uiLight.Size = new System.Drawing.Size(35, 35);
            this.uiLight.TabIndex = 64;
            this.uiLight.Text = "uiLight1";
            // 
            // txt_ServerAddress
            // 
            this.txt_ServerAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ServerAddress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ServerAddress.Location = new System.Drawing.Point(173, 44);
            this.txt_ServerAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_ServerAddress.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_ServerAddress.Name = "txt_ServerAddress";
            this.txt_ServerAddress.ShowText = false;
            this.txt_ServerAddress.Size = new System.Drawing.Size(299, 35);
            this.txt_ServerAddress.TabIndex = 61;
            this.txt_ServerAddress.Text = "opc.tcp://127.0.0.1:49320";
            this.txt_ServerAddress.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_ServerAddress.Watermark = "";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(11, 44);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(169, 35);
            this.uiLabel6.TabIndex = 60;
            this.uiLabel6.Text = "服务器地址：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_BrowseServer
            // 
            this.btn_BrowseServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_BrowseServer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_BrowseServer.Location = new System.Drawing.Point(340, 126);
            this.btn_BrowseServer.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_BrowseServer.Name = "btn_BrowseServer";
            this.btn_BrowseServer.Size = new System.Drawing.Size(132, 35);
            this.btn_BrowseServer.TabIndex = 63;
            this.btn_BrowseServer.Text = "节点浏览器";
            this.btn_BrowseServer.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_BrowseServer.Click += new System.EventHandler(this.btn_BrowseServer_Click);
            // 
            // btn_ConnectServer
            // 
            this.btn_ConnectServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ConnectServer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ConnectServer.Location = new System.Drawing.Point(32, 126);
            this.btn_ConnectServer.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ConnectServer.Name = "btn_ConnectServer";
            this.btn_ConnectServer.Size = new System.Drawing.Size(128, 35);
            this.btn_ConnectServer.TabIndex = 62;
            this.btn_ConnectServer.Text = "连接服务器";
            this.btn_ConnectServer.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ConnectServer.Click += new System.EventHandler(this.btn_ConnectServer_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(548, 294);
            this.Controls.Add(this.uiGroupBox1);
            this.Name = "ServerForm";
            this.Text = "服务器管理";
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 800, 450);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.uiGroupBox1, 0);
            this.pnlBtm.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UITextBox txt_ServerAddress;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIButton btn_BrowseServer;
        private Sunny.UI.UIButton btn_ConnectServer;
        private Sunny.UI.UILight uiLight;
    }
}