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
	 
	public partial class frmZones : Form
	{
private readonly IZoneService _zoneService;
		public frmZones(IZoneService  zoneService)
		{
			InitializeComponent();
			_zoneService = zoneService;
			
		}

		private void btnAddZone_Click(object sender, EventArgs e)
		{
			frmAddZone toOpen = new frmAddZone(_zoneService);
			toOpen.ShowDialog();
			UpdateGrid();

		}
		private void button1_Click(object sender, EventArgs e)
		{
			var obj = grdZone.SelectedRows[0].DataBoundItem as Zone;

			frmAddZone toOpen = new frmAddZone(_zoneService, obj);
			toOpen.ShowDialog();
			UpdateGrid();
		}

		private void frmVehicle_Load(object sender, EventArgs e)
		{

		}
		private void UpdateGrid()
		{

			this.grdZone.DataSource = _zoneService.GetAll().ToList();

		}
		private void frmZones_Load(object sender, EventArgs e)
		{
			grdZone.DataSource = new BindingList<Zone>(_zoneService.GetAll().ToList());
		}

		private void btnUpdateZone_Click(object sender, EventArgs e)
		{
			try
			{
				var obj = grdZone.SelectedRows[0].DataBoundItem as Zone;
				frmAddZone toOpen = new frmAddZone(_zoneService, obj);
				toOpen.ShowDialog();
				UpdateGrid();
			}
			catch (Exception)
			{


			}
		}

        private void grdZone_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
