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
    public partial class Form3_search : Form
    {
        public Form3_search()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ((Form1)this.Owner).richTextBox1.SelectAll();
            ((Form1)this.Owner).richTextBox1.SelectionColor = Color.Black;// После того как поисковик закрыт, убираю подсветку результатов поиска;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.Value = textBox1.Text;
        }
    }
}
