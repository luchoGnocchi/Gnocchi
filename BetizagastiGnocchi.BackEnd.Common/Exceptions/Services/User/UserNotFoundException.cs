﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.User
{
    public class UserNotFoundException : UserException
    {
        public UserNotFoundException() { }

        public UserNotFoundException(string message) : base(message) { }
    }
}
