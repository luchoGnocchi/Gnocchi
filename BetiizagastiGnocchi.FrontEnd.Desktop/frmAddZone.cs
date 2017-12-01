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
	public partial class frmAddZone : Form
	{
		private readonly IZoneService _zoneService;
		private Zone ActualZone;
		public static List<Zone> subZone;
		bool isUpdate;
		public frmAddZone()
		{
			InitializeComponent();
		}
		public frmAddZone(IZoneService zoneService)
		{
			_zoneService = zoneService;
			//	isUpdate = false;
			InitializeComponent();
			this.btnClear.Text = "Limpiar";
			isUpdate = false;

			subZone = new List<Zone>();
		}
		public frmAddZone(IZoneService ZoneService, Zone actualZone)
		{
			_zoneService = ZoneService;
			ActualZone = actualZone;
			isUpdate = true;
			subZone = actualZone.SubZones;
			InitializeComponent();
			btnClear.Text = "Cancelar";

		}

		private void btnAddSubZone_Click(object sender, EventArgs e)
		{
			frmAddSubZone toOpen = new frmAddSubZone(_zoneService);
			toOpen.ShowDialog();
			dataGridView1.DataSource = subZone.ToList();
		}

		private void frmAddZone_Load(object sender, EventArgs e)
		{
			if (ActualZone != null)
			{
				txtNombre.Text = ActualZone.Name;
				txtCapacity.Text = ActualZone.MaxCapacity.ToString();
				dataGridView1.DataSource = ActualZone.SubZones.ToList();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{

			if (ValidateSubZone())
			{
				try
				{
					if (ActualZone != null)
				{
					ActualZone.Name = txtNombre.Text;
					ActualZone.MaxCapacity = int.Parse( txtCapacity.Text);
					ActualZone.SubZones = subZone;
					_zoneService.Update(frmLogin.token, ActualZone);
					MessageBox.Show("Zona actualizada con exito", "Felicitaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}
				else
				{
			
					Zone zoneToList = new Zone();
					zoneToList.MaxCapacity = int.Parse(txtCapacity.Text);
					zoneToList.Name = txtNombre.Text;
					zoneToList.SubZones = subZone;

					_zoneService.Add(frmLogin.token, zoneToList);
					MessageBox.Show("Zona ingresada con exito", "Felicitaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message, "Excepcion", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				
			

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

		private void btnClear_Click(object sender, EventArgs e)
		{
			this.txtCapacity.Text = "";
			this.txtNombre.Text = "";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				var obj = dataGridView1.SelectedRows[0].DataBoundItem as Zone;
				subZone.Remove(obj);
				dataGridView1.DataSource = subZone.ToList();
			}
			catch (Exception)
			{


			}

		}
	}
}
