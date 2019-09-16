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
    public partial class cocomo2 : Form
    {
        String[] stadii = { "Предварительная", "Детальная" };
        String[] SFozenka = { "Очень низкий", "Низкий", "Средний", "Высокий", "Очень высокий" };
        double A, B = 0.91, n, SF, EAF;

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedItem.ToString().Equals("Очень низкий"))
            {
                SFmas[1] = 5.07;
            }
            else if (comboBox8.SelectedItem.ToString().Equals("Низкий"))
            {
                SFmas[1] = 4.05;
            }
            else if (comboBox8.SelectedItem.ToString().Equals("Средний"))
            {
                SFmas[1] = 3.04;
            }
            else if (comboBox8.SelectedItem.ToString().Equals("Высокий"))
            {
                SFmas[1] = 2.03;
            }
            else if (comboBox8.SelectedItem.ToString().Equals("Очень высокий"))
            {
                SFmas[1] = 1.01;
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.SelectedItem.ToString().Equals("Очень низкий"))
            {
                SFmas[2] = 7.07;
            }
            else if (comboBox9.SelectedItem.ToString().Equals("Низкий"))
            {
                SFmas[2] = 5.65;
            }
            else if (comboBox9.SelectedItem.ToString().Equals("Средний"))
            {
                SFmas[2] = 4.24;
            }
            else if (comboBox9.SelectedItem.ToString().Equals("Высокий"))
            {
                SFmas[2] = 2.83;
            }
            else if (comboBox9.SelectedItem.ToString().Equals("Очень высокий"))
            {
                SFmas[2] = 1.41;
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.SelectedItem.ToString().Equals("Очень низкий"))
            {
                SFmas[3] = 5.58;
            }
            else if (comboBox10.SelectedItem.ToString().Equals("Низкий"))
            {
                SFmas[3] = 4.38;
            }
            else if (comboBox10.SelectedItem.ToString().Equals("Средний"))
            {
                SFmas[3] = 3.29;
            }
            else if (comboBox10.SelectedItem.ToString().Equals("Высокий"))
            {
                SFmas[3] = 2.19;
            }
            else if (comboBox10.SelectedItem.ToString().Equals("Очень высокий"))
            {
                SFmas[3] = 1.10;
            }
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.SelectedItem.ToString().Equals("Очень низкий"))
            {
                SFmas[4] = 7.80;
            }
            else if (comboBox11.SelectedItem.ToString().Equals("Низкий"))
            {
                SFmas[4] = 6.24;
            }
            else if (comboBox11.SelectedItem.ToString().Equals("Средний"))
            {
                SFmas[4] = 4.68;
            }
            else if (comboBox11.SelectedItem.ToString().Equals("Высокий"))
            {
                SFmas[4] = 3.12;
            }
            else if (comboBox11.SelectedItem.ToString().Equals("Очень высокий"))
            {
                SFmas[4] = 1.56;
            }
        }

        double[] SFmas = new double[5];

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedItem.ToString().Equals("Очень низкий"))
            {
                SFmas[0] = 6.20;
            }
            else if (comboBox7.SelectedItem.ToString().Equals("Низкий"))
            {
                SFmas[0] = 4.96;
            }
            else if (comboBox7.SelectedItem.ToString().Equals("Средний"))
            {
                SFmas[0] = 3.72;
            }
            else if (comboBox7.SelectedItem.ToString().Equals("Высокий"))
            {
                SFmas[0] = 2.48;
            }
            else if (comboBox7.SelectedItem.ToString().Equals("Очень высокий"))
            {
                SFmas[0] = 1.24;
            }
        }

        

        public cocomo2()
        {
            InitializeComponent();
            comboBox12.Items.AddRange(stadii);
            comboBox7.Items.AddRange(SFozenka);
            comboBox8.Items.AddRange(SFozenka);
            comboBox9.Items.AddRange(SFozenka);
            comboBox10.Items.AddRange(SFozenka);
            comboBox11.Items.AddRange(SFozenka);
            comboBox12.SelectedItem = "Предварительная";
            comboBox7.SelectedItem = "Средний";
            comboBox8.SelectedItem = "Средний";
            comboBox9.SelectedItem = "Средний";
            comboBox10.SelectedItem = "Средний";
            comboBox11.SelectedItem = "Средний";
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox12.SelectedItem.Equals("Предварительная"))
            {
                A = 2.97;
                n = 7;
            }
            else if (comboBox12.SelectedItem.Equals("Детальная"))
            {
                A = 2.45;
                n = 17;
            }
        }
    }
}
