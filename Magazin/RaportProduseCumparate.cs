using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin
{
    public partial class RaportProduseCumparate : Form
    {
        public RaportProduseCumparate()
        {
            InitializeComponent();
        }

        private void RaportProduseCumparate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parfumerieDataSet1.Facturi' table. You can move, or remove it, as needed.
            this.facturiTableAdapter.Fill(this.parfumerieDataSet1.Facturi);

        }
    }
}
