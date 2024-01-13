namespace NengHuan.Forms.Common
{
    partial class FormConnectSelect
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
            this.TabControl = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_AnonymousLogin = new Sunny.UI.UISymbolButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_NameLogin = new Sunny.UI.UISymbolButton();
            this.tBuserPassword = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.tBuserName = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_CertificateLogin = new Sunny.UI.UISymbolButton();
            this.btn_ZS = new Sunny.UI.UIButton();
            this.tBzsPassword = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.tBCertificate = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.pnlBtm.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 446);
            this.pnlBtm.Radius = 1;
            this.pnlBtm.Size = new System.Drawing.Size(798, 1);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(670, 12);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(555, 12);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Controls.Add(this.tabPage3);
            this.TabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.TabControl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabControl.ItemSize = new System.Drawing.Size(150, 40);
            this.TabControl.Location = new System.Drawing.Point(-1, 35);
            this.TabControl.MainPage = "";
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(800, 412);
            this.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl.TabIndex = 0;
            this.TabControl.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_AnonymousLogin);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(800, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "匿名登陆";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_AnonymousLogin
            // 
            this.btn_AnonymousLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AnonymousLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AnonymousLogin.Location = new System.Drawing.Point(281, 167);
            this.btn_AnonymousLogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_AnonymousLogin.Name = "btn_AnonymousLogin";
            this.btn_AnonymousLogin.Size = new System.Drawing.Size(128, 47);
            this.btn_AnonymousLogin.TabIndex = 1;
            this.btn_AnonymousLogin.Text = "登陆";
            this.btn_AnonymousLogin.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AnonymousLogin.Click += new System.EventHandler(this.btn_AnonymousLogin_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_NameLogin);
            this.tabPage2.Controls.Add(this.tBuserPassword);
            this.tabPage2.Controls.Add(this.uiLabel2);
            this.tabPage2.Controls.Add(this.tBuserName);
            this.tabPage2.Controls.Add(this.uiLabel1);
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(800, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "用户名登陆";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_NameLogin
            // 
            this.btn_NameLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_NameLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_NameLogin.Location = new System.Drawing.Point(291, 253);
            this.btn_NameLogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_NameLogin.Name = "btn_NameLogin";
            this.btn_NameLogin.Size = new System.Drawing.Size(146, 47);
            this.btn_NameLogin.TabIndex = 12;
            this.btn_NameLogin.Text = "登陆";
            this.btn_NameLogin.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_NameLogin.Click += new System.EventHandler(this.btn_NameLogin_Click);
            // 
            // tBuserPassword
            // 
            this.tBuserPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBuserPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBuserPassword.Location = new System.Drawing.Point(291, 143);
            this.tBuserPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBuserPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.tBuserPassword.Name = "tBuserPassword";
            this.tBuserPassword.PasswordChar = '*';
            this.tBuserPassword.ShowText = false;
            this.tBuserPassword.Size = new System.Drawing.Size(268, 33);
            this.tBuserPassword.TabIndex = 3;
            this.tBuserPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tBuserPassword.Watermark = "";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(143, 143);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(108, 33);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "密码：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tBuserName
            // 
            this.tBuserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBuserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBuserName.Location = new System.Drawing.Point(291, 68);
            this.tBuserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBuserName.MinimumSize = new System.Drawing.Size(1, 16);
            this.tBuserName.Name = "tBuserName";
            this.tBuserName.ShowText = false;
            this.tBuserName.Size = new System.Drawing.Size(268, 33);
            this.tBuserName.TabIndex = 1;
            this.tBuserName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tBuserName.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(143, 68);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(119, 33);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "用户名：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_CertificateLogin);
            this.tabPage3.Controls.Add(this.btn_ZS);
            this.tabPage3.Controls.Add(this.tBzsPassword);
            this.tabPage3.Controls.Add(this.uiLabel3);
            this.tabPage3.Controls.Add(this.tBCertificate);
            this.tabPage3.Controls.Add(this.uiLabel4);
            this.tabPage3.Location = new System.Drawing.Point(0, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(800, 372);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "证书登陆";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_CertificateLogin
            // 
            this.btn_CertificateLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CertificateLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CertificateLogin.Location = new System.Drawing.Point(285, 265);
            this.btn_CertificateLogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CertificateLogin.Name = "btn_CertificateLogin";
            this.btn_CertificateLogin.Size = new System.Drawing.Size(146, 47);
            this.btn_CertificateLogin.TabIndex = 11;
            this.btn_CertificateLogin.Text = "登陆";
            this.btn_CertificateLogin.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CertificateLogin.Click += new System.EventHandler(this.btn_CertificateLogin_Click);
            // 
            // btn_ZS
            // 
            this.btn_ZS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ZS.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ZS.Location = new System.Drawing.Point(584, 80);
            this.btn_ZS.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ZS.Name = "btn_ZS";
            this.btn_ZS.Size = new System.Drawing.Size(100, 35);
            this.btn_ZS.TabIndex = 10;
            this.btn_ZS.Text = ". . .";
            this.btn_ZS.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ZS.Click += new System.EventHandler(this.uiButton4_Click);
            // 
            // tBzsPassword
            // 
            this.tBzsPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBzsPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBzsPassword.Location = new System.Drawing.Point(285, 155);
            this.tBzsPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBzsPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.tBzsPassword.Name = "tBzsPassword";
            this.tBzsPassword.PasswordChar = '*';
            this.tBzsPassword.ShowText = false;
            this.tBzsPassword.Size = new System.Drawing.Size(268, 33);
            this.tBzsPassword.TabIndex = 8;
            this.tBzsPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tBzsPassword.Watermark = "";
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(161, 155);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(108, 33);
            this.uiLabel3.TabIndex = 7;
            this.uiLabel3.Text = "密匙：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tBCertificate
            // 
            this.tBCertificate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBCertificate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tBCertificate.Location = new System.Drawing.Point(285, 82);
            this.tBCertificate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBCertificate.MinimumSize = new System.Drawing.Size(1, 16);
            this.tBCertificate.Name = "tBCertificate";
            this.tBCertificate.ShowText = false;
            this.tBCertificate.Size = new System.Drawing.Size(268, 33);
            this.tBCertificate.TabIndex = 6;
            this.tBCertificate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tBCertificate.Watermark = "";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(161, 80);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(119, 33);
            this.uiLabel4.TabIndex = 5;
            this.uiLabel4.Text = "证书：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormConnectSelect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabControl);
            this.Name = "FormConnectSelect";
            this.Text = "用户登陆";
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 800, 450);
            this.Controls.SetChildIndex(this.TabControl, 0);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.pnlBtm.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox tBuserPassword;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox tBuserName;
        private Sunny.UI.UIButton btn_ZS;
        private Sunny.UI.UITextBox tBzsPassword;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox tBCertificate;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UISymbolButton btn_CertificateLogin;
        private Sunny.UI.UISymbolButton btn_AnonymousLogin;
        private Sunny.UI.UISymbolButton btn_NameLogin;
    }
}