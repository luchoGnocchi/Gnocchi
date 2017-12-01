using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Vehicle
{
    public class VehicleException : Exception
    {
        public VehicleException() { }

        public VehicleException(string message) : base(message) { }
    }
}
