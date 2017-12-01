using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Services.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.Services.InspectionService
{
	public interface IInspectionService : IService<Inspection>
	{
		void AddDamage(string token, DamageRegistry DamageRegistry, params object[] keyValues);
	}
}
