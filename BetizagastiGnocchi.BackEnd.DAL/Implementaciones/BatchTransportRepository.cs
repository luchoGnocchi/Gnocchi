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
	public class BatchTransportRepository : GenericRepository<BatchTransport>, IBatchTransportRepository
	{
		public BatchTransportRepository(DbContext context) : base(context)
		{
		}
	}
}
