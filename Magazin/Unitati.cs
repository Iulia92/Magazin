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
    public partial class Unitati : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ATM4D3I\SQLEXPRESS;Initial Catalog=Parfumerie;Integrated Security=True");
        public Unitati()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Unitati where id_unitate = " + id + "";
            cmd.ExecuteNonQuery();
            disp();

        }

        private void Unitati_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            disp();
        }

        public void disp()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Unitati";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from Unitati where unitate = '"+textBox1.Text+"' ";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt1);
            count = Convert.ToInt32(dt1.Rows.Count.ToString());

            if (count == 0)
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Unitati values('" + textBox1.Text + "')";
                cmd.ExecuteNonQuery();
                disp();
            }
            else
            {
                MessageBox.Show("Aceasta unitate exista...adauga alta");
            }
        }
    }
}
