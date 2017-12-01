using BetizagastiGnocchi.BackEnd.DAL;
using BetizagastiGnocchi.BackEnd.Services.LogServices;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BetizagastiGnocchi.BackEnd.Services.VehicleService;
using System.Reflection;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.ImportInterface;

namespace BetizagastiGnocchi.FrontEnd.Desktop
{
    public partial class frmImportVehicle : Form
    {
         
       
        Dictionary<int, string> _dicImporters;
        string _path;
        string _username;
        ILogService _logger;
        IVehicleService _vehicleService;
        public frmImportVehicle(ILogService logService, IVehicleService vehicleService, string username)
        {
            _logger = logService;
			_vehicleService = vehicleService;
            _path = ConfigurationManager.AppSettings["DLLPath"];
            InitializeComponent();
			_username = username;

		}

	 
      

      

       

        private bool ValidateInputImport()
        {
            string messageError = string.Empty;
            bool isValid = true;
            if (txtPathDll.Text == "")
            {
                isValid = false;
                messageError = "Debe seleccionar un importador. \n";
            }
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                isValid = false;
                messageError += "Debe seleccionar el archivo a importar.";
            }
            if (!isValid)
                MessageBox.Show(messageError, "Datos de Importación Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return isValid;
        }

     

		private void btnBuscar_Click_1(object sender, EventArgs e)
		{
			txtPath.Text = string.Empty;
			if (ofdImport.ShowDialog() == DialogResult.OK)
			{
				txtPath.Text = ofdImport.FileName;
			}
		}

		private void btnImport_Click_1(object sender, EventArgs e)
		{
			if (ValidateInputImport())
			{

                try
                {
                    Assembly importedAssembly = Assembly.LoadFile(txtPathDll.Text);

                    foreach (var type in importedAssembly.GetTypes())
                    {
                        if (typeof(IImportReader).IsAssignableFrom(type))
                        {
                            IImportReader mechanism = (IImportReader)Activator.CreateInstance(type, null);
                            IEnumerable<VehicleDTO> vehicles = mechanism.ImportVehicles(txtPath.Text);
                            if (vehicles.Count() > 0)
                            {
                                List<Vehicle> listVehicles = new List<Vehicle>();
                                int countVehicle = 1;
                                foreach (var VehicleDTO in vehicles)
                                {
                                    Vehicle newVehicle = new Vehicle();
                                    

                                        newVehicle.VIN = VehicleDTO.VIN;
                                        newVehicle.Brand = VehicleDTO.Brand;
                                        newVehicle.Year = VehicleDTO.Year;
                                        newVehicle.VehicleType = (BackEnd.Domain.Enum.VehicleType)VehicleDTO.Type;
                                        newVehicle.Model = VehicleDTO.Model;
                                        newVehicle.Color = VehicleDTO.Color;
                                    newVehicle.sell = new Sell();
                                    _vehicleService.Add(frmLogin.token, newVehicle);
                                    countVehicle++;
                                }
                                _logger.Info(frmLogin._user.Name, "Importacion", "se importaron " + countVehicle + " vehiculos");
                                frmVehicle frmVehicles = new frmVehicle(_vehicleService);
                                frmVehicles.ShowDialog();
                          
                        }
                        }
                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //try
                //{
                //	Assembly importAssembly = Assembly.LoadFile(@fullPath);
                //                //Type assType = importAssembly.GetType(name);
                //                string readerType = "XML";
                //                if (name.Contains("CSV"))
                //                    readerType = "CSV";
                //                Type assType = importAssembly.GetTypes().First(t => t.Name.Contains(readerType));
                //                MethodInfo assMethod = assType.GetMethod("ImportVehicles");

                //	if (assMethod != null)
                //	{
                //		ParameterInfo[] parameters = assMethod.GetParameters();
                //		object classInstance = Activator.CreateInstance(assType, null);
                //                    importReader = (IImportReader)classInstance;

                //                    //  object[] parametersArray = new object[] { txtPath.Text };
                //                    var Vehicles = importReader.ImportVehicles(txtPath.Text);

                //		var VehiclesQuantity = Vehicles.Count;
                //		MessageBox.Show(string.Format("Se importaron correctamente {0} Vehicles", VehiclesQuantity),
                //			"Importación Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //		_logger.Info(_username, "Importación", string.Format("Se importaron {0} Vehicles", VehiclesQuantity));

                //		if (VehiclesQuantity > 0)
                //		{
                //			List<Vehicle> listVehicles = new List<Vehicle>();
                //			int countVehicle = 1;
                //			foreach (var VehicleDTO in Vehicles)
                //			{
                //				Vehicle newVehicle = new Vehicle()
                //				{
                //					Id = countVehicle,
                //					VIN = VehicleDTO.VIN,
                //					Model=VehicleDTO.Model,
                //					Brand = VehicleDTO.Brand,
                //					Year = VehicleDTO.Year,
                //					Color=VehicleDTO.Color,
                //					VehicleType = (BackEnd.Domain.Enum.VehicleType)VehicleDTO.Type,

                //				};
                //				_vehicleService.Add(frmLogin.token, newVehicle);
                //				countVehicle++;
                //			}
                //			frmVehicle frmVehicles = new frmVehicle(_vehicleService);
                //			frmVehicles.ShowDialog();
                //		}

                //	}
                //	else
                //	{
                //		MessageBox.Show(string.Format("No se encontro el método ImportVehicles en la dll {0}", fullPath),
                //		"Error al Importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //	}
                //}
                //catch (System.IO.FileNotFoundException)
                //{
                //	MessageBox.Show(string.Format("No se encontro la dll {0} en la ruta {1}", dll, _path),
                //		"Error al Importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
		}

        private void grbImport_Enter(object sender, EventArgs e)
        {

        }

        private void cbxImporters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPathDll.Text = string.Empty;
            if (ofdImport.ShowDialog() == DialogResult.OK)
            {
                txtPathDll.Text = ofdImport.FileName;
            }
        }
 
    }
}
