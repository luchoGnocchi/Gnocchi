using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Inspection
{
    public class InspectionAlreadyRegisteredException : InspectionException
    {
        public InspectionAlreadyRegisteredException() { }
        

        public InspectionAlreadyRegisteredException(string message) : base(message) { }
    }
}
