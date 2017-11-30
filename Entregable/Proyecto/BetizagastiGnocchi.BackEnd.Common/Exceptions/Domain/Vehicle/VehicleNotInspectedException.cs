using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Exceptions
{
    public class VehicleNotInspectedException : Exception
    {
        public VehicleNotInspectedException() { }

        public VehicleNotInspectedException(string message) : base(message) { }
    }
}
