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

namespace Hastane_Proje_2
{
    public partial class Doktorpaneli : Form
    {
        public Doktorpaneli()
        {
            InitializeComponent();
        }

        public void TabloGuncelle() 
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Doktor", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void Temizle() 
        {
            txtad.Clear();
            txtsoyad.Clear();
            msktc.Clear();
            cmbbrans.Text = " ";
            txtsifre.Clear();
        }

        Class_Hastane bgl = new Class_Hastane();

        private void Doktorpaneli_Load(object sender, EventArgs e)
        {
           TabloGuncelle();

            //Branşları comboboxa çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Table_Brans",bgl.baglanti());
            SqlDataReader dr2= komut2.ExecuteReader();
            while (dr2.Read()) 
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("insert into Table_Doktor (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)",bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtad.Text);
            komut.Parameters.AddWithValue("@d2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@d3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@d4",msktc.Text);
            komut.Parameters.AddWithValue("@d5",txtsifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            TabloGuncelle();
            MessageBox.Show("kaydınız oluşturuldu.");
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbbrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msktc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut3=new SqlCommand("Delete from Table_Doktor where DoktorTC=@p1",bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1",msktc.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            TabloGuncelle();
            MessageBox.Show("Kaydınız silindi.","bilgi",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            Temizle();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Table_Doktor set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,DoktorSifre=@d5 where DoktorTC=@d4",bgl.baglanti());
            komut.Parameters.AddWithValue("@d1",txtad.Text);
            komut.Parameters.AddWithValue("@d2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@d3",cmbbrans.Text);
            komut.Parameters.AddWithValue("@d4",msktc.Text);
            komut.Parameters.AddWithValue("@d5",txtsifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            TabloGuncelle();
            MessageBox.Show("Kaydınız Güüncellendi");
            Temizle() ;
        }
    }
}
