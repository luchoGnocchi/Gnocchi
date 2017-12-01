using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Exceptions
{
    public class VehicleNotIStateException : Exception
    {
        public VehicleNotIStateException() { }

        public VehicleNotIStateException(string message) : base(message) { }
    }
}
