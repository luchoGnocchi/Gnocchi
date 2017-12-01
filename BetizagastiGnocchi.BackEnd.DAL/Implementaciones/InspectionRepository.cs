using BetizagastiGnocchi.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.DAL
{
	 
	public class InspectionRepository : GenericRepository<Inspection>, IInspectionRepository
	{
		public InspectionRepository(DbContext context) : base(context)
		{
		}
	}
}
