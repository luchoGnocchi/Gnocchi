namespace BetizagastiGnocchi.FrontEnd.Desktop
{
	partial class frmVehicle
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
			this.brandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.batchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vehicleTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vINDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vehicleBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnUpdateVehicle = new System.Windows.Forms.Button();
			this.btnAddVehicle = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.brandDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn,
            this.batchDataGridViewTextBoxColumn,
            this.colorDataGridViewTextBoxColumn,
            this.vehicleTypeDataGridViewTextBoxColumn,
            this.vINDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.vehicleBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 41);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(778, 284);
			this.dataGridView1.TabIndex = 0;
			// 
			// brandDataGridViewTextBoxColumn
			// 
			this.brandDataGridViewTextBoxColumn.DataPropertyName = "Brand";
			this.brandDataGridViewTextBoxColumn.HeaderText = "Brand";
			this.brandDataGridViewTextBoxColumn.Name = "brandDataGridViewTextBoxColumn";
			// 
			// modelDataGridViewTextBoxColumn
			// 
			this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
			this.modelDataGridViewTextBoxColumn.HeaderText = "Model";
			this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
			// 
			// yearDataGridViewTextBoxColumn
			// 
			this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
			this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
			this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
			// 
			// batchDataGridViewTextBoxColumn
			// 
			this.batchDataGridViewTextBoxColumn.DataPropertyName = "Batch";
			this.batchDataGridViewTextBoxColumn.HeaderText = "Batch";
			this.batchDataGridViewTextBoxColumn.Name = "batchDataGridViewTextBoxColumn";
			// 
			// colorDataGridViewTextBoxColumn
			// 
			this.colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
			this.colorDataGridViewTextBoxColumn.HeaderText = "Color";
			this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
			// 
			// vehicleTypeDataGridViewTextBoxColumn
			// 
			this.vehicleTypeDataGridViewTextBoxColumn.DataPropertyName = "VehicleType";
			this.vehicleTypeDataGridViewTextBoxColumn.HeaderText = "VehicleType";
			this.vehicleTypeDataGridViewTextBoxColumn.Name = "vehicleTypeDataGridViewTextBoxColumn";
			// 
			// vINDataGridViewTextBoxColumn
			// 
			this.vINDataGridViewTextBoxColumn.DataPropertyName = "VIN";
			this.vINDataGridViewTextBoxColumn.HeaderText = "VIN";
			this.vINDataGridViewTextBoxColumn.Name = "vINDataGridViewTextBoxColumn";
			// 
			// vehicleBindingSource
			// 
			this.vehicleBindingSource.DataSource = typeof(BetizagastiGnocchi.BackEnd.Domain.Entities.Vehicle);
			// 
			// btnUpdateVehicle
			// 
			this.btnUpdateVehicle.Location = new System.Drawing.Point(634, 12);
			this.btnUpdateVehicle.Name = "btnUpdateVehicle";
			this.btnUpdateVehicle.Size = new System.Drawing.Size(75, 23);
			this.btnUpdateVehicle.TabIndex = 1;
			this.btnUpdateVehicle.Text = "Modificar";
			this.btnUpdateVehicle.UseVisualStyleBackColor = true;
			this.btnUpdateVehicle.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnAddVehicle
			// 
			this.btnAddVehicle.Location = new System.Drawing.Point(552, 12);
			this.btnAddVehicle.Name = "btnAddVehicle";
			this.btnAddVehicle.Size = new System.Drawing.Size(75, 23);
			this.btnAddVehicle.TabIndex = 3;
			this.btnAddVehicle.Text = "Agregar";
			this.btnAddVehicle.UseVisualStyleBackColor = true;
			this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
			// 
			// frmVehicle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(821, 363);
			this.Controls.Add(this.btnAddVehicle);
			this.Controls.Add(this.btnUpdateVehicle);
			this.Controls.Add(this.dataGridView1);
			this.Name = "frmVehicle";
			this.Text = "frmVehicle";
			this.Load += new System.EventHandler(this.frmVehicle_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn brandDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn batchDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn vehicleTypeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn vINDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource vehicleBindingSource;
		private System.Windows.Forms.Button btnUpdateVehicle;
		private System.Windows.Forms.Button btnAddVehicle;
	}
}