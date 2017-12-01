namespace BetizagastiGnocchi.FrontEnd.Desktop
{
	partial class frmZones
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
            this.grdZone = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxCapacityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usedCapacityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddZone = new System.Windows.Forms.Button();
            this.btnUpdateZone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdZone
            // 
            this.grdZone.AutoGenerateColumns = false;
            this.grdZone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdZone.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.maxCapacityDataGridViewTextBoxColumn,
            this.usedCapacityDataGridViewTextBoxColumn});
            this.grdZone.DataSource = this.zoneBindingSource;
            this.grdZone.Location = new System.Drawing.Point(12, 59);
            this.grdZone.Name = "grdZone";
            this.grdZone.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdZone.Size = new System.Drawing.Size(612, 233);
            this.grdZone.TabIndex = 0;
            this.grdZone.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdZone_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // maxCapacityDataGridViewTextBoxColumn
            // 
            this.maxCapacityDataGridViewTextBoxColumn.DataPropertyName = "MaxCapacity";
            this.maxCapacityDataGridViewTextBoxColumn.HeaderText = "MaxCapacity";
            this.maxCapacityDataGridViewTextBoxColumn.Name = "maxCapacityDataGridViewTextBoxColumn";
            // 
            // usedCapacityDataGridViewTextBoxColumn
            // 
            this.usedCapacityDataGridViewTextBoxColumn.DataPropertyName = "UsedCapacity";
            this.usedCapacityDataGridViewTextBoxColumn.HeaderText = "UsedCapacity";
            this.usedCapacityDataGridViewTextBoxColumn.Name = "usedCapacityDataGridViewTextBoxColumn";
            // 
            // zoneBindingSource
            // 
            this.zoneBindingSource.DataSource = typeof(BetizagastiGnocchi.BackEnd.Domain.Entities.Zone);
            // 
            // btnAddZone
            // 
            this.btnAddZone.Location = new System.Drawing.Point(430, 21);
            this.btnAddZone.Name = "btnAddZone";
            this.btnAddZone.Size = new System.Drawing.Size(75, 23);
            this.btnAddZone.TabIndex = 5;
            this.btnAddZone.Text = "Agregar";
            this.btnAddZone.UseVisualStyleBackColor = true;
            this.btnAddZone.Click += new System.EventHandler(this.btnAddZone_Click);
            // 
            // btnUpdateZone
            // 
            this.btnUpdateZone.Location = new System.Drawing.Point(512, 21);
            this.btnUpdateZone.Name = "btnUpdateZone";
            this.btnUpdateZone.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateZone.TabIndex = 4;
            this.btnUpdateZone.Text = "Modificar";
            this.btnUpdateZone.UseVisualStyleBackColor = true;
            this.btnUpdateZone.Click += new System.EventHandler(this.btnUpdateZone_Click);
            // 
            // frmZones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 400);
            this.Controls.Add(this.btnAddZone);
            this.Controls.Add(this.btnUpdateZone);
            this.Controls.Add(this.grdZone);
            this.Name = "frmZones";
            this.Text = "frmZones";
            this.Load += new System.EventHandler(this.frmZones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView grdZone;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn maxCapacityDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn usedCapacityDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource zoneBindingSource;
		private System.Windows.Forms.Button btnAddZone;
		private System.Windows.Forms.Button btnUpdateZone;
	}
}