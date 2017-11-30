using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Vehicle
{
    public class ProviderIsInInvoiceException : VehicleException
    {
        public ProviderIsInInvoiceException() { }

        public ProviderIsInInvoiceException(string message) : base(message) { }
    }
}
