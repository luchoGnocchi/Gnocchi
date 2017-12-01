using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.General
{
    public class TokenHasExpiredException : Exception
    {
        public TokenHasExpiredException() { }

        public TokenHasExpiredException(string message) : base(message) { }
    }
}
