using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.User
{
    public class WrongPasswordException : UserException
    {
        public WrongPasswordException() { }

        public WrongPasswordException(string message) : base(message) { }
    }
}
