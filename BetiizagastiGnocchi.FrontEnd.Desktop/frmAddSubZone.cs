using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Services.ZoneServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetizagastiGnocchi.FrontEnd.Desktop
{
	public partial class frmAddSubZone : Form
	{
		private readonly IZoneService _zoneService;
		private Zone ActualZone;
		private List<Zone> SubZones;
		bool isUpdate;
		public frmAddSubZone()
		{
			InitializeComponent();
		}
		public frmAddSubZone(IZoneService zoneService)
		{
			_zoneService = zoneService;
			isUpdate = false;
			InitializeComponent();
			this.btnClear.Text = "Limpiar";
			//this.cbTypeVehicle.DataSource = System.Enum.GetValues(typeof(VehicleType));

		}
		public frmAddSubZone(IZoneService ZoneService, Zone actualZone)
		{
			_zoneService = ZoneService;
			ActualZone = actualZone;
			isUpdate = true;
			InitializeComponent();
			btnClear.Text = "Cancelar";
			 

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (ValidateSubZone()) {
				Zone zoneToList = new Zone();
				zoneToList.MaxCapacity = int.Parse(txtCapacity.Text);
				zoneToList.Name = txtNombre.Text;
				frmAddZone.subZone.Add(zoneToList);
				MessageBox.Show("Sub zona ingresada con exito", "Error al Validar", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Close();
			}
		}
		private bool ValidateSubZone()
		{
			bool isValid = true;
			 
			int Capacity = 0;
			string message = string.Empty;
			if (string.IsNullOrWhiteSpace(txtNombre.Text))
			{
				isValid = false;
				message += "Debe ingresar el Nombre para la subZona. \n";
			}
		 

			if (string.IsNullOrWhiteSpace(txtCapacity.Text))
			{
				isValid = false;
				message += "Debe ingresar la capacidad de la subZona. \n";
			}
			else if (!int.TryParse(txtCapacity.Text, out Capacity))
			{
				isValid = false;
				message += "El valor del año deber ser entero y mayor o igual a 1. \n";
			}
			 
			if (!isValid)
				MessageBox.Show(message, "Error al Validar", MessageBoxButtons.OK, MessageBoxIcon.Error);

			return isValid;
		}

		private void frmAddSubZone_Load(object sender, EventArgs e)
		{
			if (isUpdate) {
			txtNombre.Text = ActualZone.Name;
			txtNombre.Text = ActualZone.MaxCapacity.ToString(); }
		
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			this.txtCapacity.Text = "";
			this.txtNombre.Text = "";
		}
	}
}
