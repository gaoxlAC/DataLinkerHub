using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NengHuan.UserControls
{
    public partial class PTShowBox : UserControl
    {
        List<Data> datas = new List<Data>();
        public PTShowBox()
        {
            InitializeComponent();
            Dianwei.AddColumn("点位", "Column1");
            Dianwei.AddColumn("状态", "Column2");

            Data data = new Data();
            data.Column1 = "风速";
            data.Column2 = "15m/s";
        }

        public class Data
        {
            public string Column1 { get; set; }

            public string Column2 { get; set; }

            public override string ToString()
            {
                return Column1;
            }
        }
    }
}
