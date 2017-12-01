using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.User
{
    public class RolNotFoundException : UserException
    {
        public RolNotFoundException() { }

        public RolNotFoundException(string message) : base(message) { }
    }
}
