using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hastane_Proje_2
{
    class Class_Hastane
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-BFPJH2M\\;Initial Catalog=HastaneProje2;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
