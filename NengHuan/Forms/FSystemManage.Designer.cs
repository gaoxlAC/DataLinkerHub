namespace NengHuan.Forms
{
    partial class FSystemManage
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
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiLine2 = new Sunny.UI.UILine();
            this.btn_GoConnect = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiLine3 = new Sunny.UI.UILine();
            this.btn_ServerConnect = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(0, 23);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(798, 29);
            this.uiLine1.TabIndex = 0;
            this.uiLine1.Text = "数据库管理";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine1.Click += new System.EventHandler(this.uiLine1_Click);
            // 
            // uiLine2
            // 
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.Location = new System.Drawing.Point(0, 287);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(798, 29);
            this.uiLine2.TabIndex = 1;
            this.uiLine2.Text = "用户管理";
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_GoConnect
            // 
            this.btn_GoConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_GoConnect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GoConnect.Location = new System.Drawing.Point(74, 85);
            this.btn_GoConnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_GoConnect.Name = "btn_GoConnect";
            this.btn_GoConnect.Size = new System.Drawing.Size(100, 35);
            this.btn_GoConnect.TabIndex = 2;
            this.btn_GoConnect.Text = "连接";
            this.btn_GoConnect.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GoConnect.Click += new System.EventHandler(this.btn_GoConnect_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(74, 352);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(100, 35);
            this.uiButton2.TabIndex = 3;
            this.uiButton2.Text = "编辑";
            this.uiButton2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiLine3
            // 
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine3.Location = new System.Drawing.Point(0, 146);
            this.uiLine3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(798, 29);
            this.uiLine3.TabIndex = 4;
            this.uiLine3.Text = "服务器管理";
            this.uiLine3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_ServerConnect
            // 
            this.btn_ServerConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ServerConnect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ServerConnect.Location = new System.Drawing.Point(74, 215);
            this.btn_ServerConnect.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ServerConnect.Name = "btn_ServerConnect";
            this.btn_ServerConnect.Size = new System.Drawing.Size(100, 35);
            this.btn_ServerConnect.TabIndex = 5;
            this.btn_ServerConnect.Text = "连接";
            this.btn_ServerConnect.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ServerConnect.Click += new System.EventHandler(this.btn_ServerConnect_Click);
            // 
            // FSystemManage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_ServerConnect);
            this.Controls.Add(this.uiLine3);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.btn_GoConnect);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.uiLine1);
            this.Name = "FSystemManage";
            this.Text = "FSystemManage";
            this.Initialize += new System.EventHandler(this.FSystemManage_Initialize);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UIButton btn_GoConnect;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UIButton btn_ServerConnect;
    }
}