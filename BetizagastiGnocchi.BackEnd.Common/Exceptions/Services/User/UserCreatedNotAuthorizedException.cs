using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.User
{
    public class UserCreatedNotAuthorizedException : UserException
    {
        public UserCreatedNotAuthorizedException() { }

        public UserCreatedNotAuthorizedException(string message) : base(message) { }
    }
}
