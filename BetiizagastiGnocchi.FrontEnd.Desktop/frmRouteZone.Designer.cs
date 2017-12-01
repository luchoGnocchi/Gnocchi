namespace BetiizagastiGnocchi.FrontEnd.Desktop
{
	partial class frmRouteZone
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
            this.cbZone = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.routeZoneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.routeZoneBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.zonesToPassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.routeZoneBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeZoneBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbZone
            // 
            this.cbZone.FormattingEnabled = true;
            this.cbZone.Location = new System.Drawing.Point(60, 61);
            this.cbZone.Name = "cbZone";
            this.cbZone.Size = new System.Drawing.Size(121, 21);
            this.cbZone.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zona";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(187, 59);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(268, 59);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // routeZoneBindingSource
            // 
            this.routeZoneBindingSource.DataSource = typeof(BetizagastiGnocchi.BackEnd.Domain.Entities.RouteZone);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.zonesToPassDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.routeZoneBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(397, 188);
            this.dataGridView1.TabIndex = 5;
            // 
            // routeZoneBindingSource1
            // 
            this.routeZoneBindingSource1.DataSource = typeof(BetizagastiGnocchi.BackEnd.Domain.Entities.RouteZone);
            // 
            // zonesToPassDataGridViewTextBoxColumn
            // 
            this.zonesToPassDataGridViewTextBoxColumn.DataPropertyName = "ZonesToPass";
            this.zonesToPassDataGridViewTextBoxColumn.HeaderText = "ZonesToPass";
            this.zonesToPassDataGridViewTextBoxColumn.Name = "zonesToPassDataGridViewTextBoxColumn";
            // 
            // frmRouteZone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 323);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbZone);
            this.Name = "frmRouteZone";
            this.Text = "frmRouteZone";
            this.Load += new System.EventHandler(this.frmRouteZone_Load);
            ((System.ComponentModel.ISupportInitialize)(this.routeZoneBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeZoneBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ComboBox cbZone;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.BindingSource routeZoneBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource routeZoneBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn zonesToPassDataGridViewTextBoxColumn;
    }
}