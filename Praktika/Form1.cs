using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Praktika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker2.MaxDate = DateTime.Today;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string filetext = folderBrowserDialog1.SelectedPath;
                richTextBox1.Text = filetext;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                listBox1.Items.Clear(); 
                if (richTextBox1.Text == String.Empty)
                {
                    listBox1.Items.Add("Выберите папку с файлами");
                    return;
                }
                string filetext = richTextBox1.Lines[0];
                DirectoryInfo dir = new DirectoryInfo(filetext);
                FileInfo[] files = dir.GetFiles("*.wav");
                int dlinamas = files.Length;
                if (dlinamas == 0)
                {
                    listBox1.Items.Add("В этой папке нет файлов с расширением wav");
                    return;
                }
                var result3 = DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value);
                if (result3 > 0)
                {
                    listBox1.Items.Add("Введите даты корректно");
                    return;
                }
                if (textBox1.Text == String.Empty) {
                        foreach (FileInfo fi in files)
                        {
                            string a = fi.ToString();
                            int indexOfChar = a.IndexOf("QUEUE%");
                            DateTime time1 = fi.CreationTime;
                            string time1s = time1.ToShortDateString();
                            var result1 = DateTime.Compare(time1, dateTimePicker1.Value);
                            var result2 = DateTime.Compare(time1, dateTimePicker2.Value);
                            string picktime2 = dateTimePicker2.Value.ToShortDateString();
                            long dlit = fi.Length / 1024 / 1024;
                            if ((result1 >= 0 && result2 <= 0) || (time1s == picktime2) || (result1==result2 && result1==0))
                            {
                                if ((checkBox1.Checked == true && checkBox2.Checked == true) || (checkBox1.Checked == false && checkBox2.Checked == false))
                                {
                                    if (textBox2.Text == String.Empty) {
                                        listBox1.Items.Add(fi.ToString());
                                    }
                                    else if (dlit < Convert.ToInt32(textBox2.Text))
                                    {
                                        listBox1.Items.Add(fi.ToString());
                                    }
                                }
                                else if (checkBox1.Checked == true && checkBox2.Checked == false)
                                {
                                    if (indexOfChar != -1)
                                    {
                                        if (textBox2.Text == String.Empty) {
                                            listBox1.Items.Add(fi.ToString());
                                        }
                                        else if (dlit < Convert.ToInt32(textBox2.Text))
                                        {
                                            listBox1.Items.Add(fi.ToString());
                                        }
                                    }
                                }
                                else
                                {
                                    if (indexOfChar == -1)
                                    {
                                        if (textBox2.Text == String.Empty) {
                                            listBox1.Items.Add(fi.ToString());
                                        }
                                        else if (dlit < Convert.ToInt32(textBox2.Text))
                                        {
                                            listBox1.Items.Add(fi.ToString());
                                        }
                                    }

                                }
                            }
                        }
                }
                else
                {
                    int kolvo = Convert.ToInt32(textBox1.Text);
                    foreach (FileInfo fi in files)
                    {
                        if (kolvo != 0)
                        {
                        string a = fi.ToString();
                        int indexOfChar = a.IndexOf("QUEUE%");
                        DateTime time1 = fi.CreationTime;
                        string time1s = time1.ToShortDateString();
                        var result1 = DateTime.Compare(time1, dateTimePicker1.Value);
                        var result2 = DateTime.Compare(time1, dateTimePicker2.Value);
                        string picktime2 = dateTimePicker2.Value.ToShortDateString();
                        long dlit = fi.Length / 1024 / 1024;
                        if ((result1 >= 0 && result2 <= 0) || (time1s == picktime2) || (result1 == result2 && result1 == 0))
                            {
                                if ((checkBox1.Checked == true && checkBox2.Checked == true) || (checkBox1.Checked == false && checkBox2.Checked == false))
                                {
                                    if (textBox2.Text == String.Empty)
                                    {
                                        listBox1.Items.Add(fi.ToString());
                                        kolvo -= 1;
                                    }
                                    else if (dlit < Convert.ToInt32(textBox2.Text))
                                    {
                                        listBox1.Items.Add(fi.ToString());
                                        kolvo -= 1;
                                    }
                                }
                                else if (checkBox1.Checked == true && checkBox2.Checked == false)
                                {
                                    if (indexOfChar != -1)
                                    {
                                        if (textBox2.Text == String.Empty)
                                        {
                                            listBox1.Items.Add(fi.ToString());
                                            kolvo -= 1;
                                        }
                                        else if (dlit < Convert.ToInt32(textBox2.Text))
                                        {
                                            listBox1.Items.Add(fi.ToString());
                                            kolvo -= 1;
                                        }

                                    }
                                }
                                else
                                {
                                    if (indexOfChar == -1)
                                    {
                                        if (textBox2.Text == String.Empty)
                                        {
                                            listBox1.Items.Add(fi.ToString());
                                            kolvo -= 1;
                                        }
                                        else if (dlit < Convert.ToInt32(textBox2.Text))
                                        {
                                            listBox1.Items.Add(fi.ToString());
                                            kolvo -= 1;
                                        }
                                    }

                                }
                            }
                    }
                    }
                }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string filetext = richTextBox1.Lines[0];
            DirectoryInfo dir = new DirectoryInfo(filetext);
            FileInfo[] files = dir.GetFiles("*.wav");
            int dlinamas = files.Length;
            if (dlinamas != 0)
            {
                string selel = listBox1.SelectedItem.ToString();
                foreach (FileInfo fi in files)
                {
                    if (fi.ToString() == selel)
                    {
                        System.Diagnostics.Process.Start(fi.FullName);
                    }
                }
            }
        }
    }
}
