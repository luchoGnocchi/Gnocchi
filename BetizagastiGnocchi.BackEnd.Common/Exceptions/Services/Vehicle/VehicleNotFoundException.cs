using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Vehicle
{
    public class VehicleNotFoundException : VehicleException
    {
        public VehicleNotFoundException() { }

        public VehicleNotFoundException(string message) : base(message) { }
    }
}
