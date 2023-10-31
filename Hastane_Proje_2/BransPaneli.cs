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
using System.Security;

namespace Hastane_Proje_2
{
    public partial class BransPaneli : Form
    {
        public BransPaneli()
        {
            InitializeComponent();
        }
        public void Temizle() 
        {
            txtid.Clear();
            txtbransad.Clear();
        }
        public void Guncelle() 
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Brans",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        Class_Hastane bgl= new Class_Hastane();
        private void BransPaneli_Load(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("insert into Table_Brans (BransAd) values (@b1)",bgl.baglanti());
            komut.Parameters.AddWithValue("@b1",txtbransad.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            Guncelle();
            MessageBox.Show("Kaydınız oluşturuldu.");
            Temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Table_Brans where Bransid=@b2",bgl.baglanti());
            komut.Parameters.AddWithValue("@b2",txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            Guncelle();
            MessageBox.Show("kaydınız silindi");
            Temizle();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Table_Brans set BransAd=@p1 where Bransid=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtbransad.Text);
            komut.Parameters.AddWithValue("@p2", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            Guncelle();
            MessageBox.Show("Güncelleme yapıldı.");
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int veri = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[veri].Cells[0].Value.ToString();
            txtbransad.Text = dataGridView1.Rows[veri].Cells[1].Value.ToString();

        }
    }
}
