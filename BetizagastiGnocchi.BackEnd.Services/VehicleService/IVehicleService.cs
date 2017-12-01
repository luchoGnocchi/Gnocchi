using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Services.VehicleService
{
	public interface IVehicleService : IService<Vehicle>
	{
		Vehicle ExistPlate(string Plate);
        List<Vehicle> GetVehicleOutBatch();
        bool sell(string Plate, Sell info);
        List<Vehicle> GetVehicleReadyToSell();
    }
}
