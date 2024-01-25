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
    public partial class Form2 : Form
    {
        MySqlConnection baglanti;
        Random rastgele = new Random();
        int sayi1, sayi2, islem, sonuc, dogru, skor;
        int gerisayim = 600;
        public int tekrar;
        string sesDurum;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            baglanti = new MySqlConnection("Server=localhost; Database=igpfinal; Uid=root; Pwd=;");

            if (tekrar != -1 && tekrar < 10)
            {
                tekrar = 10;
            }

            islemgetir();
            timer1.Start();

            MySqlCommand islemSkor = baglanti.CreateCommand();
            islemSkor.CommandText = "select DortIslem from skor where SkorId = 1;";
            baglanti.Open();
            MySqlDataReader read = islemSkor.ExecuteReader();
            read.Read();
            skor = Convert.ToInt32(read["DortIslem"]);
            read.Close();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sonuc == Convert.ToInt32(textBox1.Text))
                {
                    textBox1.Clear();
                    dogru++;
                    label5.Text = "Doğru: "+dogru;
                    islemgetir();
                }
            }
            catch (Exception) {
                //Bir şey yapma kendi anlasın
            }
        }

        private void islemgetir()
        {
            islem = rastgele.Next(1, 5);

            // Çıkarma sorgusu
            if (islem == 1)
            {
                sayi1 = rastgele.Next(0, 10);
                label1.Text = sayi1.ToString();
                label2.Text = "-";
                sayi2 = rastgele.Next(0, sayi1 + 1);
                label3.Text = sayi2.ToString();
                sonuc = sayi1 - sayi2;
            }
            // Toplama sorgusu
            if (islem == 2)
            {
                sayi1 = rastgele.Next(0, 10);
                label1.Text = sayi1.ToString();
                label2.Text = "+";
                sayi2 = rastgele.Next(0, 10);
                label3.Text = sayi2.ToString();
                sonuc = sayi1 + sayi2;
            }
            // Bölme sorgusu
            if (islem == 3)
            {
                sayi1 = rastgele.Next(1, 10);
                label1.Text = sayi1.ToString();
                int boyut = 0;
                label2.Text = "%";

                for (int i = 1; i <= sayi1; i++)
                {
                    if (sayi1 % i == 0)
                    {
                        boyut++;
                    }
                }

                int[] bolen = new int[boyut];
                int sayac = 0;

                for (int i = 1; i <= sayi1; i++)
                {
                    if (sayi1 % i == 0)
                    {
                        bolen[sayac] = i;
                        sayac++;
                    }
                }
                int rbolen = rastgele.Next(0, bolen.Length);
                sayi2 = bolen[rbolen];
                label3.Text = sayi2.ToString();
                sonuc = sayi1 / sayi2;
                
                //for (int a = 0; a<boyut; a++)
                //{
                //    MessageBox.Show(bolen[a].ToString());
                //}
            }
            // Çarpma sorgusu
            if (islem == 4)
            {
                sayi1 = rastgele.Next(0, 10);
                label1.Text = sayi1.ToString();
                label2.Text = "x";
                sayi2 = rastgele.Next(0, 10);
                label3.Text = sayi2.ToString();
                sonuc = sayi1 * sayi2;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gerisayim--;
            if (gerisayim % 2 == 0)
            {
                label6.Text = "Oyunun bitmesine kalan süre " + gerisayim / 2 + " saniye.";
            }

            if (tekrar != null)
            {
                if (dogru == tekrar)
                {
                    if (dogru > skor)
                    {
                        MySqlCommand skorKomutu = baglanti.CreateCommand();
                        skorKomutu.CommandText = "UPDATE skor SET DortIslem = "+ dogru +" WHERE SkorId = 1; ";

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
                    skorKomutu.CommandText = "UPDATE skor SET DortIslem = " + dogru + " WHERE SkorId = 1; ";

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
