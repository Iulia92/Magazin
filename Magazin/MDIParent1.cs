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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public static MDIParent1 mdiobj;
        public MDIParent1(string id_rol)
        {

            InitializeComponent();
            label11.Text = id_rol;
            
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void adaugaUtilizatorNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AngajatNou ang = new AngajatNou();
            ang.Show();
        }

        private void adaugaUnitateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unitati un = new Unitati();
            un.Show();
        }

        private void adaugaProducatorNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Producatori pr = new Producatori();
            pr.Show();
        }

        private void adaugaProdusNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produse pro = new Produse();
            pro.Show();
        }

        private void adaugaCategorieNouaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categorii cat = new Categorii();
            cat.Show();
        }

        private void facturaNouaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factura fact = new Factura();
            fact.Show();
        }

        private void detaliiFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetaliiRaport rap = new DetaliiRaport();
            rap.Show();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            if (label11.Text == "1")
            {
                menuStrip.Visible = true;
                menuStrip1.Visible = false;
            }
            else
            {
                menuStrip.Visible = false;
                menuStrip1.Visible = true;

            }
        }

        private void facturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Factura fc1 = new Factura();
            fc1.Show();
        }

        private void raportProduseCumparateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaportProduseCumparate pro = new RaportProduseCumparate();

            pro.Show();
        }

        private void produseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
