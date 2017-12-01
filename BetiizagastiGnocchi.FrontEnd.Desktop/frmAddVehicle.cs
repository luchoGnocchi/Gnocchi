using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Domain.Enum;
using BetizagastiGnocchi.BackEnd.Services.VehicleService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BetizagastiGnocchi.FrontEnd.Desktop
{
    public partial class frmAddVehicle : Form
    {
		IVehicleService _vehicleService;
        Vehicle ActualVehicle;
        bool isUpdate;

        public frmAddVehicle(IVehicleService VehicleService)
        {
			_vehicleService = VehicleService;
            isUpdate = false;
            InitializeComponent();
            btnClear.Text = "Limpiar";
			this.cbTypeVehicle.DataSource = System.Enum.GetValues(typeof(VehicleType));

		}

        public frmAddVehicle(IVehicleService VehicleService, Vehicle actualVehicle)
        {
			_vehicleService = VehicleService;
			ActualVehicle = actualVehicle;
            isUpdate = true;
            InitializeComponent();
            btnClear.Text = "Cancelar";
			this.cbTypeVehicle.DataSource = System.Enum.GetValues(typeof(VehicleType));

		}

        private void txtPoints_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!isUpdate)
                ClearData();
            else
                this.Close();
        }

        private void ClearData()
        {
            txtVIN.Clear();
			 
            txtBrand.Clear();
            txtYear.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateVehicle())
            {
			 
                if (ActualVehicle == null)
                {
					var newVehicle = new Vehicle()
					{ };
					 newVehicle.VIN=txtVIN.Text;
					 newVehicle.VehicleType=(VehicleType)cbTypeVehicle.SelectedItem;
					 newVehicle.Color=txtColor.Text;
					 newVehicle.Model=txtModel.Text;
					 newVehicle.Brand=txtBrand.Text;
					 newVehicle.Year=int.Parse(txtYear.Text);
                    newVehicle.sell = new Sell();
                    _vehicleService.Add(frmLogin.token,newVehicle);
                    MessageBox.Show("Se agrego correctamente el vehiculo.",
                    "Agregado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
					ActualVehicle.VIN = txtVIN.Text;
					ActualVehicle.VehicleType = (VehicleType)cbTypeVehicle.SelectedItem;
					ActualVehicle.Color = txtColor.Text;
					ActualVehicle.Model = txtModel.Text;
					ActualVehicle.Brand = txtBrand.Text;
					ActualVehicle.Year = int.Parse(txtYear.Text);

					_vehicleService.Update(frmLogin.token, ActualVehicle);
                    MessageBox.Show("Vehiculo actualizado correctamente.",
                    "Actualizado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
				ActualVehicle = null;                       
                this.Close();
            }
        }

        private bool ValidateVehicle()
        {
            bool isValid = true;
            int points = -1;
            int anio = 1899;
            string message = string.Empty;
            if (string.IsNullOrWhiteSpace(txtVIN.Text))
            {
                isValid = false;
                message += "Debe ingresar el VIN de Vehiculo. \n";                  
            }
            if (string.IsNullOrWhiteSpace(txtBrand.Text))
            {
                isValid = false;
                message += "Debe ingresar la Marca del Vehiculo. \n";
            }
           
            if (string.IsNullOrWhiteSpace(txtYear.Text))
            {
                isValid = false;
                message += "Debe ingresar el año del vehiculo. \n";
            }
            else if (!int.TryParse(txtYear.Text, out anio))
            {
                isValid = false;
                message += "El valor del año deber ser entero y mayor o igual a 1900. \n";
            }
            else if (anio <= 1900)
            {
                isValid = false;
                message += "El valor del año deber mayor o igual a 1990.";
            }
            if (!isValid)
                MessageBox.Show(message,"Error al Validar", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return isValid;
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            if (ActualVehicle != null)
            {
				//VehicleType status;
				//Enum.TryParse<VehicleType>(cbTypeVehicle.SelectedValue.ToString(), out status);
				///////
				txtVIN.Text = ActualVehicle.VIN;
				cbTypeVehicle.DataSource = Enum.GetValues(typeof(VehicleType));
				cbTypeVehicle.SelectedItem = ActualVehicle.VehicleType;
				txtColor.Text = ActualVehicle.Color;
				txtModel.Text = ActualVehicle.Model;
				txtBrand.Text = ActualVehicle.Brand;
                txtYear.Text = ActualVehicle.Year.ToString();
            }
            else
                ClearData();
        }

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void lblPoints_Click(object sender, EventArgs e)
		{

		}
	}
}
