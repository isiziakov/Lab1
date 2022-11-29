using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public IGetInfo info = new Info();
        public Int32[,] ResultArray = new Int32[8, 8];
        public Int32 size = 1;
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
            if (Int32.TryParse(text, out Int32 b))
            {
                size = 1;
                if (Int32.Parse(text) > 0 && Int32.Parse(text) <= 9)
                {
                    size = Int32.Parse(text);
                }
            }
            else
            {
                size = 1;
            }
            ResultArray = new Int32[8, 8];
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

        public Int32 headerCount = 0;
        public Int32 rawsCount = 0;
        public Int32 numbersCount = 0;
        public void show()
        {
            var text = "    ";
            for (Int32 i = 1; i <= size; i++)
            {
                headerCount++;
                text += " " + i + " ";
            }
            text += "\r\n\r\n";
            for (Int32 i = 1; i <= size; i++)
            {
                text += " " + i + " ";
                rawsCount++;
                for (Int32 j = 0; j < size; j++)
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
        Int32 getInfo(string text);
    }

    public class Info : IGetInfo
    {
        public Info()
        {

        }

        public Int32 getInfo(string text)
        {
            if (text.Length == 3 && Int32.TryParse(text[0].ToString(), out Int32 b) && Int32.TryParse(text[2].ToString(), out Int32 a))
            {
                return Int32.Parse(text[0].ToString()) * 10 + Int32.Parse(text[2].ToString());
            }
            else return -1;
        }
    }
}
