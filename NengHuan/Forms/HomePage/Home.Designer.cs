namespace NengHuan.Forms.HomePage
{
    partial class Home
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
            this.SysName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SysName
            // 
            this.SysName.AutoSize = true;
            this.SysName.Font = new System.Drawing.Font("华文行楷", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SysName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.SysName.Location = new System.Drawing.Point(-3, 131);
            this.SysName.Name = "SysName";
            this.SysName.Size = new System.Drawing.Size(1253, 126);
            this.SysName.TabIndex = 2;
            this.SysName.Text = "能环监测数据采集系统";
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1414, 450);
            this.Controls.Add(this.SysName);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SysName;
    }
}