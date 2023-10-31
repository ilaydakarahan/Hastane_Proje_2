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
    public partial class DoktorGiris : Form
    {
        public DoktorGiris()
        {
            InitializeComponent();
        }

        Class_Hastane bgl= new Class_Hastane();
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("Select * From Table_Doktor where DoktorTC=@p1 and DoktorSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2",TxtSifre.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read()) 
            {
                DoktorDetay dt= new DoktorDetay();
                dt.TC=MskTC.Text;
                dt.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
            }
            bgl.baglanti().Close();
        }
    }
}
