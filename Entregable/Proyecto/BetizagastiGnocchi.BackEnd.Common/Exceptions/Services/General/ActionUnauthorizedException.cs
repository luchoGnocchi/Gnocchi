﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.General
{
    public class ActionUnauthorizedException : Exception
    {
        public ActionUnauthorizedException() { }

        public ActionUnauthorizedException(string message) : base(message) { }
    }
}
