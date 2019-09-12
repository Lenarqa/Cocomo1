using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COCOMO
{
    public partial class RasprMetod : Form
    {
        public RasprMetod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double PM, TM, a, b, c, d, SIZE1;
            a = 2.4;
            b = 1.05;
            c = 2.5;
            d = 0.38;
            SIZE1 = Double.Parse(SIZEStrok.Text);
            PM = a * Math.Pow(SIZE1, b);
            TM = c * Math.Pow(PM, d);
            ResultPM.Text = (Math.Round(PM,0)).ToString() + " чел. × мес. ";
            ResultTM.Text = (Math.Round(TM,0)).ToString() + " колендарных месяцев";
        }
    }
}
