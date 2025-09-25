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
    public partial class Frm_istatistik : Form
    {
        public Frm_istatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-ERHK7L8;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void Frm_istatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select count(*) From Tbl_personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                label4.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //Evli Personel sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                label5.Text = dr2[0].ToString();
            }
            baglanti.Close();

            // Bekar personel sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=0 ",baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {

                label6.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //Şehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count(distinct(Persehir)) From Tbl_Personel",baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                label8.Text = dr4[0].ToString();
            }
            baglanti.Close();

            // Toplam mmaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(PerMaas) From Tbl_personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                label9.Text = dr5[0].ToString();
            }
            baglanti.Close();

            // Ortalama Maaş
            baglanti.Open ();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                label11.Text = dr6[0].ToString(); 
            }
            baglanti.Close ();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
