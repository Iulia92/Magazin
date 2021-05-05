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
    public partial class DetaliiRaport : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ATM4D3I\SQLEXPRESS;Initial Catalog=Parfumerie;Integrated Security=True");

        public DetaliiRaport()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Produse";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
             da.Fill(dt);
            dataGridView1.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["pret_total"].ToString());
            }

            label3.Text = i.ToString();
        }

        private void DetaliiRaport_Load(object sender, EventArgs e)
        {
            if(con.State== ConnectionState.Open)
            {

                con.Close();

            }
            con.Open();
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
       
           

            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Produse where produs = '"+textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["pret_total"].ToString());
            }

         
        }
    }
}
