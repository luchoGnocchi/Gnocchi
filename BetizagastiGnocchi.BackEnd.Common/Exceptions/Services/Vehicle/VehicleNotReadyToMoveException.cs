using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Vehicle
{
    public class VehicleNotReadyToMoveException : VehicleException
    {
        public VehicleNotReadyToMoveException() { }

        public VehicleNotReadyToMoveException(string message) : base(message) { }
    }
}
