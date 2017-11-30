using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Batch
{
    public class BatchAlreadyRegisteredException : BatchException
    {
        public BatchAlreadyRegisteredException() { }

        public BatchAlreadyRegisteredException(string message) : base(message) { }
    }
}
