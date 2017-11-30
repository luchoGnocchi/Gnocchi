using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Batch
{
    public class BatchException : Exception
    {
        public BatchException() { }

        public BatchException(string message) : base(message) { }
    }
}

