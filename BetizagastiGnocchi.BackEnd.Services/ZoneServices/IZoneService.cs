using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Services.ZoneServices
{
	public interface IZoneService : IService<Zone>
	{
		void AddVehicle(string token,Vehicle vehicle, params object[] keyValues);
	 
	}


}
