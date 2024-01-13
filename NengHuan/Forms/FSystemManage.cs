using NengHuan.Forms.Common;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NengHuan.Forms
{
    public partial class FSystemManage : UIPage
    {
        public FSystemManage()
        {
            InitializeComponent();
        }

        private void uiLine1_Click(object sender, EventArgs e)
        {

        }

        private void btn_GoConnect_Click(object sender, EventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            setupForm.ShowDialog();
        }

        private void btn_ServerConnect_Click(object sender, EventArgs e)
        {
            ServerForm serverForm = new ServerForm();
            serverForm.ShowDialog();
        }

        private void FSystemManage_Initialize(object sender, EventArgs e)
        {

        }
    }
}
