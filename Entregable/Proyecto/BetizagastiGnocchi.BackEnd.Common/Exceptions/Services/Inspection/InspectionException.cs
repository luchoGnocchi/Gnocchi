using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Inspection
{
    public class InspectionException : Exception
    {
        public InspectionException() { }

        public InspectionException(string message) : base(message) { }
    }
}
