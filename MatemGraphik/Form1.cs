using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace MatemGraphik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        double xo = 0, yo = 0;
        void print_pole()
        {
            Graphics g = CreateGraphics();
            Pen pen = new Pen(Color.Black, 5.0f);
            g.DrawLine(pen, 300, 400, 300, 100);
            g.DrawLine(pen, 450, 250, 150, 250);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.FromArgb(64, 64, 64));
            print_pole();
            Pen pen = new Pen(Color.Blue, 5.0f);
            double k = 0, b = 0;
            if (comboBox1.SelectedIndex == 0 && maskedTextBox1.Text != "" && maskedTextBox2.Text != "")
            {
                double x = 0, y = 0;
                k = double.Parse(maskedTextBox1.Text);
                b = double.Parse(maskedTextBox2.Text) * 10;
                for (int i = -150; i <= 150; i++)
                {
                    if (i == -150)
                    {
                        x = i;
                        y = k * x + b;
                    }
                    else
                    {
                        float x1 = (float)(x + xo), y1 = (float)((y * -1) + yo), x2 = (float)(i + xo), y2 = (float)((((k * i) + b) * -1) + yo);
                        g.DrawLine(pen, x1, y1, x2, y2);
                        x = i;
                        y = k * x + b;
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                double x = 0, y = 0;
                for (int i = -150; i <= 150; i++)
                {

                    if (i == -150)
                    {
                        x = i;
                        y = Math.Pow(x, 2);
                    }
                    else
                    {
                        float x1 = (float)(x + xo), y1 = (float)((y * -1) + yo), x2 = (float)(i + xo), y2 = (float)((Math.Pow(x, 2) * -1) + yo);
                        g.DrawLine(pen, x1, y1, x2, y2);
                        x = i;
                        y = Math.Pow(x, 2);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                double x = 0, y = 0;
                double a = double.Parse(maskedTextBox1.Text);
                for (int i = 1; i < 150; i++)
                {

                    if (i == 1)
                    {
                        x = i;
                        y = Math.Log(x) * a;
                    }
                    else
                    {
                        float x1 = (float)(x + xo), y1 = (float)((y * -1) + yo), x2 = (float)(i + xo), y2 = (float)(((Math.Log(x) * a) * -1) + yo);
                        g.DrawLine(pen, x1, y1, x2, y2);
                        x = i;
                        y = Math.Log(x) * a;
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                maskedTextBox1.Visible = true; maskedTextBox1.Text = "";
                maskedTextBox2.Visible = true; maskedTextBox2.Text = "";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                maskedTextBox1.Visible = false; maskedTextBox1.Text = "";
                maskedTextBox2.Visible = false; maskedTextBox2.Text = "";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                maskedTextBox1.Visible = true; maskedTextBox1.Text = "";
                maskedTextBox2.Visible = false; maskedTextBox2.Text = "";
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            print_pole();
            xo = 300;
            yo = 250;
        }
    }
}
