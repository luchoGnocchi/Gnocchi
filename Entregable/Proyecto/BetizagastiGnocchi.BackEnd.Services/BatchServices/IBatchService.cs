using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Services.BatchServices
{
	public interface IBatchService:IService<Batch>
	{
		void AddVehicle(string token,Vehicle vehicle, params object[] keyValues);
		bool IsReadyToTransport(params object[] keyValues);
	}


}
