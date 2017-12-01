using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.User
{
    public class UserIsTheOnlyAdminException : UserException
    {
        public UserIsTheOnlyAdminException() { }

        public UserIsTheOnlyAdminException(string message) : base(message) { }
    }
}
