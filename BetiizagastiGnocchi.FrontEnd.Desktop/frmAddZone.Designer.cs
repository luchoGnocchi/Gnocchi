namespace BetizagastiGnocchi.FrontEnd.Desktop
{
	partial class frmAddZone
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
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.lblNombre = new System.Windows.Forms.Label();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCapacity = new System.Windows.Forms.TextBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.maxCapacityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.zoneBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.btnAddSubZone = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(15, 44);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(100, 20);
			this.txtNombre.TabIndex = 0;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// lblNombre
			// 
			this.lblNombre.AutoSize = true;
			this.lblNombre.Location = new System.Drawing.Point(12, 18);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(44, 13);
			this.lblNombre.TabIndex = 2;
			this.lblNombre.Text = "Nombre";
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(85, 286);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 8;
			this.btnClear.Text = "Limpiar";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(166, 286);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Guardar";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(137, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Capacidad";
			// 
			// txtCapacity
			// 
			this.txtCapacity.Location = new System.Drawing.Point(140, 44);
			this.txtCapacity.Name = "txtCapacity";
			this.txtCapacity.Size = new System.Drawing.Size(100, 20);
			this.txtCapacity.TabIndex = 9;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.maxCapacityDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.zoneBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 95);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(308, 166);
			this.dataGridView1.TabIndex = 11;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "Nombre";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			// 
			// maxCapacityDataGridViewTextBoxColumn
			// 
			this.maxCapacityDataGridViewTextBoxColumn.DataPropertyName = "MaxCapacity";
			this.maxCapacityDataGridViewTextBoxColumn.HeaderText = "Capacidad Maxima";
			this.maxCapacityDataGridViewTextBoxColumn.Name = "maxCapacityDataGridViewTextBoxColumn";
			// 
			// zoneBindingSource
			// 
			
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Sub-Zona";
			// 
			// btnAddSubZone
			// 
			this.btnAddSubZone.Location = new System.Drawing.Point(277, 69);
			this.btnAddSubZone.Name = "btnAddSubZone";
			this.btnAddSubZone.Size = new System.Drawing.Size(43, 23);
			this.btnAddSubZone.TabIndex = 13;
			this.btnAddSubZone.Text = "+";
			this.btnAddSubZone.UseVisualStyleBackColor = true;
			this.btnAddSubZone.Click += new System.EventHandler(this.btnAddSubZone_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(228, 70);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(43, 23);
			this.button1.TabIndex = 14;
			this.button1.Text = "-";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmAddZone
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(335, 321);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnAddSubZone);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCapacity);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.lblNombre);
			this.Controls.Add(this.txtNombre);
			this.Name = "frmAddZone";
			this.Text = "frmAddZone";
			this.Load += new System.EventHandler(this.frmAddZone_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCapacity;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnAddSubZone;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn maxCapacityDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource zoneBindingSource;
		private System.Windows.Forms.Button button1;
	}
}