using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Блокнот
{
    public partial class Form4_change : Form
    {
        public Form4_change()
        {
            InitializeComponent();
            textBox1.Focus();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.Value = textBox1.Text;
            Data.Value_for_change = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          if(textBox1.Text !="" && textBox2.Text !="")
            {
                button1.Enabled = true;
            }

        
        }

        
    }
}
