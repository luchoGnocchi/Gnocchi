namespace BetizagastiGnocchi.FrontEnd.Desktop
{
	partial class frmLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
			this.btnLogin = new System.Windows.Forms.Button();
			this.lblUsername = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.menuPrincipal = new System.Windows.Forms.MenuStrip();
			this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.agregarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.mantenimientoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mantenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flujoDeTrabajoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblActualUser = new System.Windows.Forms.Label();
			this.pnlUser = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.menuPrincipal.SuspendLayout();
			this.pnlUser.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(251, 165);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(91, 23);
			this.btnLogin.TabIndex = 2;
			this.btnLogin.Text = "Iniciar Sesión";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// lblUsername
			// 
			this.lblUsername.AutoSize = true;
			this.lblUsername.Location = new System.Drawing.Point(227, 38);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(101, 13);
			this.lblUsername.TabIndex = 1;
			this.lblUsername.Text = "Nombre de Usuario:";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(227, 91);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(64, 13);
			this.lblPassword.TabIndex = 2;
			this.lblPassword.Text = "Contraseña:";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(230, 54);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(134, 20);
			this.txtUsername.TabIndex = 0;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(230, 107);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(134, 20);
			this.txtPassword.TabIndex = 1;
			this.txtPassword.UseSystemPasswordChar = true;
			this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
			// 
			// menuPrincipal
			// 
			this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.zonaToolStripMenuItem,
            this.logsToolStripMenuItem,
            this.salirToolStripMenuItem});
			this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
			this.menuPrincipal.Name = "menuPrincipal";
			this.menuPrincipal.Size = new System.Drawing.Size(445, 24);
			this.menuPrincipal.TabIndex = 5;
			this.menuPrincipal.Text = "menuPrincipal";
			this.menuPrincipal.Visible = false;
			// 
			// productosToolStripMenuItem
			// 
			this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem1,
            this.mantenimientoToolStripMenuItem1,
            this.importarToolStripMenuItem});
			this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
			this.productosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
			this.productosToolStripMenuItem.Text = "Vehiculos";
			// 
			// agregarToolStripMenuItem1
			// 
			this.agregarToolStripMenuItem1.Name = "agregarToolStripMenuItem1";
			this.agregarToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
			this.agregarToolStripMenuItem1.Text = "Agregar";
			this.agregarToolStripMenuItem1.Click += new System.EventHandler(this.agregarToolStripMenuItem1_Click);
			// 
			// mantenimientoToolStripMenuItem1
			// 
			this.mantenimientoToolStripMenuItem1.Name = "mantenimientoToolStripMenuItem1";
			this.mantenimientoToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
			this.mantenimientoToolStripMenuItem1.Text = "Mantenimiento";
			this.mantenimientoToolStripMenuItem1.Click += new System.EventHandler(this.mantenimientoToolStripMenuItem1_Click);
			// 
			// importarToolStripMenuItem
			// 
			this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
			this.importarToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.importarToolStripMenuItem.Text = "Importar";
			this.importarToolStripMenuItem.Click += new System.EventHandler(this.importarToolStripMenuItem_Click);
			// 
			// zonaToolStripMenuItem
			// 
			this.zonaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.mantenerToolStripMenuItem,
            this.flujoDeTrabajoToolStripMenuItem});
			this.zonaToolStripMenuItem.Name = "zonaToolStripMenuItem";
			this.zonaToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.zonaToolStripMenuItem.Text = "Zona";
			// 
			// agregarToolStripMenuItem
			// 
			this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
			this.agregarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.agregarToolStripMenuItem.Text = "Agregar";
			this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
			// 
			// mantenerToolStripMenuItem
			// 
			this.mantenerToolStripMenuItem.Name = "mantenerToolStripMenuItem";
			this.mantenerToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.mantenerToolStripMenuItem.Text = "Mantener";
			this.mantenerToolStripMenuItem.Click += new System.EventHandler(this.mantenerToolStripMenuItem_Click);
			// 
			// flujoDeTrabajoToolStripMenuItem
			// 
			this.flujoDeTrabajoToolStripMenuItem.Name = "flujoDeTrabajoToolStripMenuItem";
			this.flujoDeTrabajoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.flujoDeTrabajoToolStripMenuItem.Text = "Flujo de Trabajo";
			this.flujoDeTrabajoToolStripMenuItem.Click += new System.EventHandler(this.flujoDeTrabajoToolStripMenuItem_Click);
			// 
			// logsToolStripMenuItem
			// 
			this.logsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaToolStripMenuItem});
			this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
			this.logsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.logsToolStripMenuItem.Text = "Logs";
			// 
			// consultaToolStripMenuItem
			// 
			this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
			this.consultaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.consultaToolStripMenuItem.Text = "Consulta";
			this.consultaToolStripMenuItem.Click += new System.EventHandler(this.consultaToolStripMenuItem_Click);
			// 
			// salirToolStripMenuItem
			// 
			this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
			this.salirToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
			this.salirToolStripMenuItem.Text = "Cerrar Sesión";
			this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
			// 
			// lblActualUser
			// 
			this.lblActualUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblActualUser.AutoSize = true;
			this.lblActualUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblActualUser.Location = new System.Drawing.Point(-2, 283);
			this.lblActualUser.Name = "lblActualUser";
			this.lblActualUser.Size = new System.Drawing.Size(124, 20);
			this.lblActualUser.TabIndex = 6;
			this.lblActualUser.Text = "Nombre Usuario";
			this.lblActualUser.Visible = false;
			// 
			// pnlUser
			// 
			this.pnlUser.Controls.Add(this.pictureBox1);
			this.pnlUser.Controls.Add(this.btnLogin);
			this.pnlUser.Controls.Add(this.txtPassword);
			this.pnlUser.Controls.Add(this.lblUsername);
			this.pnlUser.Controls.Add(this.lblPassword);
			this.pnlUser.Controls.Add(this.txtUsername);
			this.pnlUser.Location = new System.Drawing.Point(29, 30);
			this.pnlUser.Name = "pnlUser";
			this.pnlUser.Size = new System.Drawing.Size(379, 232);
			this.pnlUser.TabIndex = 4;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(6, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(218, 229);
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// frmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(445, 305);
			this.Controls.Add(this.pnlUser);
			this.Controls.Add(this.lblActualUser);
			this.Controls.Add(this.menuPrincipal);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(461, 344);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(461, 344);
			this.Name = "frmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Inicio de Sesión";
			this.Load += new System.EventHandler(this.frmLogin_Load);
			this.menuPrincipal.ResumeLayout(false);
			this.menuPrincipal.PerformLayout();
			this.pnlUser.ResumeLayout(false);
			this.pnlUser.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.MenuStrip menuPrincipal;
		private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
		private System.Windows.Forms.Label lblActualUser;
		private System.Windows.Forms.Panel pnlUser;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStripMenuItem zonaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mantenerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem flujoDeTrabajoToolStripMenuItem;
	}
}

