using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public IGetInfo info = new Info();
        public int[,] ResultArray = new int[8, 8];
        public int size = 1;
        public Form1()
        {
            InitializeComponent();
        }

        public void setGetInfo(IGetInfo info)
        {
            this.info = info;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setSize(textBox1.Text);
        }

        public void setSize(string text)
        {
            if (int.TryParse(text, out int b))
            {
                size = 1;
                if (int.Parse(text) > 0 && int.Parse(text) <= 9)
                {
                    size = int.Parse(text);
                }
            }
            else
            {
                size = 1;
            }
            ResultArray = new int[8, 8];
            textBox1.Text = size.ToString();
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add(textBox2.Text);
        }

        public void add(string text)
        {
            var n = info.getInfo(text);
            if (n != -1 && n / 10 <= size && n % 10 <= size)
            {
                ResultArray[n / 10 - 1, n % 10 - 1]++;
                /*if (n % 10 != n / 10)
                {
                    ResultArray[n % 10 - 1, n / 10 - 1]++;
                }*/
                textBox4.Text += text + "\r\n";
                textBox2.Text = "";
                textBox5.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete(textBox3.Text);
        }

        public void delete(string text)
        {
            var n = info.getInfo(text);
            if (n != -1 && n / 10 <= size && n % 10 <= size
                && ResultArray[n / 10 - 1, n % 10 - 1] > 0 /*&& ResultArray[n % 10 - 1, n / 10 - 1] > 0*/)
            {
                ResultArray[n / 10 - 1, n % 10 - 1]--;
                /*if (n % 10 != n / 10)
                {
                    ResultArray[n % 10 - 1, n / 10 - 1]--;
                }*/
                var index = textBox4.Text.IndexOf(text);
                if (index > -1)
                {
                    textBox4.Text = textBox4.Text.Remove(index, 5);
                }
                else
                {
                    var newNumber = text[2] + " " + text[0];
                    index = textBox4.Text.IndexOf(newNumber);
                    textBox4.Text = textBox4.Text.Remove(index, 5);
                }
                textBox3.Text = "";
                textBox5.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            show();
        }

        public int headerCount = 0;
        public int rawsCount = 0;
        public int numbersCount = 0;
        public void show()
        {
            var text = "    ";
            for (int i = 1; i <= size; i++)
            {
                headerCount++;
                text += " " + i + " ";
            }
            text += "\r\n\r\n";
            for (int i = 1; i <= size; i++)
            {
                text += " " + i + " ";
                rawsCount++;
                for (int j = 0; j < size; j++)
                {
                    var number = ResultArray[i - 1, j].ToString();
                    text += " " + number + " ";
                    numbersCount++;
                }
                text += "\r\n\r\n";
            }
            textBox5.Text = text;
        }
    }

    public interface IGetInfo
    {
        int getInfo(string text);
    }

    public class Info : IGetInfo
    {
        public Info()
        {

        }

        public int getInfo(string text)
        {
            if (text.Length == 3 && int.TryParse(text[0].ToString(), out int b) && int.TryParse(text[2].ToString(), out int a))
            {
                return int.Parse(text[0].ToString()) * 10 + int.Parse(text[2].ToString());
            }
            else return -1;
        }
    }
}
