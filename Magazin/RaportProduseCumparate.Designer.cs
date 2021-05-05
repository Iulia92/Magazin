namespace Magazin
{
    partial class RaportProduseCumparate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.parfumerieDataSet = new Magazin.ParfumerieDataSet();
            this.parfumerieDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.parfumerieDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.parfumerieDataSet1 = new Magazin.ParfumerieDataSet1();
            this.facturiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturiTableAdapter = new Magazin.ParfumerieDataSet1TableAdapters.FacturiTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcumpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pretDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantitateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idclientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parfumerieDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parfumerieDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parfumerieDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parfumerieDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.idcumpDataGridViewTextBoxColumn,
            this.produsDataGridViewTextBoxColumn,
            this.pretDataGridViewTextBoxColumn,
            this.cantitateDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.idclientDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.facturiBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // parfumerieDataSet
            // 
            this.parfumerieDataSet.DataSetName = "ParfumerieDataSet";
            this.parfumerieDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // parfumerieDataSetBindingSource
            // 
            this.parfumerieDataSetBindingSource.DataSource = this.parfumerieDataSet;
            this.parfumerieDataSetBindingSource.Position = 0;
            // 
            // parfumerieDataSetBindingSource1
            // 
            this.parfumerieDataSetBindingSource1.DataSource = this.parfumerieDataSet;
            this.parfumerieDataSetBindingSource1.Position = 0;
            // 
            // parfumerieDataSet1
            // 
            this.parfumerieDataSet1.DataSetName = "ParfumerieDataSet1";
            this.parfumerieDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // facturiBindingSource
            // 
            this.facturiBindingSource.DataMember = "Facturi";
            this.facturiBindingSource.DataSource = this.parfumerieDataSet1;
            // 
            // facturiTableAdapter
            // 
            this.facturiTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idcumpDataGridViewTextBoxColumn
            // 
            this.idcumpDataGridViewTextBoxColumn.DataPropertyName = "id_cump";
            this.idcumpDataGridViewTextBoxColumn.HeaderText = "id_cump";
            this.idcumpDataGridViewTextBoxColumn.Name = "idcumpDataGridViewTextBoxColumn";
            // 
            // produsDataGridViewTextBoxColumn
            // 
            this.produsDataGridViewTextBoxColumn.DataPropertyName = "produs";
            this.produsDataGridViewTextBoxColumn.HeaderText = "produs";
            this.produsDataGridViewTextBoxColumn.Name = "produsDataGridViewTextBoxColumn";
            // 
            // pretDataGridViewTextBoxColumn
            // 
            this.pretDataGridViewTextBoxColumn.DataPropertyName = "pret";
            this.pretDataGridViewTextBoxColumn.HeaderText = "pret";
            this.pretDataGridViewTextBoxColumn.Name = "pretDataGridViewTextBoxColumn";
            // 
            // cantitateDataGridViewTextBoxColumn
            // 
            this.cantitateDataGridViewTextBoxColumn.DataPropertyName = "cantitate";
            this.cantitateDataGridViewTextBoxColumn.HeaderText = "cantitate";
            this.cantitateDataGridViewTextBoxColumn.Name = "cantitateDataGridViewTextBoxColumn";
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            // 
            // idclientDataGridViewTextBoxColumn
            // 
            this.idclientDataGridViewTextBoxColumn.DataPropertyName = "id_client";
            this.idclientDataGridViewTextBoxColumn.HeaderText = "id_client";
            this.idclientDataGridViewTextBoxColumn.Name = "idclientDataGridViewTextBoxColumn";
            // 
            // RaportProduseCumparate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RaportProduseCumparate";
            this.Text = "RaportProduseCumparate";
            this.Load += new System.EventHandler(this.RaportProduseCumparate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parfumerieDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parfumerieDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parfumerieDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parfumerieDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturiBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource parfumerieDataSetBindingSource;
        private ParfumerieDataSet parfumerieDataSet;
        private System.Windows.Forms.BindingSource parfumerieDataSetBindingSource1;
        private ParfumerieDataSet1 parfumerieDataSet1;
        private System.Windows.Forms.BindingSource facturiBindingSource;
        private ParfumerieDataSet1TableAdapters.FacturiTableAdapter facturiTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcumpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn produsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pretDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantitateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idclientDataGridViewTextBoxColumn;
    }
}