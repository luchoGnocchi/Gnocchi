using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Batch
{
    public class BatchNotAuthorizedException : BatchException
    {
        public BatchNotAuthorizedException() { }

        public BatchNotAuthorizedException(string message) : base(message) { }
    }
}
