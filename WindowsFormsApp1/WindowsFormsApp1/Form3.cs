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
    public partial class Form3 : Form
    {
        MySqlConnection baglanti;
        Random rastgele = new Random();
        Button secilen1 = null, secilen2 = null, secilen3 = null;
        int secim1, secim2, secim3, dogru, skor;
        int gerisayim = 600;
        public int tekrar;
        string sesDurum;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            baglanti = new MySqlConnection("Server=localhost; Database=igpfinal; Uid=root; Pwd=;");

            if (tekrar != -1 && tekrar < 10)
            {
                tekrar = 20;
            }

            show();
            timer1.Start();
            timer2.Start();

            MySqlCommand hangisiSkor = baglanti.CreateCommand();
            hangisiSkor.CommandText = "select Hangisi from skor where SkorId = 1;";
            baglanti.Open();
            MySqlDataReader read2 = hangisiSkor.ExecuteReader();
            read2.Read();
            skor = Convert.ToInt32(read2["Hangisi"]);
            read2.Close();
            baglanti.Close();
        }

        private void show()
        {
            int sayac;
            secim1 = rastgele.Next(1, 10);
            switch (secim1)
            {
                case 1: button1.Text = "+"; button1.ForeColor = Color.Black; break;
                case 2: button2.Text = "+"; button2.ForeColor = Color.Black; break;
                case 3: button3.Text = "+"; button3.ForeColor = Color.Black; break;
                case 4: button4.Text = "+"; button4.ForeColor = Color.Black; break;
                case 5: button5.Text = "+"; button5.ForeColor = Color.Black; break;
                case 6: button6.Text = "+"; button6.ForeColor = Color.Black; break;
                case 7: button7.Text = "+"; button7.ForeColor = Color.Black; break;
                case 8: button8.Text = "+"; button8.ForeColor = Color.Black; break;
                case 9: button9.Text = "+"; button9.ForeColor = Color.Black; break;
            }
            sayac = 0;
            while (sayac < 1)
            {
                secim2 = rastgele.Next(1, 10);
                if (secim1 != secim2)
                {
                    switch (secim2)
                    {
                        case 1: button1.Text = "+"; button1.ForeColor = Color.Black; break;
                        case 2: button2.Text = "+"; button2.ForeColor = Color.Black; break;
                        case 3: button3.Text = "+"; button3.ForeColor = Color.Black; break;
                        case 4: button4.Text = "+"; button4.ForeColor = Color.Black; break;
                        case 5: button5.Text = "+"; button5.ForeColor = Color.Black; break;
                        case 6: button6.Text = "+"; button6.ForeColor = Color.Black; break;
                        case 7: button7.Text = "+"; button7.ForeColor = Color.Black; break;
                        case 8: button8.Text = "+"; button8.ForeColor = Color.Black; break;
                        case 9: button9.Text = "+"; button9.ForeColor = Color.Black; break;
                    }
                    sayac++;
                }
            }
            sayac = 0;
            while (sayac < 1)
            {
                secim3 = rastgele.Next(1, 10);
                if (secim1 != secim3 && secim2 != secim3)
                {
                    switch (secim3)
                    {
                        case 1: button1.Text = "+"; button1.ForeColor = Color.Black; break;
                        case 2: button2.Text = "+"; button2.ForeColor = Color.Black; break;
                        case 3: button3.Text = "+"; button3.ForeColor = Color.Black; break;
                        case 4: button4.Text = "+"; button4.ForeColor = Color.Black; break;
                        case 5: button5.Text = "+"; button5.ForeColor = Color.Black; break;
                        case 6: button6.Text = "+"; button6.ForeColor = Color.Black; break;
                        case 7: button7.Text = "+"; button7.ForeColor = Color.Black; break;
                        case 8: button8.Text = "+"; button8.ForeColor = Color.Black; break;
                        case 9: button9.Text = "+"; button9.ForeColor = Color.Black; break;
                    }
                    sayac++;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;
            button4.ForeColor = Color.White;
            button5.ForeColor = Color.White;
            button6.ForeColor = Color.White;
            button7.ForeColor = Color.White;
            button8.ForeColor = Color.White;
            button9.ForeColor = Color.White;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (secilen1 == null)
            {
                secilen1 = clickedButton;
                secilen1.ForeColor = Color.Black;
                return;
            }

            if (secilen2 == null)
            {
                secilen2 = clickedButton;
                secilen2.ForeColor = Color.Black;
                return;
            }

            secilen3 = clickedButton;
            secilen3.ForeColor = Color.Black;

            if (secilen1.Text == secilen2.Text && secilen2.Text == secilen3.Text && secilen1.Text == secilen3.Text)
            {
                dogru++;
                label1.Text = "Doğru: " + dogru;
                secilen1 = null;
                secilen2 = null;
                secilen3 = null;
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
                show();
                timer1.Start();
                return;
            }
            else {
                secilen1 = null;
                secilen2 = null;
                secilen3 = null;
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
                show();
                timer1.Start();
                return;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            gerisayim--;
            if (gerisayim % 2 == 0)
            {
                label2.Text = "Oyunun bitmesine kalan süre " + gerisayim/2 + " saniye.";
            }

            if (tekrar != null)
            {
                if (dogru == tekrar)
                {
                    if (dogru > skor)
                    {
                        MySqlCommand skorKomutu = baglanti.CreateCommand();
                        skorKomutu.CommandText = "UPDATE skor SET Hangisi = " + dogru + " WHERE SkorId = 1; ";

                        baglanti.Open();
                        skorKomutu.ExecuteNonQuery();
                        baglanti.Close();
                    }

                    MySqlCommand sesDenetim = baglanti.CreateCommand();
                    sesDenetim.CommandText = "select * from alarmses where No = 1;";
                    baglanti.Open();
                    MySqlDataReader read = sesDenetim.ExecuteReader();
                    read.Read();
                    sesDurum = read["durumu"].ToString();
                    read.Close();
                    baglanti.Close();

                    if (sesDurum == "açık")
                    {
                        MySqlCommand sesKapat = baglanti.CreateCommand();
                        sesKapat.CommandText = "UPDATE alarmses SET durumu = 'kapalı' WHERE No = 1; ";
                        baglanti.Open();
                        sesKapat.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    this.Close();
                }
            }

            
            if (gerisayim == 0)
            {
                if (dogru > skor)
                {
                    MySqlCommand skorKomutu = baglanti.CreateCommand();
                    skorKomutu.CommandText = "UPDATE skor SET Hangisi = " + dogru + " WHERE SkorId = 1; ";

                    baglanti.Open();
                    skorKomutu.ExecuteNonQuery();
                    baglanti.Close();
                }

                MySqlCommand sesDenetim = baglanti.CreateCommand();
                sesDenetim.CommandText = "select * from alarmses where No = 1;";
                baglanti.Open();
                MySqlDataReader read = sesDenetim.ExecuteReader();
                read.Read();
                sesDurum = read["durumu"].ToString();
                read.Close();
                baglanti.Close();

                if (sesDurum == "açık")
                {
                    MySqlCommand sesKapat = baglanti.CreateCommand();
                    sesKapat.CommandText = "UPDATE alarmses SET durumu = 'kapalı' WHERE No = 1; ";
                    baglanti.Open();
                    sesKapat.ExecuteNonQuery();
                    baglanti.Close();
                }
                this.Close();
            }
        }
    }
}
