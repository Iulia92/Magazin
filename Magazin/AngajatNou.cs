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
    public partial class AngajatNou : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ATM4D3I\SQLEXPRESS;Initial Catalog=Parfumerie;Integrated Security=True");
        public AngajatNou()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
           

                int i = 0;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Angajati where utilizator ='" + textBox9.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());


                if (i == 0)
                {

                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText  = "INSERT into Angajati (nume_angajat,data_angajari, data_nasteri, adresa, telefon, gen, salariu, email, utilizator, parola,id_rol) VALUES ('" + textBox1.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + dateTimePicker2.Value.ToShortDateString() + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + comboBox2.SelectedValue.ToString() + "')";
                    cmd1.ExecuteNonQuery();

                    textBox1.Text = "";
                    textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";
                    textBox7.Text = ""; textBox8.Text = ""; textBox9.Text = "";
                    textBox10.Text = "";  
                    display();
                    MessageBox.Show("Datele au fost adaugate cu succes");

                }

                else
                {
                    MessageBox.Show("utilizator-ul exista deja");

                }
            }
        
        private void AngajatNou_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parfumerieDataSet.Roluri' table. You can move, or remove it, as needed.
            this.roluriTableAdapter.Fill(this.parfumerieDataSet.Roluri);
            // TODO: This line of code loads data into the 'parfumerieDataSet3.Roluri' table. You can move, or remove it, as needed.


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void display()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Angajati";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            id=Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd =  con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Angajati where Id_anagajat=" + id + "";
            cmd.ExecuteNonQuery();
            display();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Angajati where Id_anagajat=" + id + "";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                textBox11.Text = dr["nume_angajat"].ToString();
                dateTimePicker4.Text = dr["data_angajari"].ToString();
                dateTimePicker3.Text = dr["data_nasteri"].ToString();
                textBox3.Text = dr["adresa"].ToString();
                textBox2.Text = dr["telefon"].ToString();
                textBox16.Text = dr["gen"].ToString();
                textBox15.Text = dr["salariu"].ToString();
                textBox14.Text = dr["email"].ToString();
                textBox13.Text = dr["utilizator"].ToString();
                textBox12.Text = dr["parola"].ToString();
                comboBox1.Text = dr["id_rol"].ToString();

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Angajati set nume_angajat='" + textBox11.Text + "' , data_angajari = '" + dateTimePicker4.Value.ToString() + "', data_nasteri = '" + dateTimePicker3.Value.ToString() + "', adresa = '" + textBox3.Text + "',telefon= '" + textBox12.Text + "',gen= '" + textBox16.Text + "',salariu= '" + textBox15.Text + "',email= '" + textBox14.Text + "',utilizator= '" + textBox13.Text + "',email= '" + textBox12.Text + "',id_rol= '" + comboBox2.SelectedValue + "' where Id_anagajat =" + id + "";
            cmd.ExecuteNonQuery();
            panel2.Visible = false;
            display();
        }

       
    }
}

