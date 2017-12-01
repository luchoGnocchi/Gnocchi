using BetizagastiGnocchi.BackEnd.Domain.Entities;
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

namespace BetizagastiGnocchi.FrontEnd.Desktop
{
	public partial class frmVehicle : Form
	{
		private IBindingList list;
		private readonly IVehicleService _vehicleService;
		public frmVehicle(IVehicleService vehicleService)
		{
			InitializeComponent();
			_vehicleService = vehicleService;
			list = new BindingList<Vehicle>(_vehicleService.GetAll().ToList());
			dataGridView1.DataSource = list;

		}

		private void button1_Click(object sender, EventArgs e)
		{
			var obj = dataGridView1.SelectedRows[0].DataBoundItem as Vehicle;
			 
			frmAddVehicle toOpen = new frmAddVehicle(_vehicleService, obj);
			toOpen.ShowDialog();
			UpdateGrid(); 
		}

		private void frmVehicle_Load(object sender, EventArgs e)
		{

		}
		private void UpdateGrid()
		{

			dataGridView1.DataSource = _vehicleService.GetAll().ToList() ;
			 
		}

		private void btnAddVehicle_Click(object sender, EventArgs e)
		{
			frmAddVehicle toOpen = new frmAddVehicle(_vehicleService);
			toOpen.ShowDialog();
			UpdateGrid();
		}
	}
}
