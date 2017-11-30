﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Common.Services.Vehicle
{
    public class VehicleCommissionIsPercentageException : VehicleException
    {
        public VehicleCommissionIsPercentageException() { }

        public VehicleCommissionIsPercentageException(string message) : base(message) { }
    }
}
