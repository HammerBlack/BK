using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderSystem_v1
{
    public partial class Notice : Form
    {
        Form1 form1; 
        public Notice()
        {
            InitializeComponent();
        }
        public void ChangeTextBox(string word,Form1 form1)
        {
            this.form1 = form1; 
            BoxShow.Text = word;
            this.Show();
            this.form1.Hide(); 
        }
        private void Conferm_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.form1.Show(); 
        }

        private void Conferm_MouseEnter(object sender, EventArgs e)
        {
            Conferm.ForeColor = Color.White;
        }

        private void Conferm_MouseLeave(object sender, EventArgs e)
        {
            Conferm.ForeColor = Color.Black;
        }
    }
}
