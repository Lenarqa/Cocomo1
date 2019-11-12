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
        String[] ozenkaPromLvl = { "Критически низкий", "Очень низкий", "Низкий", "Средний", "Высокий", "Очень высокий", "Критический" };
        String[] ruseMas = {"Низкий", "Средний", "Высокий", "Очень высокий", "Критический" };
        String[] ruseMas2 = { "Очень низкий", "Низкий", "Средний", "Высокий"};
        double[] EMozenka = new double[7];//для предварительной оценки.
        double[] EmDetalozenka = new double[17];//для детальной;
        double A, B = 0.91, n, SF, EAF = 1, SIZE,E, SFmasRes;
        double[] SFmas = new double[5]; // массив факторов масштаба

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

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox13.SelectedItem.ToString().Equals("Критически низкий"))
            {
                EMozenka[0] = 2.12;
            }
            else if (comboBox13.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EMozenka[0] = 1.62;
            }
            else if (comboBox13.SelectedItem.ToString().Equals("Низкий"))
            {
                EMozenka[0] = 1.26;
            }
            else if (comboBox13.SelectedItem.ToString().Equals("Средний"))
            {
                EMozenka[0] = 1;
            }
            else if (comboBox13.SelectedItem.ToString().Equals("Высокий"))
            {
                EMozenka[0] = 0.83;
            }
            else if (comboBox13.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EMozenka[0] = 0.63;
            }
            else if (comboBox13.SelectedItem.ToString().Equals("Критический"))
            {
                EMozenka[0] = 0.5;
            }
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox14.SelectedItem.ToString().Equals("Критически низкий"))
            {
                EMozenka[1] = 1.59;
            }
            else if (comboBox14.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EMozenka[1] = 1.33;
            }
            else if (comboBox14.SelectedItem.ToString().Equals("Низкий"))
            {
                EMozenka[1] = 1.22;
            }
            else if (comboBox14.SelectedItem.ToString().Equals("Средний"))
            {
                EMozenka[1] = 1;
            }
            else if (comboBox14.SelectedItem.ToString().Equals("Высокий"))
            {
                EMozenka[1] = 0.87;
            }
            else if (comboBox14.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EMozenka[1] = 0.74;
            }
            else if (comboBox14.SelectedItem.ToString().Equals("Критический"))
            {
                EMozenka[1] = 0.62;
            }
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox15.SelectedItem.ToString().Equals("Критически низкий"))
            {
                EMozenka[2] = 0.49;
            }
            else if (comboBox15.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EMozenka[2] = 0.60;
            }
            else if (comboBox15.SelectedItem.ToString().Equals("Низкий"))
            {
                EMozenka[2] = 0.83;
            }
            else if (comboBox15.SelectedItem.ToString().Equals("Средний"))
            {
                EMozenka[2] = 1;
            }
            else if (comboBox15.SelectedItem.ToString().Equals("Высокий"))
            {
                EMozenka[2] = 1.33;
            }
            else if (comboBox15.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EMozenka[2] = 1.91;
            }
            else if (comboBox15.SelectedItem.ToString().Equals("Критический"))
            {
                EMozenka[2] = 2.72;
            }
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)//Разработка повторного использования
        {
            if (comboBox16.SelectedItem.ToString().Equals("Низкий"))
            {
                EMozenka[3] = 0.95;
            }
            else if (comboBox16.SelectedItem.ToString().Equals("Средний"))
            {
                EMozenka[3] = 1;
            }
            else if (comboBox16.SelectedItem.ToString().Equals("Высокий"))
            {
                EMozenka[3] = 1.07;
            }
            else if (comboBox16.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EMozenka[3] = 1.15;
            }
            else if (comboBox16.SelectedItem.ToString().Equals("Критический"))
            {
                EMozenka[3] = 1.24;
            }
        }

        

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)//сложность платформы разработки.
        {
            if (comboBox17.SelectedItem.ToString().Equals("Низкий"))
            {
                EMozenka[4] = 0.87;
            }
            else if (comboBox17.SelectedItem.ToString().Equals("Средний"))
            {
                EMozenka[4] = 1;
            }
            else if (comboBox17.SelectedItem.ToString().Equals("Высокий"))
            {
                EMozenka[4] = 1.29;
            }
            else if (comboBox17.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EMozenka[4] = 1.81;
            }
            else if (comboBox17.SelectedItem.ToString().Equals("Критический"))
            {
                EMozenka[4] = 2.61;
            }
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)//оборудование.
        {
            if (comboBox18.SelectedItem.ToString().Equals("Критически низкий"))
            {
                EMozenka[5] = 1.43;
            }
            else if (comboBox18.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EMozenka[5] = 1.30;
            }
            else if (comboBox18.SelectedItem.ToString().Equals("Низкий"))
            {
                EMozenka[5] = 1.10;
            }
            else if (comboBox18.SelectedItem.ToString().Equals("Средний"))
            {
                EMozenka[5] = 1;
            }
            else if (comboBox18.SelectedItem.ToString().Equals("Высокий"))
            {
                EMozenka[5] = 0.87;
            }
            else if (comboBox18.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EMozenka[5] = 0.73;
            }
            else if (comboBox18.SelectedItem.ToString().Equals("Критический"))
            {
                EMozenka[5] = 0.62;
            }
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)//требуемое выполнение графика работ
        {
            if (comboBox19.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EMozenka[6] = 1.43;
            }
            else if (comboBox19.SelectedItem.ToString().Equals("Низкий"))
            {
                EMozenka[6] = 1.14;
            }
            else if (comboBox19.SelectedItem.ToString().Equals("Средний"))
            {
                EMozenka[6] = 1;
            }
            else if (comboBox19.SelectedItem.ToString().Equals("Высокий"))
            {
                EMozenka[6] = 1;
            }
        }

        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox20.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EmDetalozenka[0] = 1.42;
            }
            else if (comboBox20.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[0] = 1.29;
            }
            else if (comboBox20.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[0] = 1;
            }
            else if (comboBox20.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[0] = 0.85;
            }
            else if (comboBox20.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[0] = 0.71;
            }
        }

        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)//Опыт разработки приложения
        {
            if (comboBox21.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EmDetalozenka[1] = 1.22;
            }
            else if (comboBox21.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[1] = 1.10;
            }
            else if (comboBox21.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[1] = 1;
            }
            else if (comboBox21.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[1] = 0.88;
            }
            else if (comboBox21.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[1] = 0.81;
            }
        }

        

        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)//Возможности программиста
        {
            if (comboBox22.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EmDetalozenka[2] = 1.34;
            }
            else if (comboBox22.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[2] = 1.15;
            }
            else if (comboBox22.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[2] = 1;
            }
            else if (comboBox22.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[2] = 0.88;
            }
            else if (comboBox22.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[2] = 0.76;
            }
        }

       

        private void comboBox23_SelectedIndexChanged(object sender, EventArgs e)//Продолжительность работы
        {
            if (comboBox23.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EmDetalozenka[3] = 1.29;
            }
            else if (comboBox23.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[3] = 1.12;
            }
            else if (comboBox23.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[3] = 1;
            }
            else if (comboBox23.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[3] = 0.90;
            }
            else if (comboBox23.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[3] = 0.81;
            }
        }

        private void comboBox24_SelectedIndexChanged(object sender, EventArgs e)//Опыт работы с платформой
        {
            if (comboBox24.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EmDetalozenka[4] = 1.19;
            }
            else if (comboBox24.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[4] = 1.09;
            }
            else if (comboBox24.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[4] = 1;
            }
            else if (comboBox24.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[4] = 0.91;
            }
            else if (comboBox24.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[4] = 0.85;
            }
        }

        private void comboBox25_SelectedIndexChanged(object sender, EventArgs e)//опыт использования языка
        {
            if (comboBox25.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EmDetalozenka[5] = 1.20;
            }
            else if (comboBox25.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[5] = 1.09;
            }
            else if (comboBox25.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[5] = 1;
            }
            else if (comboBox25.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[5] = 0.91;
            }
            else if (comboBox25.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[5] = 0.84;
            }
        }

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
            comboBox13.Items.AddRange(ozenkaPromLvl);
            comboBox14.Items.AddRange(ozenkaPromLvl);
            comboBox15.Items.AddRange(ozenkaPromLvl);
            comboBox16.Items.AddRange(ruseMas);
            comboBox17.Items.AddRange(ruseMas);
            comboBox18.Items.AddRange(ozenkaPromLvl);
            comboBox19.Items.AddRange(ruseMas2);
            comboBox20.Items.AddRange(SFozenka);
            comboBox21.Items.AddRange(SFozenka);
            comboBox22.Items.AddRange(SFozenka);
            comboBox23.Items.AddRange(SFozenka);
            comboBox24.Items.AddRange(SFozenka);
            comboBox25.Items.AddRange(SFozenka);

            comboBox12.SelectedItem = "Предварительная";
            comboBox7.SelectedItem = "Средний";
            comboBox8.SelectedItem = "Средний";
            comboBox9.SelectedItem = "Средний";
            comboBox10.SelectedItem = "Средний";
            comboBox11.SelectedItem = "Средний";
            comboBox13.SelectedItem = "Средний";
            comboBox14.SelectedItem = "Средний";
            comboBox15.SelectedItem = "Средний";
            comboBox16.SelectedItem = "Средний";
            comboBox17.SelectedItem = "Средний";
            comboBox18.SelectedItem = "Средний";
            comboBox19.SelectedItem = "Средний";
            comboBox20.SelectedItem = "Средний";
            comboBox21.SelectedItem = "Средний";
            comboBox22.SelectedItem = "Средний";
            comboBox23.SelectedItem = "Средний";
            comboBox24.SelectedItem = "Средний";
            comboBox25.SelectedItem = "Средний";
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox12.SelectedItem.Equals("Предварительная"))
            {
                groupBox3.Visible = true;
                groupBox4.Visible = false;
                A = 2.97;
                n = 7;
            }
            else if (comboBox12.SelectedItem.Equals("Детальная"))
            {
                groupBox3.Visible = false;
                groupBox4.Visible = true;
                A = 2.45;
                n = 17;
            }
        }

        private void button2_Click(object sender, EventArgs e) // рассчитать EAF
        {
            if (comboBox12.SelectedItem.Equals("Предварительная"))
            {
                n = 7;
            }
            else if (comboBox12.SelectedItem.Equals("Детальная"))
            {
                n = 17;
            }

            for (int i = 0; i < n; i++)
            {
                EAF *= EMozenka[i];
            }

            label19.Text = "EAF = " + (Math.Round(EAF, 3)).ToString();
            EAF = 1;
        }

        private void button1_Click(object sender, EventArgs e)//рассчет pm tm
        {
            if (SIZEStrok.Text != String.Empty)
            {
                SIZE = Double.Parse(SIZEStrok.Text);

                for (int i = 0; i < 5; i++)
                {
                    SFmasRes += SFmas[i];
                }

                E = B + 0.01 * SFmasRes;

                if (comboBox12.SelectedItem.Equals("Предварительная"))
                {
                    A = 2.97;
                    n = 7;

                    for (int i = 0; i < 7; i++)
                    {
                        EAF *= EMozenka[i];
                    }

                    double resPM;
                    resPM = EAF * A * Math.Pow(SIZE,E);

                    ResultPM.Text = (Math.Round(resPM, 0)).ToString() + " чел. × мес. ";
                    EAF = 1;
                    // ResultTM.Text = (Math.Round(TM, 0)).ToString() + " календарных месяцев";
                }
                else if (comboBox12.SelectedItem.Equals("Детальная"))
                {
                    A = 2.45;
                    n = 17;
                }

            }
            else
            {
                MessageBox.Show("Укажите объем программного продукта в тыс.,строк кода!");
            }
            
        }

    }
}
