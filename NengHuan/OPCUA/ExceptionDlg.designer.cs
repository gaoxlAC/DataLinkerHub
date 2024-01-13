
namespace NengHuan.OPCUA
{
    partial class ExceptionDlg
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShowStackTracesCK = new System.Windows.Forms.CheckBox();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.ExceptionBrowser = new System.Windows.Forms.WebBrowser();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CloseBTN);
            this.panel1.Controls.Add(this.ShowStackTracesCK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 27);
            this.panel1.TabIndex = 0;
            // 
            // ShowStackTracesCK
            // 
            this.ShowStackTracesCK.AutoSize = true;
            this.ShowStackTracesCK.Location = new System.Drawing.Point(4, 6);
            this.ShowStackTracesCK.Name = "ShowStackTracesCK";
            this.ShowStackTracesCK.Size = new System.Drawing.Size(156, 16);
            this.ShowStackTracesCK.TabIndex = 0;
            this.ShowStackTracesCK.Text = "Show Exception Details";
            this.ShowStackTracesCK.UseVisualStyleBackColor = true;
            // 
            // CloseBTN
            // 
            this.CloseBTN.Location = new System.Drawing.Point(362, 3);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(75, 23);
            this.CloseBTN.TabIndex = 1;
            this.CloseBTN.Text = "Close";
            this.CloseBTN.UseVisualStyleBackColor = true;
            // 
            // ExceptionBrowser
            // 
            this.ExceptionBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExceptionBrowser.Location = new System.Drawing.Point(0, 0);
            this.ExceptionBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.ExceptionBrowser.Name = "ExceptionBrowser";
            this.ExceptionBrowser.Size = new System.Drawing.Size(780, 167);
            this.ExceptionBrowser.TabIndex = 1;
            // 
            // ExceptionDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 194);
            this.Controls.Add(this.ExceptionBrowser);
            this.Controls.Add(this.panel1);
            this.Name = "ExceptionDlg";
            this.Text = "ExceptionDlg";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ShowStackTracesCK;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.WebBrowser ExceptionBrowser;
    }
}