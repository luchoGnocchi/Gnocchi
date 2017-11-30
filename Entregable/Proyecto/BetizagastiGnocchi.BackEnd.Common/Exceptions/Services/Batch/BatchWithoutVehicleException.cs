using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Batch
{
    public class BatchWithoutVehicleException : BatchException
    {
        public BatchWithoutVehicleException() { }

        public BatchWithoutVehicleException(string message) : base(message) { }
    }
}
