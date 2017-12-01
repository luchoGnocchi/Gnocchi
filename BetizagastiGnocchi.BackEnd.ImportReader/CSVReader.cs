using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BetizagastiGnocchi.BackEnd.ImportInterface;

namespace BetizagastiGnocchi.BackEnd.ImportReader
{
    public class CSVReader : IImportReader
    {
        public string ReaderType => "CSV";

        public List<VehicleDTO> ImportVehicles(string path)
        {
            List<VehicleDTO> vehicles = new List<VehicleDTO>();
            try
            {
                var reader = new StreamReader(File.OpenRead(@path));
                int count = 1;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    bool isValidParsing = true;
					VehicleDTO vehicle = new VehicleDTO();
                    
                    vehicle.Brand = values[0];
                    if (string.IsNullOrWhiteSpace(vehicle.Brand))
                        isValidParsing = false;
                    vehicle.Model = values[1];
                    string yearStr = values[2];
                    string typeStr = values[3];
					vehicle.VIN = values[4];
					vehicle.Color = values[5];
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
            catch (Exception)
            {
                //Se produjo un error logearlo
            }
            return vehicles;
        }
    }
}
