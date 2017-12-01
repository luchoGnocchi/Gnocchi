namespace BetizagastiGnocchi.FrontEnd.Desktop
{
	partial class frmLogs
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
            this.grbResults = new System.Windows.Forms.GroupBox();
            this.grdLogs = new System.Windows.Forms.DataGridView();
            this.grbSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.grbResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).BeginInit();
            this.grbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbResults
            // 
            this.grbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbResults.Controls.Add(this.grdLogs);
            this.grbResults.Location = new System.Drawing.Point(12, 102);
            this.grbResults.Name = "grbResults";
            this.grbResults.Size = new System.Drawing.Size(605, 305);
            this.grbResults.TabIndex = 9;
            this.grbResults.TabStop = false;
            this.grbResults.Text = "Resultado";
            this.grbResults.Enter += new System.EventHandler(this.grbResults_Enter);
            // 
            // grdLogs
            // 
            this.grdLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLogs.Location = new System.Drawing.Point(6, 19);
            this.grdLogs.Name = "grdLogs";
            this.grdLogs.Size = new System.Drawing.Size(593, 280);
            this.grdLogs.TabIndex = 3;
            // 
            // grbSearch
            // 
            this.grbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSearch.Controls.Add(this.btnSearch);
            this.grbSearch.Controls.Add(this.lblDateTo);
            this.grbSearch.Controls.Add(this.dtpDateTo);
            this.grbSearch.Controls.Add(this.lblDateFrom);
            this.grbSearch.Controls.Add(this.dtpDateFrom);
            this.grbSearch.Location = new System.Drawing.Point(12, 17);
            this.grbSearch.Name = "grbSearch";
            this.grbSearch.Size = new System.Drawing.Size(605, 79);
            this.grbSearch.TabIndex = 8;
            this.grbSearch.TabStop = false;
            this.grbSearch.Text = "Buscador";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(369, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(189, 29);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(69, 13);
            this.lblDateTo.TabIndex = 5;
            this.lblDateTo.Text = "Fecha hasta:";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(192, 46);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(137, 20);
            this.dtpDateTo.TabIndex = 1;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(14, 29);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(72, 13);
            this.lblDateFrom.TabIndex = 4;
            this.lblDateFrom.Text = "Fecha desde:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(17, 46);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(137, 20);
            this.dtpDateFrom.TabIndex = 2;
            // 
            // frmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 424);
            this.Controls.Add(this.grbResults);
            this.Controls.Add(this.grbSearch);
            this.Name = "frmLogs";
            this.Text = "frmLog";
            this.grbResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).EndInit();
            this.grbSearch.ResumeLayout(false);
            this.grbSearch.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grbResults;
		private System.Windows.Forms.DataGridView grdLogs;
		private System.Windows.Forms.GroupBox grbSearch;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Label lblDateTo;
		private System.Windows.Forms.DateTimePicker dtpDateTo;
		private System.Windows.Forms.Label lblDateFrom;
		private System.Windows.Forms.DateTimePicker dtpDateFrom;
	}
}