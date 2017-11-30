using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Batch
{
    public class BatchNotFoundException : BatchException
    {
        public BatchNotFoundException() { }

        public BatchNotFoundException(string message) : base(message) { }
    }
}
