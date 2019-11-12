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
    public partial class promezh : Form
    {

        double a, b, g, d, k = 1;
        double[] z = new double[15];
        

        public promezh()
        {
            for (int i = 0; i < 15; i++)
            {
                z[i] = 1;
            }
            InitializeComponent();
            String[] mas = { "Распространенный", "Полунезависимый", "Встроенный" };
            String[] mas2 = { "Очень низкий", "Низкий", "Средний", "Высокий", "Очень высокий", "Критический" };
            String[] mas3 = { "Очень низкий", "Низкий", "Средний", "Высокий", "Очень высокий"};
            String[] mas4 = { "Низкий", "Средний", "Высокий", "Очень высокий"};
            String[] mas5 = { "Средний", "Высокий", "Очень высокий", "Критический" };
            String[] mas6 = { "Очень низкий", "Низкий", "Средний", "Высокий" };
            comboBox1.Items.AddRange(mas);
            comboBox2.Items.AddRange(mas3);
            comboBox3.Items.AddRange(mas4);
            comboBox4.Items.AddRange(mas5);
            comboBox5.Items.AddRange(mas5);
            comboBox6.Items.AddRange(mas2);
            comboBox7.Items.AddRange(mas3);
            comboBox8.Items.AddRange(mas4);
            comboBox9.Items.AddRange(mas4);
            comboBox10.Items.AddRange(mas3);
            comboBox11.Items.AddRange(mas3);
            comboBox12.Items.AddRange(mas6);
            comboBox13.Items.AddRange(mas6);
            comboBox14.Items.AddRange(mas3);
            comboBox15.Items.AddRange(mas3);
            comboBox16.Items.AddRange(mas3);
            comboBox1.SelectedItem = "Распространенный";
            comboBox2.SelectedItem = "Средний";
            comboBox3.SelectedItem = "Средний";
            comboBox4.SelectedItem = "Средний";
            comboBox5.SelectedItem = "Средний";
            comboBox6.SelectedItem = "Средний";
            comboBox7.SelectedItem = "Средний";
            comboBox8.SelectedItem = "Средний";
            comboBox9.SelectedItem = "Средний";
            comboBox10.SelectedItem = "Средний";
            comboBox11.SelectedItem = "Средний";
            comboBox12.SelectedItem = "Средний";
            comboBox13.SelectedItem = "Средний";
            comboBox14.SelectedItem = "Средний";
            comboBox15.SelectedItem = "Средний";
            comboBox16.SelectedItem = "Средний";
            label19.Text = "K = " + k;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double SIZE1, PM, TM;

            k = 1;
            for (int i = 0; i < 15; i++)
            {
                k *= z[i];
            }

            if (textBox1.Text != String.Empty)
            {
                SIZE1 = Double.Parse(textBox1.Text);
                PM = k* a * Math.Pow(SIZE1, b);
                ResultPM.Text = (Math.Round(PM, 3)).ToString() + " чел. × мес. ";
                TM = g * Math.Pow(PM, d);
                ResultTM.Text = (Math.Round(TM, 3)).ToString() + " календарных месяцев";
            }
            else
            {
                MessageBox.Show("Укажите объем программного продукта в тыс.,строк кода!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            k = 1;
            for (int i = 0; i < 15; i++)
            {
                k *= z[i];
            }
            label19.Text = "EAF = " + k;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString().Equals("Низкий"))
            {
                z[1] = 0.94;
            }
            else if (comboBox3.SelectedItem.ToString().Equals("Средний"))
            {
                z[1] = 1;
            }
            else if (comboBox3.SelectedItem.ToString().Equals("Высокий"))
            {
                z[1] = 1.08;
            }
            else if (comboBox3.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[1] = 1.16;
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedItem.ToString().Equals("Очень низкий"))
            {
                z[2] = 0.70;
            }
            else if (comboBox6.SelectedItem.ToString().Equals("Низкий"))
            {
                z[2] = 0.85;
            }
            else if (comboBox6.SelectedItem.ToString().Equals("Средний"))
            {
                z[2] = 1;
            }
            else if (comboBox6.SelectedItem.ToString().Equals("Высокий"))
            {
                z[2] = 1.15;
            }
            else if (comboBox6.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[2] = 1.30;
            }
            else if (comboBox6.SelectedItem.ToString().Equals("Критический"))
            {
                z[2] = 1.65;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem.ToString().Equals("Средний"))
            {
                z[3] = 1;
            }
            else if (comboBox5.SelectedItem.ToString().Equals("Высокий"))
            {
                z[3] = 1.11;
            }
            else if (comboBox5.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[3] = 1.30;
            }
            else if (comboBox5.SelectedItem.ToString().Equals("Критический"))
            {
                z[3] = 1.66;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString().Equals("Средний"))
            {
                z[4] = 1;
            }
            else if (comboBox4.SelectedItem.ToString().Equals("Высокий"))
            {
                z[4] = 1.06;
            }
            else if (comboBox4.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[4] = 1.21;
            }
            else if (comboBox4.SelectedItem.ToString().Equals("Критический"))
            {
                z[4] = 1.56;
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.SelectedItem.ToString().Equals("Низкий"))
            {
                z[5] = 0.85;
            }
            else if (comboBox9.SelectedItem.ToString().Equals("Средний"))
            {
                z[5] = 1;
            }
            else if (comboBox9.SelectedItem.ToString().Equals("Высокий"))
            {
                z[5] = 1.15;
            }
            else if (comboBox9.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[5] = 1.30;
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedItem.ToString().Equals("Низкий"))
            {
                z[6] = 0.85;
            }
            else if (comboBox8.SelectedItem.ToString().Equals("Средний"))
            {
                z[6] = 1;
            }
            else if (comboBox8.SelectedItem.ToString().Equals("Высокий"))
            {
                z[6] = 1.07;
            }
            else if (comboBox8.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[6] = 1.15;
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedItem.ToString().Equals("Очень низкий"))
            {
                z[7] = 1.46;
            }
            else if (comboBox7.SelectedItem.ToString().Equals("Низкий"))
            {
                z[7] = 1.19;
            }
            else if (comboBox7.SelectedItem.ToString().Equals("Средний"))
            {
                z[7] = 1;
            }
            else if (comboBox7.SelectedItem.ToString().Equals("Высокий"))
            {
                z[7] = 0.86;
            }
            else if (comboBox7.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[7] = 0.71;
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.SelectedItem.ToString().Equals("Очень низкий"))
            {
                z[8] = 1.29;
            }
            else if (comboBox10.SelectedItem.ToString().Equals("Низкий"))
            {
                z[8] = 1.13;
            }
            else if (comboBox10.SelectedItem.ToString().Equals("Средний"))
            {
                z[8] = 1;
            }
            else if (comboBox10.SelectedItem.ToString().Equals("Высокий"))
            {
                z[8] = 0.91;
            }
            else if (comboBox10.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[8] = 0.82;
            }
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.SelectedItem.ToString().Equals("Очень низкий"))
            {
                z[9] = 1.42;
            }
            else if (comboBox11.SelectedItem.ToString().Equals("Низкий"))
            {
                z[9] = 1.17;
            }
            else if (comboBox11.SelectedItem.ToString().Equals("Средний"))
            {
                z[9] = 1;
            }
            else if (comboBox11.SelectedItem.ToString().Equals("Высокий"))
            {
                z[9] = 0.86;
            }
            else if (comboBox11.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[9] = 0.70;
            }
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox12.SelectedItem.ToString().Equals("Очень низкий"))
            {
                z[10] = 1.21;
            }
            else if (comboBox12.SelectedItem.ToString().Equals("Низкий"))
            {
                z[10] = 1.10;
            }
            else if (comboBox12.SelectedItem.ToString().Equals("Средний"))
            {
                z[10] = 1;
            }
            else if (comboBox12.SelectedItem.ToString().Equals("Высокий"))
            {
                z[10] = 0.90;
            }
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox13.SelectedItem.ToString().Equals("Очень низкий"))
            {
                z[11] = 1.14;
            }
            else if (comboBox13.SelectedItem.ToString().Equals("Низкий"))
            {
                z[11] = 1.07;
            }
            else if (comboBox13.SelectedItem.ToString().Equals("Средний"))
            {
                z[11] = 1;
            }
            else if (comboBox13.SelectedItem.ToString().Equals("Высокий"))
            {
                z[11] = 0.95;
            }
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox14.SelectedItem.ToString().Equals("Очень низкий"))
            {
                z[12] = 1.24;
            }
            else if (comboBox14.SelectedItem.ToString().Equals("Низкий"))
            {
                z[12] = 1.10;
            }
            else if (comboBox14.SelectedItem.ToString().Equals("Средний"))
            {
                z[12] = 1;
            }
            else if (comboBox14.SelectedItem.ToString().Equals("Высокий"))
            {
                z[12] = 0.91;
            }
            else if (comboBox14.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[12] = 0.82;
            }
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox15.SelectedItem.ToString().Equals("Очень низкий"))
            {
                z[13] = 1.24;
            }
            else if (comboBox15.SelectedItem.ToString().Equals("Низкий"))
            {
                z[13] = 1.10;
            }
            else if (comboBox15.SelectedItem.ToString().Equals("Средний"))
            {
                z[13] = 1;
            }
            else if (comboBox15.SelectedItem.ToString().Equals("Высокий"))
            {
                z[13] = 0.91;
            }
            else if (comboBox15.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[13] = 0.83;
            }
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox16.SelectedItem.ToString().Equals("Очень низкий"))
            {
                z[14] = 1.23;
            }
            else if (comboBox16.SelectedItem.ToString().Equals("Низкий"))
            {
                z[14] = 1.08;
            }
            else if (comboBox16.SelectedItem.ToString().Equals("Средний"))
            {
                z[14] = 1;
            }
            else if (comboBox16.SelectedItem.ToString().Equals("Высокий"))
            {
                z[14] = 1.04;
            }
            else if (comboBox16.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[14] = 1.10;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }*/
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == ',' || c == '\b');
        }

        private void label37_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label37, "объем программного продукта в тысячах строк исходного текста (Kilo of Source Line of Code – KSLOC)");
        }

        private void label38_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label38, "PM – трудоемкость(чел.× мес.)");
            
        }

        private void label22_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label22, "TM (Time at Month) – время разработки в календарных месяцах; ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu form2 = new Menu();
            this.Hide();
            form2.ShowDialog();
            this.Show();
            Close();
        }

        private void label39_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label39, "EAF(Effort Adjustment Factor) – произведение выбранных атрибутов стоимости.");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label4, "На этом уровне базовая модель уточнена за счет ввода дополнительных 15 «атрибутов стоимости» (или факторов затрат) Cost Drivers (CDk), которые представлены ниже.");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString().Equals("Очень низкий"))
            {
                z[0] = 0.75;   
            }
            else if (comboBox2.SelectedItem.ToString().Equals("Низкий"))
            {
                z[0] = 0.88;
            }
            else if (comboBox2.SelectedItem.ToString().Equals("Средний"))
            {
                z[0] = 1;
            }
            else if (comboBox2.SelectedItem.ToString().Equals("Высокий"))
            {
                z[0] = 1.15;
            }
            else if (comboBox2.SelectedItem.ToString().Equals("Очень высокий"))
            {
                z[0] = 1.40;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString().Equals("Распространенный"))
            {
                a = 3.2;
                b = 1.05;
                g = 2.5;
                d = 0.38;
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Полунезависимый"))
            {
                a = 3.0;
                b = 1.12;
                g = 2.5;
                d = 0.35;
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Встроенный"))
            {
                a = 2.8;
                b = 1.20;
                g = 2.5;
                d = 0.32;
            }
        }


    }
}
