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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-T1QQFNTS\\MSSQLSERVER02;Initial Catalog=PersonelVeriTab;Integrated Security=True");

        void temizle()
        {
            Txtid.Text = "";
            Txtid.Text = "";
            Txtsoyad.Text = "";
            txtmeslek.Text = "";
            mskmaas.Text = "";
            cmbsehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            Txtad.Focus();


        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabDataSet6.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter1.Fill(this.personelVeriTabDataSet6.Tbl_Personel);

       
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabDataSet.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter1.Fill(this.personelVeriTabDataSet6.Tbl_Personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,permeslek,perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", Txtad.Text);
            komut.Parameters.AddWithValue("@p2", Txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", mskmaas.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);

            MessageBox.Show("Personel Eklendi");
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           if(radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;

            Txtid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            Txtad.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            Txtsoyad.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text= dataGridView2.Rows[secilen].Cells[6].Value.ToString();

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text=="True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text =="False")
            {
                radioButton2.Checked = false;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel Where Perid=@k1",baglanti);

            komutsil.Parameters.AddWithValue("@k1", Txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutguncelle = new SqlCommand("Update tbl_Personel Set PerAd=@k1,PerSoyad=@k2,persehir=@k3,permaas=@k4,perdurum=@k5,permeslek=@k6 where perid=@k7", baglanti);
            komutguncelle.Parameters.AddWithValue("@k1", Txtad.Text);
            komutguncelle.Parameters.AddWithValue("@k2", Txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@k3", cmbsehir.Text);
            komutguncelle.Parameters.AddWithValue("@k4", mskmaas.Text);
            komutguncelle.Parameters.AddWithValue("@k5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@k6", txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@k7", Txtid.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgileri Güncellendi");


        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            frmistatistik fr = new frmistatistik();
            fr.Show();
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            frmgrafikler fr = new frmgrafikler();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmraporlar frm = new frmraporlar();
            frm.Show();
        }
    }
}
