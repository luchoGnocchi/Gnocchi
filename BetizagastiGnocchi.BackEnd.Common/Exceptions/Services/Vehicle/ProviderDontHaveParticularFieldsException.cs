using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Vehicle
{
    public class ProviderDontHaveParticularFieldException : VehicleException
    {
        public ProviderDontHaveParticularFieldException() { }

        public ProviderDontHaveParticularFieldException(string message) : base(message) { }
    }
}
