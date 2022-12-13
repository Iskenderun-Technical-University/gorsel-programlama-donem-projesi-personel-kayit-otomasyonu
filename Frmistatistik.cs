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

namespace SinavHazirlik2
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(" Data Source=.;Initial Catalog=SinavHazirlik2;Integrated Security=True");
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            


            //Toplam Personel Sayısı

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                label2.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //Evli Personel Sayısı


            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From tbl_Personel where perdurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                label3.Text = dr2[0].ToString();
            }
            baglanti.Close();


            //bekar Personel Sayısı


            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From tbl_Personel where perdurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                label5.Text = dr3[0].ToString();
            }
            baglanti.Close();



            //şehir Sayısı


            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count( distinct (perSehir)) From tbl_Personel ", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                label7.Text = dr4[0].ToString();
            }
            baglanti.Close();


            //toplam maaş

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(permaas) from tbl_Personel",baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                label10.Text = dr5[0].ToString();
            }
            baglanti.Close();


            //ortalama maaş

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(permaas) from tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                label12.Text = dr6[0].ToString();
            }
            baglanti.Close();

        }

        
    }
}
    