using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Services.BatchServices
{
	public interface IBatchTransportService : IService<BatchTransport>
	{
		void AddBatch(string token,Batch vehicle, params object[] keyValues);
		void StartTravel(string token, params object[] keyValues);
		void FinishTravel(string token, params object[] keyValues);

	}


}
