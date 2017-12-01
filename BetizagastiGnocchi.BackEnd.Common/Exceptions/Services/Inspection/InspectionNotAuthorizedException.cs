using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Inspection
{
    public class InspectionNotAuthorizedException : InspectionException
    {
        public InspectionNotAuthorizedException() { }

        public InspectionNotAuthorizedException(string message) : base(message) { }
    }
}
