using BetizagastiGnocchi.BackEnd.DAL;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BetizagastiGnocchi.BackEnd.DAL
{
	public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
	{
		public VehicleRepository(DbContext context) : base(context)
		{
		}
	}
}
