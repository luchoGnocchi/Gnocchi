using BetizagastiGnocchi.BackEnd.DAL;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BetizagastiGnocchi.BackEnd.DAL.Interfaces;

namespace BetizagastiGnocchi.BackEnd.DAL
{
	public class BatchRepository : GenericRepository<Batch>, IBatchRepository
	{
		public BatchRepository(DbContext context) : base(context)
		{
		}
	}
}
