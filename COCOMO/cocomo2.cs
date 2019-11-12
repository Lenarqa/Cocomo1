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
        String[] SFozenka2 = { "Низкий", "Средний", "Высокий", "Очень высокий" };
        String[] ozenkaPromLvl = { "Критически низкий", "Очень низкий", "Низкий", "Средний", "Высокий", "Очень высокий", "Критический" };
        String[] ruseMas = { "Низкий", "Средний", "Высокий", "Очень высокий", "Критический" };
        String[] ruseMas3 = { "Очень низкий", "Низкий", "Средний", "Высокий", "Очень высокий", "Критический" };
        String[] ruseMas4 = { "Средний", "Высокий", "Очень высокий", "Критический" };
        String[] ruseMas2 = { "Очень низкий", "Низкий", "Средний", "Высокий"};
        double[] EMozenka = new double[7];//для предварительной оценки.
        double[] EmDetalozenka = new double[17];//для детальной;
        double A, B = 0.91, n, SF, EAF = 1, SIZE, E, SFmasRes;
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

 

        private void comboBox26_SelectedIndexChanged(object sender, EventArgs e) //требуемая надежность программы
        {
            if (comboBox26.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EmDetalozenka[6] = 0.84;
            }
            else if (comboBox26.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[6] = 0.92;
            }
            else if (comboBox26.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[6] = 1;
            }
            else if (comboBox26.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[6] = 1.10;
            }
            else if (comboBox26.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[6] = 1.26;
            }
        }

        
        private void comboBox27_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox27.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[7] = 0.23;
            }
            else if (comboBox27.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[7] = 1;
            }
            else if (comboBox27.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[7] = 1.14;
            }
            else if (comboBox27.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[7] = 1.28;
            }
        }

        

        private void comboBox28_SelectedIndexChanged(object sender, EventArgs e)//сложность программы
        {
            if (comboBox28.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EmDetalozenka[8] = 0.73;
            }
            else if (comboBox28.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[8] = 0.87;
            }
            else if (comboBox28.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[8] = 1;
            }
            else if (comboBox28.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[8] = 1.17;
            }
            else if (comboBox28.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[8] = 1.34;
            }
            else if (comboBox28.SelectedItem.ToString().Equals("Критический"))
            {
                EmDetalozenka[8] = 1.74;
            }
        }

       

        private void comboBox29_SelectedIndexChanged(object sender, EventArgs e)//Возможность реиспользования
        {
            if (comboBox29.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[9] = 0.95;
            }
            else if (comboBox29.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[9] = 1;
            }
            else if (comboBox29.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[9] = 1.07;
            }
            else if (comboBox29.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[9] = 1.15;
            }
            else if (comboBox29.SelectedItem.ToString().Equals("Критический"))
            {
                EmDetalozenka[9] = 1.24;
            }
        }

        

        private void comboBox30_SelectedIndexChanged(object sender, EventArgs e)//соответствие документации
        {
            if (comboBox30.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EmDetalozenka[10] = 0.81;
            }
            else if (comboBox30.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[10] = 0.91;
            }
            else if (comboBox30.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[10] = 1;
            }
            else if (comboBox30.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[10] = 1.11;
            }
            else if (comboBox30.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[10] = 1.23;
            }
        }

       

        private void comboBox31_SelectedIndexChanged(object sender, EventArgs e)//ограничение по времени
        {
            if (comboBox31.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[11] = 1;
            }
            else if (comboBox31.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[11] = 1.11;
            }
            else if (comboBox31.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[11] = 1.29;
            }
            else if (comboBox31.SelectedItem.ToString().Equals("Критический"))
            {
                EmDetalozenka[11] = 1.63;
            }
        }

        

        private void comboBox32_SelectedIndexChanged(object sender, EventArgs e)//Ограничение памяти
        {
            if (comboBox32.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[12] = 1;
            }
            else if (comboBox32.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[12] = 1.05;
            }
            else if (comboBox32.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[12] = 1.17;
            }
            else if (comboBox32.SelectedItem.ToString().Equals("Критический"))
            {
                EmDetalozenka[12] = 1.46;
            }
        }


        private void comboBox33_SelectedIndexChanged(object sender, EventArgs e)//изменение платформы
        {
            if (comboBox33.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[13] = 0.87;
            }
            else if (comboBox33.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[13] = 1;
            }
            else if (comboBox33.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[13] = 1.15;
            }
            else if (comboBox33.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[13] = 1.30;
            }
        }


        private void comboBox34_SelectedIndexChanged(object sender, EventArgs e)//Использование ПС
        {
            if (comboBox34.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EmDetalozenka[14] = 1.17;
            }
            else if (comboBox34.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[14] = 1.09;
            }
            else if (comboBox34.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[14] = 1;
            }
            else if (comboBox34.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[14] = 0.90;
            }
            else if (comboBox34.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[14] = 0.78;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu form2 = new Menu();
            this.Hide();
            form2.ShowDialog();
            this.Show();
            Close();
        }

        private void label38_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label6, "PM (People×Month) – трудоемкость (чел.×мес.)");
        }

        private void label22_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label7, "TM (Time at Month) – время разработки в календарных месяцах");
        }

        private void label37_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label8, "объем программного продукта в тысячах строк исходного текста (Kilo of Source Line of Code – KSLOC)");
        }

        private void label39_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label39, "EAF(Effort Adjustment Factor) – произведение выбранных атрибутов стоимости.");
        }

        private void SIZEStrok_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !(char.IsDigit(c) || c == ',' || c == '\b');
        }



        private void comboBox35_SelectedIndexChanged(object sender, EventArgs e)//многоабанентская разработка
        {
            if (comboBox35.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EmDetalozenka[15] = 1.22;
            }
            else if (comboBox35.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[15] = 1.09;
            }
            else if (comboBox35.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[15] = 1;
            }
            else if (comboBox35.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[15] = 0.93;
            }
            else if (comboBox35.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[15] = 0.86;
            }
            else if (comboBox35.SelectedItem.ToString().Equals("Критический"))
            {
                EmDetalozenka[15] = 0.80;
            }
        }

        private void comboBox36_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox36.SelectedItem.ToString().Equals("Очень низкий"))
            {
                EmDetalozenka[16] = 1.43;
            }
            else if (comboBox36.SelectedItem.ToString().Equals("Низкий"))
            {
                EmDetalozenka[16] = 1.14;
            }
            else if (comboBox36.SelectedItem.ToString().Equals("Средний"))
            {
                EmDetalozenka[16] = 1;
            }
            else if (comboBox36.SelectedItem.ToString().Equals("Высокий"))
            {
                EmDetalozenka[16] = 1;
            }
            else if (comboBox36.SelectedItem.ToString().Equals("Очень высокий"))
            {
                EmDetalozenka[16] = 1;
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
            comboBox26.Items.AddRange(SFozenka);
            comboBox27.Items.AddRange(SFozenka2);
            comboBox28.Items.AddRange(ruseMas3);
            comboBox29.Items.AddRange(ruseMas);
            comboBox30.Items.AddRange(SFozenka);
            comboBox31.Items.AddRange(ruseMas4);
            comboBox32.Items.AddRange(ruseMas4);
            comboBox33.Items.AddRange(SFozenka2);
            comboBox34.Items.AddRange(SFozenka);
            comboBox35.Items.AddRange(ruseMas3);
            comboBox36.Items.AddRange(SFozenka);


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
            comboBox26.SelectedItem = "Средний";
            comboBox27.SelectedItem = "Средний";
            comboBox28.SelectedItem = "Средний";
            comboBox29.SelectedItem = "Средний";
            comboBox30.SelectedItem = "Средний";
            comboBox31.SelectedItem = "Средний";
            comboBox32.SelectedItem = "Средний";
            comboBox33.SelectedItem = "Средний";
            comboBox34.SelectedItem = "Средний";
            comboBox35.SelectedItem = "Средний";
            comboBox36.SelectedItem = "Средний";
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
                for (int i = 0; i < n; i++)
                {
                    EAF *= EMozenka[i];
                }
            }
            else if (comboBox12.SelectedItem.Equals("Детальная"))
            {
                n = 17;
                for (int i = 0; i < n; i++)
                {
                    EAF *= EmDetalozenka[i];
                }
            }

          

            label19.Text = "EAF = " + (Math.Round(EAF, 3)).ToString();
            EAF = 1;
        }

        private void button1_Click(object sender, EventArgs e)//рассчет pm tm
        {
            double resPM;
            double resTM;

            ResultPM.Text ="";
            ResultTM.Text = "";

            if (SIZEStrok.Text != String.Empty)
            {
                SIZE = 0;
                SIZE = Double.Parse(SIZEStrok.Text);

                for (int i = 0; i < 5; i++)
                {
                    SFmasRes += SFmas[i];
                }

                E = B + 0.01 * SFmasRes;
                SFmasRes = 0;


                if (comboBox12.SelectedItem.Equals("Предварительная"))
                {
                    A = 2.94;

                    for (int i = 0; i < 7; i++)
                    {
                        EAF *= EMozenka[i];
                    }

                  
                    resPM = EAF * A * Math.Pow(SIZE,E);
                    double C = 3.67, D = 0.28;
                    

                    double EAFns = 1;
                    for (int i = 0; i < 6; i++)
                    {
                        EAFns *= EMozenka[i];
                    }

                    double PMns = EAFns * A * Math.Pow(SIZE, E);
                    resTM = EMozenka[6]*C* Math.Pow(PMns, D+0.2*(E-B));

                    ResultPM.Text = (Math.Round(resPM, 3)).ToString() + " чел. × мес. ";
                    ResultTM.Text = (Math.Round(resTM, 3)).ToString() + " календарных месяцев";
                    EAFns = 1;

                }
                else if (comboBox12.SelectedItem.Equals("Детальная"))
                {
                    A = 2.45;

                    for (int i = 0; i < 17; i++)
                    {
                        EAF *= EmDetalozenka[i];
                    }

                    //double resPM;
                    resPM = EAF * A * Math.Pow(SIZE, E);

                    double C = 3.67, D = 0.28;
                    //double resTM;

                    double EAFns = 1;
                    for (int i = 0; i < 16; i++)
                    {
                        EAFns *= EmDetalozenka[i];
                    }

                    double PMns = EAFns * A * Math.Pow(SIZE, E);
                    resTM = EmDetalozenka[16] * C * Math.Pow(PMns, D + 0.2 * (E - B));

                    ResultPM.Text = (Math.Round(resPM, 3)).ToString() + " чел. × мес. ";
                    ResultTM.Text = (Math.Round(resTM, 3)).ToString() + " календарных месяцев";
                    //EAF = 1;
                    //resPM = 0;
                    //resTM = 0;
                } 
            }
            else
            {
                MessageBox.Show("Укажите объем программного продукта в тыс.,строк кода!");
            }
            EAF = 1;
            resPM = 0;
            resTM = 0;
           


        }

    }
}
