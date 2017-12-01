namespace BetizagastiGnocchi.FrontEnd.Desktop
{
	partial class frmAddSubZone
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
			this.SuspendLayout();
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(12, 44);
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
			this.btnClear.Location = new System.Drawing.Point(100, 99);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 8;
			this.btnClear.Text = "Limpiar";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(192, 99);
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
			// frmAddSubZone
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(279, 134);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCapacity);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.lblNombre);
			this.Controls.Add(this.txtNombre);
			this.Name = "frmAddSubZone";
			this.Text = "frmAddZone";
			this.Load += new System.EventHandler(this.frmAddSubZone_Load);
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
	}
}