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

namespace PersonelKayitProgramı
{
    public partial class frmAnaform : Form
    {
        public frmAnaform()
        {
            InitializeComponent(); 
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-ERHK7L8;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtmeslek.Text = "";
            txtsoyad.Text = "";
            mskmaas.Text = "";
            cmbsehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked= false;
            txtad.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_personel(PerAd,PerSoyad,PerSehir,PerMaas,permeslek,perDurum) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", mskmaas.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);  
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Yüklendi");
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
            if ( radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }




        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmtguncelleme = new SqlCommand(" Update Tbl_personel set perad=@p1, persoyad=@p2, persehir=@p3, permaas=@p4, perdurum=@p5, permeslek=@p6 where perid=@p7", baglanti);
            kmtguncelleme.Parameters.AddWithValue("@p1", txtad.Text);
            kmtguncelleme.Parameters.AddWithValue("@p2", txtsoyad.Text);
            kmtguncelleme.Parameters.AddWithValue("@p3", cmbsehir.Text);
            kmtguncelleme.Parameters.AddWithValue("@p4", mskmaas.Text);
            kmtguncelleme.Parameters.AddWithValue("@p5", label8.Text);
            kmtguncelleme.Parameters.AddWithValue("@p6", txtmeslek.Text);
            kmtguncelleme.Parameters.AddWithValue("@p7", txtid.Text);
            kmtguncelleme.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişi Başarıyla Güncellenmiştir"); 
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmtsil = new SqlCommand("Delete From Tbl_personel Where perid=@k1", baglanti);
            kmtsil.Parameters.AddWithValue("@k1", txtid.Text);
            kmtsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişi Silindi");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frm_istatistik frm2 = new Frm_istatistik();
            frm2.Show();
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm3 = new FrmGrafikler();
            frm3.Show(); 
        }
    }
}
