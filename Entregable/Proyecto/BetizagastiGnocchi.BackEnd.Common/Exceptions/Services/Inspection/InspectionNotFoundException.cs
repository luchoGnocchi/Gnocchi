using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Inspection
{
    public class InspectionNotFoundException : InspectionException
    {
        public InspectionNotFoundException() { }

        public InspectionNotFoundException(string message) : base(message) { }
    }
}
