using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Vehicle
{
    public class VehicleVINAlreadyRegisteredException : VehicleException
    {
        public VehicleVINAlreadyRegisteredException() { }

        public VehicleVINAlreadyRegisteredException(string message) : base(message) { }
    }
}
