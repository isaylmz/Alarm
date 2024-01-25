using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MySqlConnection baglanti;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti = new MySqlConnection("Server=localhost; Database=igpfinal; Uid=root; Pwd=;");
            timer1.Start();

            Form5 denetim = new Form5();
            denetim.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    Form2 DortIslem = new Form2();
                    DortIslem.tekrar = Convert.ToInt32(textBox1.Text);
                    DortIslem.Show();
                }
                else {
                    Form2 DortIslem = new Form2();
                    DortIslem.Show();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Sadece sayı giriniz!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    Form3 Hangisi = new Form3();
                    Hangisi.tekrar = Convert.ToInt32(textBox2.Text);
                    Hangisi.Show();
                }
                else
                {
                    Form3 Hangisi = new Form3();
                    Hangisi.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sadece sayı giriniz!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 Alarm = new Form4();
            Alarm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MySqlCommand islemSkor = baglanti.CreateCommand();
            islemSkor.CommandText = "select * from skor where SkorId = 1;";
            baglanti.Open();
            MySqlDataReader read = islemSkor.ExecuteReader();
            read.Read();
            label8.Text = read["DortIslem"].ToString();
            read.Close();
            baglanti.Close();

            MySqlCommand hangisiSkor = baglanti.CreateCommand();
            hangisiSkor.CommandText = "select * from skor where SkorId = 1;";
            baglanti.Open();
            MySqlDataReader read2 = hangisiSkor.ExecuteReader();
            read2.Read();
            label9.Text = read2["Hangisi"].ToString();
            read2.Close();
            baglanti.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
