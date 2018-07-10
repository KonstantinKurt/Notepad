using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Printing;


namespace Блокнот
{
    public partial class Form1 : Form
    {
        public string file_name;
        public Form1()
        {
            InitializeComponent();
            file_name = "";
            Data.Value_changed_for_search += Find_text; // Обьявляю события для изменения и поиска строк в richbox и подписываю на них методы;
            Data.Value_changed_for_replace += Change_text;
        }

        #region Menu;
        public void Find_text(object sender, EventArgs e)  // Метод поиска и подсвечивания 
        {
            int startIndex = 0;
            while (startIndex < richTextBox1.Text.Length)
            {
                startIndex = richTextBox1.Find(Data.Value, startIndex, RichTextBoxFinds.None);
                if (startIndex == -1) break;
                richTextBox1.Select(startIndex, Data.Value.Length);
                richTextBox1.SelectionColor = Color.Red;
                startIndex += Data.Value.Length;
            }
           

        }
        public void Change_text(object sender, EventArgs e) // Метод замены элементов текста по заданным параметрам;
        {
            if (richTextBox1.Text.Contains(Data.Value))
            {
                richTextBox1.Text = richTextBox1.Text.Replace(Data.Value, Data.Value_for_change);
            }
            else
            {
                MessageBox.Show("Данная строка не найдена!", "Внимание!");
            }
        }
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (richTextBox1.Text != "")
                {
                    DialogResult result = MessageBox.Show("Желаете сохранить текущий документ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                        {
                            File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                            richTextBox1.Clear();
                            file_name = "";
                        }

                    }
                    else
                    {
                        file_name = "";
                        richTextBox1.Clear();
                    }
                }
                MessageBox.Show("Создаем новый документ");
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                    Text = saveFileDialog1.FileName;
                    file_name = saveFileDialog1.FileName;
                }
            }

            private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                // 1 способ;
                ////////////////////////
                if (richTextBox1.Text != "")
                {
                    DialogResult result = MessageBox.Show("Желаете сохранить текущий документ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                        {
                            File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                            richTextBox1.Clear();
                            file_name = "";
                        }
                        else
                        {
                            file_name = "";
                            richTextBox1.Clear();
                        }
                    }
                }
                if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                    Text = openFileDialog1.FileName;
                }

                // 2 способ;
                ////////////////////////
                //if (openFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    richTextBox1.LoadFile(openFileDialog1.FileName,RichTextBoxStreamType.PlainText);
                //    Text = openFileDialog1.FileName;
                //}
            }
            private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                // 1 способ сохранения;
                ////////////////////////
                if (file_name != "")
                {
                    File.WriteAllText(file_name, richTextBox1.Text);
                }
                else
                {
                    if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                        Text = saveFileDialog1.FileName;
                    }
                }
                // 2 способ сохранения;
                ////////////////////////
                //if (saveFileDialog1.ShowDialog() == DialogResult.OK)                     
                //{
                //    richTextBox1.SaveFile(saveFileDialog1.FileName,RichTextBoxStreamType.PlainText);
                //    Text = saveFileDialog1.FileName;
                //}
            }
            private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (printDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    try
                    {
                        if (file_name != "")
                        {
                            PrintDocument Doc = new PrintDocument();
                            Doc.DocumentName = file_name;
                            Doc.Print();
                        }
                        else
                        {
                            MessageBox.Show("Создайте документ!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
            }

            #endregion Menu;
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                Application.Exit();
            }

            private void выходToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
            #region Edit
            private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Undo();
            }
            private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Cut();
            }
            private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Copy();
            }
            private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Paste();
            }
            private void выделитьвсеToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.SelectAll();
            }
            private void времяИДатаToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Text += "\n" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
            }
            private void найтиToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Form3_search form3_search = new Form3_search(); 
                form3_search.Owner = this;  // Обьявляю родительскую форму "хозяином")) формы поиска; При этом richtextbox.modifiers = public;
                form3_search.Show();
            }

            private void заменитьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Form4_change form4_change = new Form4_change();
                form4_change.Show();
            }
           #endregion Edit;

            private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Font = fontDialog1.Font;
                }
            }

            private void цветToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionColor = colorDialog1.Color;
                }
            }

            private void строкаСостоянияToolStripMenuItem_Click(object sender, EventArgs e)  // Активация/Деактивация строки состояния;
            {

                строкаСостоянияToolStripMenuItem.Checked = !строкаСостоянияToolStripMenuItem.Checked;
                toolStripStatusLabel1.Visible = !toolStripStatusLabel1.Visible;

            }

            private void richTextBox1_TextChanged(object sender, EventArgs e)
            {
                  //richTextBox1.SelectionColor = Color.Black;
                  toolStripStatusLabel1.Text = "Колличество строк " + richTextBox1.Lines.Length + "    Колличество символов " + richTextBox1.TextLength;
            }

            private void просмотретьСправкуToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Process.Start("https://answers.microsoft.com/en-us/windows/forum/apps_windows_10"); // Переход на сайт microsoft;
            }

            private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Form2_certificate form2_certificate = new Form2_certificate();  // Или через var;
                form2_certificate.ShowDialog();
            }

        

        
    }
    
    }





