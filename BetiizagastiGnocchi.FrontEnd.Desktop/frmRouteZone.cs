using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Services.RouteZoneServices;
using BetizagastiGnocchi.BackEnd.Services.ZoneServices;
using BetizagastiGnocchi.FrontEnd.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetiizagastiGnocchi.FrontEnd.Desktop
{
    public partial class frmRouteZone : Form
    {
        private readonly IRouteZoneService _routeZoneService;

        private readonly IZoneService _zoneService;
        public frmRouteZone(IZoneService zoneService,IRouteZoneService routeZoneService)
        {
            InitializeComponent();
            _zoneService = zoneService;
            _routeZoneService = routeZoneService;
        }


        private void frmRouteZone_Load(object sender, EventArgs e)
        {
            updateGrid();
            updateComboBoxZones();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var selectd = cbZone.SelectedValue;
            _routeZoneService.Add(frmLogin.token,new RouteZone { ZonesToPass = selectd.ToString() });
            updateGrid();
        }
        private void updateComboBoxZones()
        {
            cbZone.DataSource = _zoneService.GetAll().GroupBy(test => test.Name).Select(grp => grp.First().Name).ToList();
        }
        private void updateGrid()
        {
            dataGridView1.DataSource = _routeZoneService.GetAll().ToList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
            var obj = dataGridView1.SelectedRows[0].DataBoundItem as RouteZone;
            _routeZoneService.DeleteById(frmLogin.token, obj.id);
            updateGrid();
            }
            catch (Exception)
            {

                 
            }
           

        }
    }
}
