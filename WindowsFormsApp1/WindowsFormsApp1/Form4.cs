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
    public partial class Form4 : Form
    {
        MySqlConnection baglanti;
        string zaman;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            baglanti = new MySqlConnection("Server=localhost; Database=igpfinal; Uid=root; Pwd=;");
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                zaman = comboBox2.Text + ":" + comboBox3.Text;
                MySqlCommand elkeKomutu = baglanti.CreateCommand();
                elkeKomutu.CommandText = "insert into alarm (AlarmNo, AlarmAdi, Zaman) values (" + Convert.ToInt32(comboBox1.Text) + ",'" + textBox1.Text + "','" + zaman +"')";

                baglanti.Open();
                try
                {
                    elkeKomutu.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    //
                }
                baglanti.Close();
                denetimBasla();

                listele();
            }
            else
            {
                MessageBox.Show("Lütfen bütün alanları doldurunuz!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {
                MySqlCommand silKomutu = baglanti.CreateCommand();
                silKomutu.CommandText = "DELETE FROM alarm WHERE AlarmNo = "+ Convert.ToInt32(comboBox4.Text) +";";

                baglanti.Open();
                try
                {
                    silKomutu.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    //
                }
                baglanti.Close();
                denetimDur();

                listele();
            }
            else
            {
                MessageBox.Show("Lütfen bütün alanları doldurunuz!");
            }
        }

        private void listele() {
            MySqlCommand listeleKomutu = baglanti.CreateCommand();
            listeleKomutu.CommandText = "SELECT * FROM alarm";
            MySqlDataAdapter da = new MySqlDataAdapter(listeleKomutu);
            DataTable dt = new DataTable();

            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();
            dataGridView1.DataSource = dt;
        }

        private void denetimBasla()
        {
            switch (comboBox1.Text)
            {
                case "1":
                    MySqlCommand alarm1Guncelle = baglanti.CreateCommand();
                    alarm1Guncelle.CommandText = "UPDATE denetim SET durum = 'aktif' WHERE No = 1";
                    baglanti.Open();
                    alarm1Guncelle.ExecuteNonQuery();
                    baglanti.Close(); break;
                case "2":
                    MySqlCommand alarm2Guncelle = baglanti.CreateCommand();
                    alarm2Guncelle.CommandText = "UPDATE denetim SET durum = 'aktif' WHERE No = 2";
                    baglanti.Open();
                    alarm2Guncelle.ExecuteNonQuery();
                    baglanti.Close(); break;
                case "3":
                    MySqlCommand alarm3Guncelle = baglanti.CreateCommand();
                    alarm3Guncelle.CommandText = "UPDATE denetim SET durum = 'aktif' WHERE No = 3";
                    baglanti.Open();
                    alarm3Guncelle.ExecuteNonQuery();
                    baglanti.Close(); break;
                case "4":
                    MySqlCommand alarm4Guncelle = baglanti.CreateCommand();
                    alarm4Guncelle.CommandText = "UPDATE denetim SET durum = 'aktif' WHERE No = 4";
                    baglanti.Open();
                    alarm4Guncelle.ExecuteNonQuery();
                    baglanti.Close(); break;
                case "5":
                    MySqlCommand alarm5Guncelle = baglanti.CreateCommand();
                    alarm5Guncelle.CommandText = "UPDATE denetim SET durum = 'aktif' WHERE No = 5";
                    baglanti.Open();
                    alarm5Guncelle.ExecuteNonQuery();
                    baglanti.Close(); break;
            }
        }

        private void denetimDur()
        {
            switch (comboBox4.Text)
            {
                case "1":
                    MySqlCommand alarm1Guncelle = baglanti.CreateCommand();
                    alarm1Guncelle.CommandText = "UPDATE denetim SET durum = 'pasif' WHERE No = 1";
                    baglanti.Open();
                    alarm1Guncelle.ExecuteNonQuery();
                    baglanti.Close(); break;
                case "2":
                    MySqlCommand alarm2Guncelle = baglanti.CreateCommand();
                    alarm2Guncelle.CommandText = "UPDATE denetim SET durum = 'pasif' WHERE No = 2";
                    baglanti.Open();
                    alarm2Guncelle.ExecuteNonQuery();
                    baglanti.Close(); break;
                case "3":
                    MySqlCommand alarm3Guncelle = baglanti.CreateCommand();
                    alarm3Guncelle.CommandText = "UPDATE denetim SET durum = 'pasif' WHERE No = 3";
                    baglanti.Open();
                    alarm3Guncelle.ExecuteNonQuery();
                    baglanti.Close(); break;
                case "4":
                    MySqlCommand alarm4Guncelle = baglanti.CreateCommand();
                    alarm4Guncelle.CommandText = "UPDATE denetim SET durum = 'pasif' WHERE No = 4";
                    baglanti.Open();
                    alarm4Guncelle.ExecuteNonQuery();
                    baglanti.Close(); break;
                case "5":
                    MySqlCommand alarm5Guncelle = baglanti.CreateCommand();
                    alarm5Guncelle.CommandText = "UPDATE denetim SET durum = 'pasif' WHERE No = 5";
                    baglanti.Open();
                    alarm5Guncelle.ExecuteNonQuery();
                    baglanti.Close(); break;
            }
        }
    }
}
