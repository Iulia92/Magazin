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
    public partial class Factura : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ATM4D3I\SQLEXPRESS;Initial Catalog=Parfumerie;Integrated Security=True");
        DataTable dt = new DataTable();

        int tot = 0;
   
 
            
       



        public Factura()
        {
            
            InitializeComponent();
      
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            dt.Clear();
            dt.Columns.Add("produs");
            dt.Columns.Add("pret");
            dt.Columns.Add("cant");
            dt.Columns.Add("total");
        }



        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            listBox1.Visible = true;
            listBox1.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Stoc where nume_produs like ('" + textBox3.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["nume_produs"].ToString());
            }
        }



        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.listBox1.SelectedIndex = this.listBox1.SelectedIndex + 1;
                }

                if (e.KeyCode == Keys.Up)
                {
                    this.listBox1.SelectedIndex = this.listBox1.SelectedIndex - 1;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    textBox3.Text = listBox1.SelectedItem.ToString();
                    listBox1.Visible = false;
                    textBox4.Focus();
                }
            }

            catch (Exception ex)
            {

            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select top 1 * from Produse where produs = '" + textBox3.Text + "' order by id_produs desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox4.Text = dr["pret_prod"].ToString();
            }

        }


        private void textBox6_Enter(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = Convert.ToString(Convert.ToInt32(textBox4.Text) * Convert.ToInt32(textBox5.Text));
            }
            catch (Exception ex)
            {

            }
        }


        






        private void button1_Click(object sender, EventArgs e)
        {
            int stoc = 0;
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Select * from Stoc where nume_produs='" + textBox3.Text + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                stoc = Convert.ToInt32(dr1["cant_produs"].ToString());
            }
            if (Convert.ToInt32(textBox5.Text)>stoc)
            {
                MessageBox.Show("Valoarea nu este disponibila");
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["produs"] = textBox3.Text;
                dr["pret"] = textBox4.Text;
                dr["cant"] = textBox5.Text;
                dr["total"] = textBox6.Text;
                dt.Rows.Add(dr);
                dataGridView1.DataSource = dt;
                tot = tot + Convert.ToInt32(dr["total"].ToString());
                label10.Text = tot.ToString();


            }
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                tot = 0;
                dt.Rows.RemoveAt(Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString()));
                foreach (DataRow dr1 in dt.Rows)
                {
                    tot = tot+ Convert.ToInt32(dr1["total"].ToString());
                    label10.Text = tot.ToString();
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          string idcump = "";
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "INSERT into Clienti (nume,prenume,plata_cumparare,data_cumparare) VALUES ('" +textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text.ToString() + "','"+ dateTimePicker1.Value.ToString("dd/MM/yyyy") + "') ";
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select top 1 * from Clienti order by id_client desc";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach(DataRow dr2 in dt2.Rows)
            {
                idcump = dr2["id_client"].ToString();
            } 
                foreach(DataRow dr in dt.Rows)
            {
                int cant = 0;
                string pnume = "";
                
                SqlCommand cmd8 = con.CreateCommand();
                cmd8.CommandType = CommandType.Text;
                cmd8.CommandText = "insert into Facturi(id_cump,produs,pret,cantitate,total) values ('"+idcump.ToString()+"','" + dr["produs"].ToString() + "','" + dr["pret"].ToString() + "','" + dr["cant"].ToString() + "','"+ dr["total"].ToString() + "') ";
                cmd8.ExecuteNonQuery();

               cant = Convert.ToInt32(dr["cant"].ToString());
               pnume = dr["produs"].ToString();

               SqlCommand cmd6 = con.CreateCommand();
               cmd6.CommandType = CommandType.Text;
              cmd6.CommandText = "Update Stoc set cant_produs = cant_produs-"+ cant +" where nume_produs = '"+pnume.ToString()+"' ";
              cmd6.ExecuteNonQuery();

            }       
            textBox1.Text = "";
            textBox2.Text = "";            
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            label10.Text = "";
            dt.Clear();
            dataGridView1.DataSource = dt;
            MessageBox.Show("Datele au fost adaugate");

        }

        private void button4_Click(object sender, EventArgs e)
        {

            string idcump = "";
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "INSERT into Clienti (nume,prenume,plata_cumparare,data_cumparare) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text.ToString() + "','" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "') ";
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select top 1 * from Clienti order by id_client desc";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                idcump = dr2["id_client"].ToString();
            }
            foreach (DataRow dr in dt.Rows)
            {
                int cant = 0;
                string pnume = "";

                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "insert into Facturi values ('" + idcump.ToString() + "','" + dr["produs"].ToString() + "','" + dr["pret"].ToString() + "','" + dr["cant"].ToString() + "','" + dr["total"].ToString() + "') ";
                cmd3.ExecuteNonQuery();

                cant = Convert.ToInt32(dr["cantitate"].ToString());
                pnume = dr["produs"].ToString();

                SqlCommand cmd6 = con.CreateCommand();
                cmd6.CommandType = CommandType.Text;
                cmd6.CommandText = "Update Stoc set cant_produs = cant_produs-" + cant + " where nume_produs = '" + pnume.ToString() + "' ";
                cmd6.ExecuteNonQuery();

            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            label10.Text = "";
            dt.Clear();
            dataGridView1.DataSource = dt;




        }

    }

       
    
           
    }

