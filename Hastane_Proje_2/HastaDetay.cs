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
    public partial class HastaDetay : Form
    {
        public HastaDetay()
        {
            InitializeComponent();
        }

        public string tc;

        Class_Hastane bgl = new Class_Hastane();
        private void HastaDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;
            //Ad Soyad Çekme
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad from Table_Hasta Where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //Randevu Geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Randevu where HastaTC=" + lbltc.Text, bgl.baglanti());
            da.Fill(dt);
            dataGridView2gecmis.DataSource = dt;

            //branş çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Table_Brans", bgl.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read()) 
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();

            SqlCommand komut3=new SqlCommand("Select DoktorAd,DoktorSoyad From Table_Doktor where DoktorBrans=@p1",bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1",cmbbrans.Text);
            SqlDataReader dr3=komut3.ExecuteReader();
            while (dr3.Read()) 
            {
                cmbdoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        //Branş ve doktor seçince aktif randevu kısmına datagrid tablosunun gelmesi
        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Randevu where RandevuBrans= '" + cmbbrans.Text + "' and RandevuDoktor= '"+cmbdoktor.Text+"' and RandevuDurum=0",bgl.baglanti());
            da.Fill(dt);
            dataGridView1aktf.DataSource = dt;
        }

        private void lnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaBilgiDuzenle fr=new HastaBilgiDuzenle();
            fr.tc = lbltc.Text;
            fr.Show();
        }

        private void dataGridView1aktf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1aktf.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1aktf.Rows[secilen].Cells[0].Value.ToString();
            
        }

        private void btnrandevual_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Table_Randevu set RandevuDurum=1, HastaTC=@p1,HastaSikayet=@p2 where Randevuid=@p3",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",lbltc.Text);
            komut.Parameters.AddWithValue("@p2",richsikayet.Text);
            komut.Parameters.AddWithValue("@p3",txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu alındı.");
        }
    }
}
