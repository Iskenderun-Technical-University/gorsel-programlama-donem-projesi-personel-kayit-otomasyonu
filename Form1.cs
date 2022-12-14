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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(" Data Source=.;Initial Catalog=SinavHazirlik2;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            SqlDataAdapter da = new SqlDataAdapter("select *from tbl_personel",baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "tbl_personel");
            dataGridView1.DataSource = ds.Tables["tbl_personel"];
            baglanti.Close();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.sinavHazirlik2DataSet.Tbl_Personel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerDurum,PerMeslek) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1",textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5", label8.Text);
            komut.Parameters.AddWithValue("@p6", textBox4.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("personel eklendi...");
            this.tbl_PersonelTableAdapter.Fill(this.sinavHazirlik2DataSet.Tbl_Personel);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
              label8.Text=("true");
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
               label8.Text = ("false");
            }
            
        }
        public void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            maskedTextBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox2.Focus();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            temizle();

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
           
            textBox4.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutSil = new SqlCommand("Delete From tbl_Personel where Perid=@k1",baglanti);
            komutSil.Parameters.AddWithValue("@k1", textBox1.Text);
            komutSil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kayıt silindi...");
            this.tbl_PersonelTableAdapter.Fill(this.sinavHazirlik2DataSet.Tbl_Personel);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutGuncelle = new SqlCommand("update Tbl_Personel Set perAd=@a1, perSoyad=@a2, perSehir=@a3, perMaas=@a4, perDurum=@a5, perMeslek=@a6 where perid=@a7",baglanti);
            komutGuncelle.Parameters.AddWithValue("@a1", textBox2.Text);
            komutGuncelle.Parameters.AddWithValue("@a2", textBox3.Text);
            komutGuncelle.Parameters.AddWithValue("@a3", comboBox1.Text);
            komutGuncelle.Parameters.AddWithValue("@a4", maskedTextBox1.Text);
            komutGuncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutGuncelle.Parameters.AddWithValue("@a6", textBox4.Text);
            komutGuncelle.Parameters.AddWithValue("@a7", textBox1.Text);
            komutGuncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("personel güncellendi...");
            this.tbl_PersonelTableAdapter.Fill(this.sinavHazirlik2DataSet.Tbl_Personel);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frmistatistik frmi = new Frmistatistik();
            frmi.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            raporlar rp = new raporlar();
            rp.Show();
            this.Hide();
        }
    }
}
