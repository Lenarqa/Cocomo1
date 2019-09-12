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
            ResultTM.Text = (Math.Round(TM,0)).ToString() + " календарных месяцев";
        }

        private void SIZEStrok_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label6, "PM (People×Month) – трудоемкость (чел.×мес.)");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label7, "TM (Time at Month) – время разработки в календарных месяцах");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label8, "объем программного продукта в тысячах строк исходного текста (Kilo of Source Line of Code – KSLOC)");

        }
    }
}
