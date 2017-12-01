namespace BetizagastiGnocchi.FrontEnd.Desktop
{
	partial class frmAddVehicle
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
			this.lblName = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblBrand = new System.Windows.Forms.Label();
			this.lblStock = new System.Windows.Forms.Label();
			this.txtVIN = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.grbNewProduct = new System.Windows.Forms.GroupBox();
			this.cbTypeVehicle = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBrand = new System.Windows.Forms.TextBox();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.txtYear = new System.Windows.Forms.TextBox();
			this.txtColor = new System.Windows.Forms.TextBox();
			this.grbNewProduct.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(18, 33);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(28, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "VIN:";
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(184, 33);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(31, 13);
			this.lblDescription.TabIndex = 1;
			this.lblDescription.Text = "Tipo:";
			// 
			// lblBrand
			// 
			this.lblBrand.AutoSize = true;
			this.lblBrand.Location = new System.Drawing.Point(18, 92);
			this.lblBrand.Name = "lblBrand";
			this.lblBrand.Size = new System.Drawing.Size(40, 13);
			this.lblBrand.TabIndex = 2;
			this.lblBrand.Text = "Marca:";
			this.lblBrand.Click += new System.EventHandler(this.lblPoints_Click);
			// 
			// lblStock
			// 
			this.lblStock.AutoSize = true;
			this.lblStock.Location = new System.Drawing.Point(121, 92);
			this.lblStock.Name = "lblStock";
			this.lblStock.Size = new System.Drawing.Size(45, 13);
			this.lblStock.TabIndex = 3;
			this.lblStock.Text = "Modelo:";
			// 
			// txtVIN
			// 
			this.txtVIN.Location = new System.Drawing.Point(21, 50);
			this.txtVIN.Name = "txtVIN";
			this.txtVIN.Size = new System.Drawing.Size(145, 20);
			this.txtVIN.TabIndex = 1;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(199, 173);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Guardar";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(118, 173);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 6;
			this.btnClear.Text = "Limpiar";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// grbNewProduct
			// 
			this.grbNewProduct.Controls.Add(this.txtColor);
			this.grbNewProduct.Controls.Add(this.txtYear);
			this.grbNewProduct.Controls.Add(this.txtModel);
			this.grbNewProduct.Controls.Add(this.txtBrand);
			this.grbNewProduct.Controls.Add(this.cbTypeVehicle);
			this.grbNewProduct.Controls.Add(this.label2);
			this.grbNewProduct.Controls.Add(this.label1);
			this.grbNewProduct.Controls.Add(this.lblName);
			this.grbNewProduct.Controls.Add(this.lblDescription);
			this.grbNewProduct.Controls.Add(this.lblBrand);
			this.grbNewProduct.Controls.Add(this.lblStock);
			this.grbNewProduct.Controls.Add(this.txtVIN);
			this.grbNewProduct.Location = new System.Drawing.Point(12, 12);
			this.grbNewProduct.Name = "grbNewProduct";
			this.grbNewProduct.Size = new System.Drawing.Size(375, 155);
			this.grbNewProduct.TabIndex = 10;
			this.grbNewProduct.TabStop = false;
			this.grbNewProduct.Text = "Datos Vehiculo";
			// 
			// cbTypeVehicle
			// 
			this.cbTypeVehicle.FormattingEnabled = true;
			this.cbTypeVehicle.Location = new System.Drawing.Point(187, 48);
			this.cbTypeVehicle.Name = "cbTypeVehicle";
			this.cbTypeVehicle.Size = new System.Drawing.Size(165, 21);
			this.cbTypeVehicle.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(258, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Color:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(187, 92);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Año:";
			// 
			// txtBrand
			// 
			this.txtBrand.Location = new System.Drawing.Point(21, 108);
			this.txtBrand.Name = "txtBrand";
			this.txtBrand.Size = new System.Drawing.Size(100, 20);
			this.txtBrand.TabIndex = 10;
			// 
			// txtModel
			// 
			this.txtModel.Location = new System.Drawing.Point(124, 108);
			this.txtModel.Name = "txtModel";
			this.txtModel.Size = new System.Drawing.Size(57, 20);
			this.txtModel.TabIndex = 11;
			// 
			// txtYear
			// 
			this.txtYear.Location = new System.Drawing.Point(187, 108);
			this.txtYear.Name = "txtYear";
			this.txtYear.Size = new System.Drawing.Size(65, 20);
			this.txtYear.TabIndex = 12;
			// 
			// txtColor
			// 
			this.txtColor.Location = new System.Drawing.Point(258, 108);
			this.txtColor.Name = "txtColor";
			this.txtColor.Size = new System.Drawing.Size(100, 20);
			this.txtColor.TabIndex = 13;
			// 
			// frmAddVehicle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(399, 208);
			this.Controls.Add(this.grbNewProduct);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnSave);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(415, 247);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(415, 247);
			this.Name = "frmAddVehicle";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Agregar Producto";
			this.Load += new System.EventHandler(this.frmAddProduct_Load);
			this.grbNewProduct.ResumeLayout(false);
			this.grbNewProduct.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Label lblBrand;
		private System.Windows.Forms.Label lblStock;
		private System.Windows.Forms.TextBox txtVIN;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.GroupBox grbNewProduct;
		private System.Windows.Forms.ComboBox cbTypeVehicle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtColor;
		private System.Windows.Forms.TextBox txtYear;
		private System.Windows.Forms.TextBox txtModel;
		private System.Windows.Forms.TextBox txtBrand;
	}
}