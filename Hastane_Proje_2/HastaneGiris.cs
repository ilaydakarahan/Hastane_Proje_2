using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Proje_2
{
    public partial class HastaneGiris : Form
    {
        public HastaneGiris()
        {
            InitializeComponent();
        }

        private void btnhasta_Click(object sender, EventArgs e)
        {
            HastaGiris fr=new HastaGiris();
            fr.Show();
            this.Hide();
        }

        private void btndoktor_Click(object sender, EventArgs e)
        {
            DoktorGiris dr=new DoktorGiris();
            dr.Show();
            this.Hide();
        }

        private void btnsekrtr_Click(object sender, EventArgs e)
        {
            SekreterGiris sk=new SekreterGiris();
            sk.Show();
            this.Hide();
        }
    }
}
