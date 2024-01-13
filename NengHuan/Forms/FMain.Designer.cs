namespace NengHuan.UI
{
    partial class FMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.MainContainer = new Sunny.UI.UITabControl();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.传感器管理toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.传感器数据库配置toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Header = new Sunny.UI.UINavBar();
            this.EndButton = new Sunny.UI.UIButton();
            this.StartButton = new Sunny.UI.UIButton();
            this.uiLight2 = new Sunny.UI.UILight();
            this.btn_ConnectServer = new Sunny.UI.UIButton();
            this.uiipTextBox = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.ucBtnAddDevice1 = new NengHuan.UserControls.UCBtnAddDevice();
            this.Aside = new Sunny.UI.UINavMenu();
            this.StyleManager = new Sunny.UI.UIStyleManager(this.components);
            this.menuStrip1.SuspendLayout();
            this.Header.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            this.MainContainer.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.MainContainer.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.MainContainer.ItemSize = new System.Drawing.Size(0, 1);
            this.MainContainer.Location = new System.Drawing.Point(220, 87);
            this.MainContainer.MainPage = "";
            this.MainContainer.Margin = new System.Windows.Forms.Padding(0);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.SelectedIndex = 0;
            this.MainContainer.Size = new System.Drawing.Size(1000, 513);
            this.MainContainer.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainContainer.TabIndex = 12;
            this.MainContainer.TabVisible = false;
            this.MainContainer.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label2.Size = new System.Drawing.Size(323, 30);
            this.label2.TabIndex = 10;
            this.label2.Text = "能环监测数据采集系统";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.传感器管理toolStripMenuItem,
            this.传感器数据库配置toolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(222, 7);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(352, 40);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 传感器管理toolStripMenuItem
            // 
            this.传感器管理toolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(102)))), ((int)(((byte)(104)))));
            this.传感器管理toolStripMenuItem.Name = "传感器管理toolStripMenuItem";
            this.传感器管理toolStripMenuItem.Size = new System.Drawing.Size(139, 34);
            this.传感器管理toolStripMenuItem.Text = "传感器管理";
            this.传感器管理toolStripMenuItem.Click += new System.EventHandler(this.传感器管理toolStripMenuItem_Click);
            // 
            // 传感器数据库配置toolStripMenuItem
            // 
            this.传感器数据库配置toolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(102)))), ((int)(((byte)(104)))));
            this.传感器数据库配置toolStripMenuItem.Name = "传感器数据库配置toolStripMenuItem";
            this.传感器数据库配置toolStripMenuItem.Size = new System.Drawing.Size(205, 34);
            this.传感器数据库配置toolStripMenuItem.Text = "传感器数据库配置";
            this.传感器数据库配置toolStripMenuItem.Click += new System.EventHandler(this.传感器数据库配置toolStripMenuItem_Click_1);
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Header.Controls.Add(this.EndButton);
            this.Header.Controls.Add(this.StartButton);
            this.Header.Controls.Add(this.uiLight2);
            this.Header.Controls.Add(this.btn_ConnectServer);
            this.Header.Controls.Add(this.uiipTextBox);
            this.Header.Controls.Add(this.menuStrip1);
            this.Header.Controls.Add(this.uiLabel6);
            this.Header.Controls.Add(this.uiPanel1);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.DropMenuFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Header.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Header.Location = new System.Drawing.Point(0, 35);
            this.Header.MenuHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Header.MenuSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Header.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1222, 843);
            this.Header.TabIndex = 1;
            this.Header.Text = "uiNavBar1";
            this.Header.MenuItemClick += new Sunny.UI.UINavBar.OnMenuItemClick(this.Header_MenuItemClick);
            // 
            // EndButton
            // 
            this.EndButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EndButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.EndButton.Location = new System.Drawing.Point(1117, 7);
            this.EndButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(100, 32);
            this.EndButton.TabIndex = 37;
            this.EndButton.Text = "全部停止";
            this.EndButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.StartButton.Location = new System.Drawing.Point(999, 7);
            this.StartButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 32);
            this.StartButton.TabIndex = 36;
            this.StartButton.Text = "全部开始";
            this.StartButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // uiLight2
            // 
            this.uiLight2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLight2.Location = new System.Drawing.Point(924, 3);
            this.uiLight2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLight2.Name = "uiLight2";
            this.uiLight2.Radius = 35;
            this.uiLight2.Size = new System.Drawing.Size(35, 35);
            this.uiLight2.TabIndex = 13;
            this.uiLight2.Text = "uiLight2";
            // 
            // btn_ConnectServer
            // 
            this.btn_ConnectServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ConnectServer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ConnectServer.Location = new System.Drawing.Point(801, 3);
            this.btn_ConnectServer.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ConnectServer.Name = "btn_ConnectServer";
            this.btn_ConnectServer.Size = new System.Drawing.Size(108, 35);
            this.btn_ConnectServer.TabIndex = 63;
            this.btn_ConnectServer.Text = "连接服务器";
            this.btn_ConnectServer.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ConnectServer.Click += new System.EventHandler(this.btn_ConnectServer_Click);
            // 
            // uiipTextBox
            // 
            this.uiipTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiipTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiipTextBox.Location = new System.Drawing.Point(581, 2);
            this.uiipTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiipTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiipTextBox.Name = "uiipTextBox";
            this.uiipTextBox.Padding = new System.Windows.Forms.Padding(5);
            this.uiipTextBox.ShowText = false;
            this.uiipTextBox.Size = new System.Drawing.Size(213, 35);
            this.uiipTextBox.TabIndex = 63;
            this.uiipTextBox.Text = "opc.tcp://127.0.0.1:49320";
            this.uiipTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiipTextBox.Watermark = "";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(490, 2);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(169, 35);
            this.uiLabel6.TabIndex = 62;
            this.uiLabel6.Text = "服务器地址：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiPanel1
            // 
            this.uiPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(36)))));
            this.uiPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.uiPanel1.Controls.Add(this.ucBtnAddDevice1);
            this.uiPanel1.Controls.Add(this.label2);
            this.uiPanel1.Controls.Add(this.Aside);
            this.uiPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(36)))));
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(-3, -3);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiPanel1.Size = new System.Drawing.Size(225, 569);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.TabIndex = 14;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucBtnAddDevice1
            // 
            this.ucBtnAddDevice1.Image = ((System.Drawing.Image)(resources.GetObject("ucBtnAddDevice1.Image")));
            this.ucBtnAddDevice1.Location = new System.Drawing.Point(0, 32668);
            this.ucBtnAddDevice1.Margin = new System.Windows.Forms.Padding(492, 1299, 492, 1299);
            this.ucBtnAddDevice1.Name = "ucBtnAddDevice1";
            this.ucBtnAddDevice1.Size = new System.Drawing.Size(33796, 30521);
            this.ucBtnAddDevice1.TabIndex = 11;
            this.ucBtnAddDevice1.Text = "添加点位";
            this.ucBtnAddDevice1.Click += new System.EventHandler(this.ucBtnAddDevice1_Click);
            // 
            // Aside
            // 
            this.Aside.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(36)))));
            this.Aside.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Aside.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.Aside.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(19)))), ((int)(((byte)(36)))));
            this.Aside.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Aside.FullRowSelect = true;
            this.Aside.ItemHeight = 36;
            this.Aside.Location = new System.Drawing.Point(5, 58);
            this.Aside.Margin = new System.Windows.Forms.Padding(0);
            this.Aside.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Aside.Name = "Aside";
            this.Aside.ShowLines = false;
            this.Aside.Size = new System.Drawing.Size(225, 511);
            this.Aside.Style = Sunny.UI.UIStyle.Custom;
            this.Aside.TabIndex = 1;
            this.Aside.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // StyleManager
            // 
            this.StyleManager.DPIScale = true;
            // 
            // FMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1222, 597);
            this.Controls.Add(this.MainContainer);
            this.Controls.Add(this.Header);
            this.MaximizeBox = false;
            this.Name = "FMain";
            this.Text = "";
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 800, 450);
            this.Load += new System.EventHandler(this.FMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITabControl MainContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        protected Sunny.UI.UINavBar Header;
        private Sunny.UI.UIStyleManager StyleManager;
        private System.Windows.Forms.ToolStripMenuItem 传感器管理toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 传感器数据库配置toolStripMenuItem;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UINavMenu Aside;
        private UserControls.UCBtnAddDevice ucBtnAddDevice1;
        private Sunny.UI.UITextBox uiipTextBox;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIButton btn_ConnectServer;
        private Sunny.UI.UILight uiLight2;
        private Sunny.UI.UIButton EndButton;
        private Sunny.UI.UIButton StartButton;
    }
}