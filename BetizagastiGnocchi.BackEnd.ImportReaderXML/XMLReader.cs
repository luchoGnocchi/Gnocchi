using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
 
using BetizagastiGnocchi.BackEnd.ImportInterface;

namespace BetizagastiGnocchi.BackEnd.ImportReaderXML
{
    public class XMLReader : IImportReader
    {
        public string ReaderType => "XML";

        public List<VehicleDTO> ImportVehicles(string path)
        {
            List<VehicleDTO> vehicles = new List<VehicleDTO>();
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(path);
                XmlNodeList nodeList = xmlDoc.SelectNodes("/Vehiculos/Vehiculo");
                int count = 1;
                foreach (XmlNode node in nodeList)
                {
                    bool isValidParsing = true;
					VehicleDTO vehicle = new VehicleDTO();
                  
                    vehicle.Brand = node["Marca"].InnerText;
                    if (string.IsNullOrWhiteSpace(vehicle.Brand))
                        isValidParsing = false;
                    vehicle.Model = node["Modelo"].InnerText;
                    string yearStr = node["Año"].InnerText;
					vehicle.Color= node["Color"].InnerText;
					vehicle.VIN=node["VIN"].InnerText;
					string typeStr = node["Tipo"].InnerText;
                    int year;
                    if (int.TryParse(yearStr, out year))
                        vehicle.Year = year;
                    else
                        isValidParsing = false;

                    int typeVehicle;
                    if (int.TryParse(typeStr, out typeVehicle))
                        vehicle.Type = typeVehicle;
                    else
                        isValidParsing = false;
                    //Si se pudo parsear todos los atributos se agrega el producto a la lista
                    if (isValidParsing)
                    {
                        vehicles.Add(vehicle);
                        count++;
                    }
                }
            }
            catch (Exception ex )
            {
			
                //Se produjo un error logearlo
            }            
            return vehicles;
        }
    }
}
