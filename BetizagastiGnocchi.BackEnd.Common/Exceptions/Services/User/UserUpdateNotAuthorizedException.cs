using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.User
{
    public class UserUpdateNotAuthorizedException : UserException
    {
        public UserUpdateNotAuthorizedException() { }

        public UserUpdateNotAuthorizedException(string message) : base(message) { }
    }
}
