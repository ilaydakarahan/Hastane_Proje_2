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
using System.Data.Common;

namespace Hastane_Proje_2
{
    public partial class SekreterDetay : Form
    {
        public SekreterDetay()
        {
            InitializeComponent();
        }
        public string tc;

        Class_Hastane bgl=new Class_Hastane();
        private void SekreterDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;

            //Ad Soyad
            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad From Table_Sekreter where SekreterTC=@p1",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1",lbltc.Text);
            SqlDataReader dr1= komut1.ExecuteReader();
            while(dr1.Read()) 
            {
                lbladsoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //Branşları datagride aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Table_Brans",bgl.baglanti());
            da.Fill(dt);
            dataGridView1brans.DataSource = dt;

            //Doktorları datagride çekme
            DataTable dt2= new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd+ ' ' +DoktorSoyad) as 'Doktorlar',DoktorBrans From Table_Doktor",bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2doktor.DataSource = dt2;

            //Branşı comboboxa aktarma
            SqlCommand komut2 = new SqlCommand("Select BransAd From Table_Brans",bgl.baglanti());
            SqlDataReader dr2= komut2.ExecuteReader();
            while(dr2.Read()) 
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();  

        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();

            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Table_Doktor where DoktorBrans=@p1",bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr3= komut3.ExecuteReader();
            while(dr3.Read()) 
            {
                cmbdoktor.Items.Add(dr3[0]+ " " + dr3[1]);
            }
            bgl.baglanti() .Close();
        }

        //Randevu Kaydetme
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Table_Randevu (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)",bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1", msktarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2",msksaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3",cmbbrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4",cmbdoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız oluşturuldu.");

        }

        private void btnolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Table_Duyuru (Duyurular) values (@d1)",bgl.baglanti());
            komut.Parameters.AddWithValue("@d1",richduyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru oluşturuldu.");
        }

        private void btndoktorpaneli_Click(object sender, EventArgs e)
        {
            Doktorpaneli dp= new Doktorpaneli();
            dp.Show();
        }

        private void btnbranspaneli_Click(object sender, EventArgs e)
        {
            BransPaneli bp= new BransPaneli();
            bp.Show();
        }

        private void btnrandevulistele_Click(object sender, EventArgs e)
        {
            RandevuListesi rl= new RandevuListesi();
            rl.Show();
        }

        private void btnduyurular_Click(object sender, EventArgs e)
        {
            Duyuru dr= new Duyuru();
            dr.Show();
        }
        
    }
}
