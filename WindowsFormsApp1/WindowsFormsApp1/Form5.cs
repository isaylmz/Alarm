using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Media;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        MySqlConnection baglanti;
        string saat, alarm1, alarm2, alarm3, alarm4, alarm5;
        string denetim1, denetim2, denetim3, denetim4, denetim5, sesDurum;
        public Form5()
        {
            InitializeComponent();
        }

        private void alarmSes_Tick(object sender, EventArgs e)
        {
            System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
            ses.SoundLocation = "alarm.wav";
            if (sesDurum == "açık")
            {
                ses.Play();
            }
            else
            {
                ses.Stop();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            baglanti = new MySqlConnection("Server=localhost; Database=igpfinal; Uid=root; Pwd=;");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MySqlCommand alarm1Getir = baglanti.CreateCommand();
            alarm1Getir.CommandText = "select * from alarm where AlarmNo = 1;";
            baglanti.Open();
            MySqlDataReader read1 = alarm1Getir.ExecuteReader();
            read1.Read();
            try
            {
                alarm1 = read1["Zaman"].ToString();
                label1.Text = alarm1;
            }
            catch (Exception)
            {
                //
            }
            read1.Close();
            baglanti.Close();

            if (alarm1 == saat)
            {
                sesAc();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MySqlCommand alarm2Getir = baglanti.CreateCommand();
            alarm2Getir.CommandText = "select * from alarm where AlarmNo = 2;";
            baglanti.Open();
            MySqlDataReader read2 = alarm2Getir.ExecuteReader();
            read2.Read();
            try
            {
                alarm2 = read2["Zaman"].ToString();
                label2.Text = alarm2;
            }
            catch (Exception)
            {
                //
            }
            read2.Close();
            baglanti.Close();

            if (alarm2 == saat)
            {
                sesAc();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            MySqlCommand alarm3Getir = baglanti.CreateCommand();
            alarm3Getir.CommandText = "select * from alarm where AlarmNo = 3;";
            baglanti.Open();
            MySqlDataReader read3 = alarm3Getir.ExecuteReader();
            read3.Read();
            try
            {
                alarm3 = read3["Zaman"].ToString();
                label3.Text = alarm3;
            }
            catch (Exception)
            {
                //
            }
            read3.Close();
            baglanti.Close();

            if (alarm3 == saat)
            {
                sesAc();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            MySqlCommand alarm4Getir = baglanti.CreateCommand();
            alarm4Getir.CommandText = "select * from alarm where AlarmNo = 4;";
            baglanti.Open();
            MySqlDataReader read4 = alarm4Getir.ExecuteReader();
            read4.Read();
            try
            {
                alarm4 = read4["Zaman"].ToString();
                label4.Text = alarm4;
            }
            catch (Exception)
            {
                //
            }
            read4.Close();
            baglanti.Close();

            if (alarm4 == saat)
            {
                sesAc();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            MySqlCommand alarm5Getir = baglanti.CreateCommand();
            alarm5Getir.CommandText = "select * from alarm where AlarmNo = 5;";
            baglanti.Open();
            MySqlDataReader read5 = alarm5Getir.ExecuteReader();
            read5.Read();
            try
            {
                alarm5 = read5["Zaman"].ToString();
                label5.Text = alarm5;
            }
            catch (Exception)
            {
                //
            }
            read5.Close();
            baglanti.Close();

            if (alarm5 == saat)
            {
                sesAc();
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            denetleme();
            if (denetim1 == "aktif")
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }

            if (denetim2 == "aktif")
            {
                timer2.Start();
            }
            else
            {
                timer2.Stop();
            }

            if (denetim3 == "aktif")
            {
                timer3.Start();
            }
            else
            {
                timer3.Stop();
            }

            if (denetim4 == "aktif")
            {
                timer4.Start();
            }
            else
            {
                timer4.Stop();
            }

            if (denetim5 == "aktif")
            {
                timer5.Start();
            }
            else
            {
                timer5.Stop();
            }
        }

        private void guncelSaat_Tick(object sender, EventArgs e)
        {
            saat = DateTime.Now.ToShortTimeString();
        }

        private void denetleme()
        {
            MySqlCommand alarm1Getir = baglanti.CreateCommand();
            alarm1Getir.CommandText = "select * from denetim where No = 1;";
            baglanti.Open();
            MySqlDataReader read1 = alarm1Getir.ExecuteReader();
            read1.Read();
            denetim1 = read1["durum"].ToString();
            read1.Close();
            baglanti.Close();

            MySqlCommand alarm2Getir = baglanti.CreateCommand();
            alarm2Getir.CommandText = "select * from denetim where No = 2;";
            baglanti.Open();
            MySqlDataReader read2 = alarm2Getir.ExecuteReader();
            read2.Read();
            denetim2 = read2["durum"].ToString();
            read2.Close();
            baglanti.Close();

            MySqlCommand alarm3Getir = baglanti.CreateCommand();
            alarm3Getir.CommandText = "select * from denetim where No = 3;";
            baglanti.Open();
            MySqlDataReader read3 = alarm3Getir.ExecuteReader();
            read3.Read();
            denetim3 = read3["durum"].ToString();
            read3.Close();
            baglanti.Close();

            MySqlCommand alarm4Getir = baglanti.CreateCommand();
            alarm4Getir.CommandText = "select * from denetim where No = 4;";
            baglanti.Open();
            MySqlDataReader read4 = alarm4Getir.ExecuteReader();
            read4.Read();
            denetim4 = read4["durum"].ToString();
            read4.Close();
            baglanti.Close();

            MySqlCommand alarm5Getir = baglanti.CreateCommand();
            alarm5Getir.CommandText = "select * from denetim where No = 5;";
            baglanti.Open();
            MySqlDataReader read5 = alarm5Getir.ExecuteReader();
            read5.Read();
            alarm5 = read5["durum"].ToString();
            read5.Close();
            baglanti.Close();

            MySqlCommand sesDenetim = baglanti.CreateCommand();
            sesDenetim.CommandText = "select * from alarmses where No = 1;";
            baglanti.Open();
            MySqlDataReader read6 = sesDenetim.ExecuteReader();
            read6.Read();
            sesDurum = read6["durumu"].ToString();
            read6.Close();
            baglanti.Close();
        }

        private void sesAc()
        {
            MySqlCommand sesKapat = baglanti.CreateCommand();
            sesKapat.CommandText = "UPDATE alarmses SET durumu = 'açık' WHERE No = 1; ";
            baglanti.Open();
            sesKapat.ExecuteNonQuery();
            baglanti.Close();
        }
    }

}
