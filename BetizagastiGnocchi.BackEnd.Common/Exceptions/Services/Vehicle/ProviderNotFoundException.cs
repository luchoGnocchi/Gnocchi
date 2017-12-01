using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Vehicle
{
    public class ProviderNotFoundException : VehicleException
    {
        public ProviderNotFoundException() { }

        public ProviderNotFoundException(string message) : base(message) { }
    }
}
