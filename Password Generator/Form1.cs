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

namespace Password_Generator
{
    public partial class Form1 : Form
    {
        public List<string> myList = File.ReadAllLines(@"rockyou.txt").ToList();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            int lenght = (int)numericUpDown1.Value;
            string login = richTextBox2.Text;
            bool similar = checkBox1.Checked;
            bool symb = checkBox2.Checked;
            bool rockyou = checkBox3.Checked;
            Random rand = new Random();
            for (int i = 0; i < lenght; i++)
            {
                if (similar == true && symb == true)
                {
                    int value = rand.Next(33, 127);
                    while (value == 105 || value == 108 || value == 49 || value == 111 || value == 48 || value == 79)
                    {
                        value = rand.Next(65, 127);
                    }
                    richTextBox1.Text += (char)value;
                }
                if (similar == true && symb == false)
                {
                    int value = rand.Next(65, 116);
                    if (value > 90)
                    {
                        value += 6;
                    }
                    while (value == 105 || value == 108 || value == 49 || value == 111 || value == 48 || value == 79)
                    {
                        value = rand.Next(65, 127);
                    }
                    richTextBox1.Text += (char)value;
                }
                if (similar == false && symb == false)
                {
                    int value = rand.Next(65, 116);
                    if (value > 90)
                    {
                        value += 6;
                    }
                    richTextBox1.Text += (char)value;
                }
                if (similar == false && symb == true)
                {
                    char valuechar = (char)rand.Next(33, 127);
                    richTextBox1.Text += valuechar.ToString();
                }
                if (rockyou == true)
                {
                    while (myList.Contains(richTextBox1.Text))
                    {
                        if (similar == true && symb == true)
                        {
                            int value = rand.Next(33, 127);
                            while (value == 105 || value == 108 || value == 49 || value == 111 || value == 48 || value == 79)
                            {
                                value = rand.Next(65, 127);
                            }
                            richTextBox1.Text += (char)value;
                        }
                        if (similar == true && symb == false)
                        {
                            int value = rand.Next(65, 116);
                            if (value > 90)
                            {
                                value += 6;
                            }
                            while (value == 105 || value == 108 || value == 49 || value == 111 || value == 48 || value == 79)
                            {
                                value = rand.Next(65, 127);
                            }
                            richTextBox1.Text += (char)value;
                        }
                        if (similar == false && symb == false)
                        {
                            int value = rand.Next(65, 116);
                            if (value > 90)
                            {
                                value += 6;
                            }
                            richTextBox1.Text += (char)value;
                        }
                        if (similar == false && symb == true)
                        {
                            char valuechar = (char)rand.Next(33, 127);
                            richTextBox1.Text += valuechar.ToString();
                        }
                    }
                }
            }
            try
            {
                StreamWriter sw = new StreamWriter(@"LoginPassword.txt");
                sw.WriteLine($"Login: {login}");
                sw.WriteLine($"Password: {richTextBox1.Text}");
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
