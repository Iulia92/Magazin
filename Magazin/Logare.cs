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
    public partial class Logare : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ATM4D3I\SQLEXPRESS;Initial Catalog=Parfumerie;Integrated Security=True");
        public Logare()
        {
            InitializeComponent();
        }
        
       private void Logare_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
      
        private void button2_Click(object sender, EventArgs e)
        {

            int i = 0;
            SqlDataAdapter sdf = new SqlDataAdapter("select id_rol from  Angajati where utilizator ='" + textBox1.Text + "' and parola= '" + textBox2.Text + "' ", con);
            DataTable dt = new DataTable();
            sdf.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("Utilizator sau parola gresite");

            }


            else if (dt.Rows.Count == 1)
            {
                
                if (dt.Rows[0][0].ToString() != "Admin")
                {


                    MDIParent1 m1 = new MDIParent1(dt.Rows[0][0].ToString());
                    Factura fact1 = new Factura();
                    m1.Show();
                    fact1.Hide();
                    this.Hide();

                }
               
            }

            else if (dt.Rows.Count == 2)
            {

                MDIParent1 m1 = new MDIParent1(dt.Rows[0][0].ToString());
               
                m1.Hide();
                Factura fact1 = new Factura();
                fact1.Show();



            }



        }
            }
          

            


            

        }
    



