using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Exceptions
{
    public class ZoneMaximunVioledException : Exception
    {
        public ZoneMaximunVioledException() { }

        public ZoneMaximunVioledException(string message) : base(message) { }
    }
}
