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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(" Data Source=.;Initial Catalog=SinavHazirlik2;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Tbl_Yonetici where kullaniciAd=@p1 and sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                Form1 form = new Form1();
                form.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show(  "hatalı giriş"  );
            }


            baglanti.Close();

        }
    }
}
