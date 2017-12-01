namespace BetizagastiGnocchi.FrontEnd.Desktop
{
    partial class frmImportVehicle
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
            this.grbImport = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPathDll = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdImport = new System.Windows.Forms.OpenFileDialog();
            this.grbImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbImport
            // 
            this.grbImport.Controls.Add(this.button1);
            this.grbImport.Controls.Add(this.txtPathDll);
            this.grbImport.Controls.Add(this.btnImport);
            this.grbImport.Controls.Add(this.label2);
            this.grbImport.Controls.Add(this.txtPath);
            this.grbImport.Controls.Add(this.btnBuscar);
            this.grbImport.Controls.Add(this.label1);
            this.grbImport.Location = new System.Drawing.Point(12, 12);
            this.grbImport.Name = "grbImport";
            this.grbImport.Size = new System.Drawing.Size(471, 237);
            this.grbImport.TabIndex = 7;
            this.grbImport.TabStop = false;
            this.grbImport.Text = "Importar";
            this.grbImport.Enter += new System.EventHandler(this.grbImport_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPathDll
            // 
            this.txtPathDll.Enabled = false;
            this.txtPathDll.Location = new System.Drawing.Point(37, 52);
            this.txtPathDll.Name = "txtPathDll";
            this.txtPathDll.Size = new System.Drawing.Size(306, 20);
            this.txtPathDll.TabIndex = 6;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(176, 180);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Importar";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Importador:";
            // 
            // txtPath
            // 
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(37, 116);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(306, 20);
            this.txtPath.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(370, 113);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ruta:";
            // 
            // ofdImport
            // 
            this.ofdImport.FileName = "ofdImport";
            // 
            // frmImportVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 270);
            this.Controls.Add(this.grbImport);
            this.Name = "frmImportVehicle";
            this.Text = "frmImportVehicle";
            this.grbImport.ResumeLayout(false);
            this.grbImport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbImport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdImport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPathDll;
    }
}