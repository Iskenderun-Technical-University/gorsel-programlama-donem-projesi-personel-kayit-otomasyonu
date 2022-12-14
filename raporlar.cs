using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinavHazirlik2
{
    public partial class raporlar : Form
    {
        public raporlar()
        {
            InitializeComponent();
        }

        private void raporlar_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'sinavHazirlik2DataSet1.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter.Fill(this.sinavHazirlik2DataSet1.Tbl_Personel);

        }
    }
}
