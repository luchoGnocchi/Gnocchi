using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Inspection
{
    public class InspectionWithoutVehicleException : InspectionException
    {
        public InspectionWithoutVehicleException() { }

        public InspectionWithoutVehicleException(string message) : base(message) { }
    }
}
