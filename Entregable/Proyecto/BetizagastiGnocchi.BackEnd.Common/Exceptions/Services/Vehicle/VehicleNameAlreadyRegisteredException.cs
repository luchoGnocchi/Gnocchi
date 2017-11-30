using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Vehicle
{
    public class VehicleNameAlreadyRegisteredException : VehicleException
    {
        public VehicleNameAlreadyRegisteredException() { }

        public VehicleNameAlreadyRegisteredException(string message) : base(message) { }
    }
}
