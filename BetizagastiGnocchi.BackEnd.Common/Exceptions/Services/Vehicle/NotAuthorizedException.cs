using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Vehicle
{
    public class NotAuthorizedException : VehicleException
    {
        public NotAuthorizedException() { }

        public NotAuthorizedException(string message) : base(message) { }
    }
}
