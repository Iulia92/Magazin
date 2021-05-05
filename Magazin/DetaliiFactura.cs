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

namespace Magazin
{
    public partial class DetaliiFactura : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-ATM4D3I\SQLEXPRESS;Initial Catalog=Parfumerie;Integrated Security=True");
        int j;
        int tot = 0;
        public DetaliiFactura()
        {
            InitializeComponent();
        }

        public void val(int i)
        {
            j = 1;
        }


        private void DetaliiFactura_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            ParfumerieDataSet ds = new ParfumerieDataSet();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Clienti where id_client=" + j + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds.DataTable1);

            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from ProduseCumparate where id_cump=" + j + "";
            cmd1.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
            da2.Fill(ds.DataTable2);
            da2.Fill(dt2);

            tot = 0;
            foreach (DataRow dr2 in dt2.Rows)
            {
                tot = tot + Convert.ToInt32(dr2["total"].ToString());
            }
            CrystalReport1 rap = new CrystalReport1();
            rap.SetDataSource(ds);
            rap.SetParameterValue("total", tot.ToString());
            crystalReportViewer1.ReportSource = rap;


        }
    }
}
