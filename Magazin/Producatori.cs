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
    public partial class Producatori : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ATM4D3I\SQLEXPRESS;Initial Catalog=Parfumerie;Integrated Security=True");
        public Producatori()
        {
            InitializeComponent();
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Producatori where producator ='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());


            if (i == 0)
            {

                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = cmd2.CommandText = "INSERT into Producatori (producator, website, telefon, locatie, email) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                cmd2.ExecuteNonQuery();

                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
                textBox4.Text = ""; textBox5.Text = "";              
                display();
                MessageBox.Show("Producatorul a fost adaugat cu succes");

            }

            else
            {
                MessageBox.Show("Producatorul-ul exista deja");

            }
        }

        private void Producatori_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            display();
        }

        public void display()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Producatori";
            cmd.ExecuteNonQuery();
         
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;



        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType= CommandType.Text;
            cmd.CommandText = "delete from Producatori where id_producator=" + id + "";
            cmd.ExecuteNonQuery();
            
           
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd= con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Producatori where id_producator=" + id + "";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                textBox6.Text = dr["producator"].ToString();
                textBox7.Text = dr["website"].ToString();
                textBox8.Text = dr["telefon"].ToString();
                textBox9.Text = dr["locatie"].ToString();
                textBox10.Text = dr["email"].ToString();
            }



          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Producatori set producator='" +textBox6.Text  + "' , website = '"+textBox7.Text+"', telefon = '"+textBox8.Text+"', locatie = '"+textBox9.Text+"',email= '"+textBox10.Text+"' where id_producator ="+id+"";
            cmd.ExecuteNonQuery();
            panel2.Visible = false;
            display();
        }
    }
}
