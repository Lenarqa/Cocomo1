﻿using System;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BasicLvl form2 = new BasicLvl();
            this.Hide();
            form2.ShowDialog();
            this.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            promezh form2 = new promezh();
            this.Hide();
            form2.ShowDialog();
            this.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //String filename = "Cправка.pdf";
            //System.Diagnostics.Process.Start("C:\\Users\\lenar\\OneDrive\\Рабочий стол\\3 курс 1 семест\\ИМ Миньков\\COCOMO\\COCOMO\\COCOMO\\Resources\\Spravka.pdf");
            //System.Diagnostics.Process.Start(filename);
            //string filename = Application.StartupPath;

            //filename = System.IO.Path.GetFullPath(System.IO.Path.Combine(filename, ".\\Справка.pdf"));
            //System.Diagnostics.Process.Start(filename);
            System.Diagnostics.Process.Start(".\\Справка.pdf");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cocomo2 form2 = new cocomo2();
            this.Hide();
            form2.ShowDialog();
            this.Show();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
            }
        }
    }
}
