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
    public partial class Produse : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ATM4D3I\SQLEXPRESS;Initial Catalog=Parfumerie;Integrated Security=True");
        public Produse()
        {
            InitializeComponent();
        }

        private void Produse_Load(object sender, EventArgs e)
        {
 
           this.unitatiTableAdapter.Fill(this.parfumerieDataSet.Unitati);         
           this.categoriiTableAdapter.Fill(this.parfumerieDataSet.Categorii);           
           this.producatoriTableAdapter.Fill(this.parfumerieDataSet.Producatori);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            filldgv();
        }

        public void filldgv()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Produse";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from Stoc where nume_produs = '" + textBox2.Text + "'";
            cmd2.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
            da1.Fill(dt1);
            i = Convert.ToInt32(dt1.Rows.Count.ToString());
            if (i == 0)
            {


                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "INSERT into Produse (id_producator, produs,unitate,descriere,id_parfum,cantitate_pro,pret_prod,pret_total,profit) values ('" + comboBox1.SelectedValue.ToString() + "','" + textBox1.Text + "','" + comboBox2.SelectedValue.ToString() + "','" + textBox2.Text + "','" + comboBox3.SelectedValue.ToString() + "','" + textBox3.Text + "','" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "')";
                cmd1.ExecuteNonQuery();
               // textBox2.Text = ""; textBox3.Text = "";
               // textBox5.Text = ""; textBox6.Text = "";
                filldgv();
         
                SqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "INSERT into Stoc(nume_produs,cant_produs)  values ('" + textBox1.Text + "','" + textBox3.Text + "')";
                cmd3.ExecuteNonQuery();

            }
            else
            {

                SqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "INSERT into Produse (id_producator, produs,unitate,descriere,id_parfum,pret_prod,pret_total,cantitate_pro) values ('" + comboBox1.SelectedValue.ToString() + "','" + textBox1.Text + "','" + comboBox2.SelectedValue.ToString() + "','" + textBox2.Text + "','" + comboBox3.SelectedValue.ToString() + "','" + textBox3.Text + "','" + textBox4.Text + "', '" + textBox5.Text + "' + '" + textBox6.Text + "')";
                cmd4.ExecuteNonQuery();

                SqlCommand cmd5 = con.CreateCommand();
                cmd5.CommandType = CommandType.Text;
                cmd5.CommandText = "Update Stoc set cant_produs = cantitate_pro + '" + textBox3.Text + "' where nume_produs = '" + textBox1.Text + "'  ";
                cmd5.ExecuteNonQuery();
            }
            MessageBox.Show("Datele au fost adaugate");           
        }
       
       private void textBox5_Leave(object sender, EventArgs e)

        {         
           textBox5.Text = Convert.ToString( Convert.ToInt32(textBox3.Text) * Convert.ToInt32(textBox4.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Produse where id_produs=" + id + "";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox6.SelectedValue = dr["id_producator"].ToString();
                textBox8.Text = dr["produs"].ToString();
                comboBox7.Text = dr["unitate"].ToString();
                comboBox5.SelectedValue = dr["id_parfum"].ToString();
                textBox12.Text = dr["cantitate_pro"].ToString();
                textBox14.Text = dr["pret_prod"].ToString();
                textBox13.Text = dr["pret_total"].ToString();
                textBox11.Text = dr["profit"].ToString();
            }



        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            textBox13.Text = Convert.ToString(Convert.ToInt32(textBox12.Text) * Convert.ToInt32(textBox14.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "update Produse set id_producator='" + comboBox6.SelectedValue.ToString() + "' , produs = '" + textBox8.Text + "', unitate = '" + comboBox7.SelectedValue.ToString() + "', descriere = '" + textBox7.Text + "',id_parfum= '" + comboBox5.SelectionLength.ToString() + "',pret_prod='"+textBox14.Text+"',cantitate_pro='"+textBox12.Text+"',pret_total='"+textBox13.Text+"',profit='"+textBox11.Text+"' where id_produs =" + id + "";
            cmd2.ExecuteNonQuery();
            panel3.Visible = false;
          filldgv();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Produse where id_produs=" + id + "";
            cmd.ExecuteNonQuery();


        }
    }
}



   


        





    

       
    

