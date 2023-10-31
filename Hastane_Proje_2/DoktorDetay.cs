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
    public partial class DoktorDetay : Form
    {
        public DoktorDetay()
        {
            InitializeComponent();
        }

        private void btnduyuru_Click(object sender, EventArgs e)
        {
            Duyuru dy=new Duyuru();
            dy.Show();
        }

        Class_Hastane bgl=new Class_Hastane();

        public string TC;
        private void DoktorDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = TC;

            //Ad Soyad labela çekme
            SqlCommand komut= new SqlCommand("Select DoktorAd,DoktorSoyad from Table_Doktor where DoktorTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",lbltc.Text);
            SqlDataReader dt=komut.ExecuteReader();
            while(dt.Read()) 
            {
                lbladsoyad.Text= dt[0] + " " + dt[1];
            }
            bgl.baglanti().Close();

            //Randevu listesi aktarma
            DataTable dt2=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Randevu where RandevuDoktor='"+ lbladsoyad.Text + "'",bgl.baglanti());
            da.Fill(dt2);
            dataGridView1.DataSource= dt2;
        }

        private void btnbilgi_Click(object sender, EventArgs e)
        {
            Doktorbilgidüzenle db=new Doktorbilgidüzenle();
            db.tc = lbltc.Text;
            db.Show();
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
