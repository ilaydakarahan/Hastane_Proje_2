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
    public partial class SekreterGiris : Form
    {
        public SekreterGiris()
        {
            InitializeComponent();
        }

        Class_Hastane bgl=new Class_Hastane();
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Table_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr= komut.ExecuteReader();
            if (dr.Read()) 
            {
                SekreterDetay frs= new SekreterDetay();
                frs.tc=MskTC.Text;
                frs.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Hatalı şifre yada tc");
            }
            bgl.baglanti().Close();
        }
    }
}
