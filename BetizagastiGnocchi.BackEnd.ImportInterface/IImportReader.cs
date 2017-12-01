using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.ImportInterface
{
    public interface IImportReader
    {
        List<VehicleDTO> ImportVehicles(string path);
        string ReaderType {  get; }
    }
}
