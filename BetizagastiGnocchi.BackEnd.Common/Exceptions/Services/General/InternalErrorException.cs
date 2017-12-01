using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.General
{
    public class InternalErrorException : Exception
    {
        public InternalErrorException() { }

        public InternalErrorException(string message) : base(message) { }
    }
}
