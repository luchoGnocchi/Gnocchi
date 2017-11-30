using BetizagastiGnocchi.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetizagastiGnocchi.BackEnd.DAL
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<User> UserRepository { get; }
		IRepository<Vehicle> VehicleRepository { get; }
		IRepository<Batch> BatchRepository { get; }
		IRepository<BatchTransport> BatchTransportRepository { get; }
		IRepository<DamageRegistry> DamageRegistryRepository { get; }
		IRepository<VehicleMovement> VehicleMovementRepository { get; }
		IRepository<Zone> ZoneRepository { get; }
		IRepository<Inspection> InspectionRepository { get; }
		IRepository<UserRol> UserRolRepository { get; }
		void Save();
	}
}
