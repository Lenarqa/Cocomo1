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
    public partial class BasicLvl : Form
    {
        public BasicLvl()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            RasprMetod rm = new RasprMetod();
            this.Hide();
            rm.ShowDialog();
            this.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PoluNezMetod prm = new PoluNezMetod();
            this.Hide();
            prm.ShowDialog();
            this.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VstroenMetod vm = new VstroenMetod();
            this.Hide();
            vm.ShowDialog();
            this.Show();
            Close();
        }
    }
}
