using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelKayıtProjesi
{
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-T1QQFNTS\\MSSQLSERVER02;Initial Catalog=PersonelVeriTab;Integrated Security=True");
        //TOPLAM PERSONEL SAYISI 
        private void frmistatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while(dr1.Read())
            {
                lbltoplampersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();


            //EVLİ PERSONEL SAYISI

            baglanti.Open();


            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personel where perdurum=1",baglanti);

            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                lblevlipersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //BEKAR PERSONEL SAYISI

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count (*) From Tbl_Personel where perdurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while(dr3.Read())
            {
                lblbekar.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //ŞEHİR SAYISI
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count (distinct(persehir)) From Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblsehirsayı.Text = dr4[0].ToString();
            }
            baglanti.Close();


            //TOPLAM MAAŞ

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(permaas) From Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while(dr5.Read())
            {
                lbltoplammaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //ORTALAMA MAAŞ 
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(perMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while(dr6.Read())
            {
                lblortmaas.Text = dr6[0].ToString();
            }
            baglanti.Close();


        }
    }
}
