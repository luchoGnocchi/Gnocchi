using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Vehicle
{
    public class VehicleWithoutNameException : VehicleException
    {
        public VehicleWithoutNameException() { }

        public VehicleWithoutNameException(string message) : base(message) { }
    }
}
