using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.User
{
    public class UserAlreadyRegisteredException : UserException
    {
        public UserAlreadyRegisteredException() { }

        public UserAlreadyRegisteredException(string message) : base(message) { }
    }
}
