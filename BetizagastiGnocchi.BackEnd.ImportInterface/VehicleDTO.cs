using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.ImportInterface
{
    public class VehicleDTO
	{
		 

		public int IdVehicleDTO { get; set; }

        public string Brand { get; set; }
        
        public string Model { get; set; }
		public string Color { get; set; }
		public int Year { get; set; }
       
        public int Type { get; set; }
		public string VIN { get; set; }
	}
}
