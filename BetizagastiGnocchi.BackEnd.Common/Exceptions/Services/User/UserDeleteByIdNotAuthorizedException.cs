using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.User
{
    public class UserDeleteByIdNotAuthorized : UserException
    {
        public UserDeleteByIdNotAuthorized() { }

        public UserDeleteByIdNotAuthorized(string message) : base(message) { }
    }
}
