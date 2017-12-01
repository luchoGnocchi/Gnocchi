using BetiizagastiGnocchi.FrontEnd.Desktop;
using BetizagastiGnocchi.BackEnd.DAL;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Services.LogServices;
using BetizagastiGnocchi.BackEnd.Services.RouteZoneServices;
using BetizagastiGnocchi.BackEnd.Services.UserService;
using BetizagastiGnocchi.BackEnd.Services.VehicleService;
using BetizagastiGnocchi.BackEnd.Services.ZoneServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace BetizagastiGnocchi.FrontEnd.Desktop
{
    public partial class frmLogin : Form
    {
        IUnitOfWork _unitOfWork;
	    ILogService _logger;
        public static User _user;
		IUserService _userService;
		IVehicleService _vehicleService;
		IZoneService _zoneService;
        IRouteZoneService _routeZoneService;

        public static string token;
		public frmLogin(ILogService logService, IUserService userService, IVehicleService vehicleService, IZoneService zoneService, IRouteZoneService routeZoneService)
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _logger = logService;
			_userService = userService;
			_vehicleService = vehicleService;
			_zoneService = zoneService;
            _routeZoneService = routeZoneService;

        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            ActiveForm.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
			
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				if (ValidateUser(out _user))
				{
					//Se valida que el usuario exista y que sea administrador
					//  IUserService userService = new UserService();
					string token = _userService.Login(txtUsername.Text, txtPassword.Text);
					if (token.Length > 0)
					{
						var user = _userService.GetAll().Where(u => u.Token.ToString() == token).FirstOrDefault();
						if (user.Rol_Id ==1)
						{
							pnlUser.Visible = false;
							txtUsername.Text = string.Empty;
							txtPassword.Text = string.Empty;
							lblActualUser.Text = _user.UserName;
							lblActualUser.Visible = true;
							menuPrincipal.Visible = true;
							frmLogin.token = token;
							_logger.Info(_user.UserName, "Login", "Inicio de Sesión");
						}
						else
						{
							MessageBox.Show("El usuario no es administrador del sistema, verifique los datos ingresados",
						   "Inicio Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}

					}
					else
					{
						MessageBox.Show("El usuario no existe o su pasword es incorrecta",
						   "Inicio Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				Cursor.Current = Cursors.Default;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, "Inicio Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		
		}

		private bool ValidateUser(out User user)
        {
            string messageError = string.Empty;
            bool isValid = true;
            user = new User() {   };
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text.Trim();
            if (!string.IsNullOrEmpty(username))
            {
                user.UserName = username;
            }
            else
            {
                isValid = false;
                messageError = "Debe ingresar el nombre de usuario. \n";
            }
            if (!string.IsNullOrEmpty(password))
            {
                user.Password = password;
            }
            else
            {
                isValid = false;
                messageError += "Debe ingresar la contraseña de usuario.";
            }
            if (!isValid)
                MessageBox.Show(messageError, "Datos de Inicio Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return isValid;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlUser.Visible = true;
            lblActualUser.Text = string.Empty;
            lblActualUser.Visible = false;
            menuPrincipal.Visible = false;
        }

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
			 new frmImportVehicle(_logger, _vehicleService, _user.UserName).ShowDialog();

		}

		private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmLoyalty loyalty = new frmLoyalty(_unitOfWork);
            //loyalty.ShowDialog();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
          new frmLogs().ShowDialog();
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           new frmAddVehicle(_vehicleService).ShowDialog();

        }

        private void mantenimientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
			new frmVehicle(_vehicleService).ShowDialog(this);
		}

		private void frmLogin_Load(object sender, EventArgs e)
		{
			txtPassword.Text = "Admin";
			txtUsername.Text = "admin";
		}

		private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			 new frmAddZone(_zoneService).ShowDialog();
		
		}

		private void mantenerToolStripMenuItem_Click(object sender, EventArgs e)
		{

		 new frmZones(_zoneService).ShowDialog(this);
		
		}

		private void flujoDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
		{

			frmRouteZone v = new frmRouteZone(_zoneService,_routeZoneService);
			v.ShowDialog(this);
		}
	}
}
