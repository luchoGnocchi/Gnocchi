using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetizagastiGnocchi.BackEnd.Domain.Entities;

namespace BetizagastiGnocchi.BackEnd.DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		private CarManagementContext context;
		private GenericRepository<User> userRepository;
		private GenericRepository<UserRol> userRolRepository;
		private GenericRepository<Vehicle> vehicleRepository;
		private GenericRepository<Batch> batchRepository;
		private GenericRepository<Zone> zoneRepository;
        private GenericRepository<DamageRegistry> damageRegistryRepository;
        private GenericRepository<Inspection> inspectionRepository;
        private GenericRepository<VehicleMovement> vehicleMovementRepository;
		private GenericRepository<BatchTransport> batchTransportRepository;
		public UnitOfWork(CarManagementContext carManagmentContext)
		{
			this.context = carManagmentContext;
		}
		public UnitOfWork()
		{
			context =   CarManagementContext.getInstance();
		}




		public IRepository<User> UserRepository
		{
			get
			{
				if (this.userRepository == null)
				{
					this.userRepository = new GenericRepository<User>(context);
				}
				return userRepository;
			}
		}
		public IRepository<Vehicle> VehicleRepository
		{
			get
			{
				if (this.vehicleRepository == null)
				{
					this.vehicleRepository = new GenericRepository<Vehicle>(context);
				}
				return vehicleRepository;
			}
		}
		public IRepository<Batch> BatchRepository
		{
			get
			{
				if (this.batchRepository == null)
				{
					this.batchRepository = new GenericRepository<Batch>(context);
				}
				return batchRepository;
			}
		}
        public IRepository<Zone> ZoneRepository
        {
            get
            {
                if (this.zoneRepository == null)
                {
                    this.zoneRepository = new GenericRepository<Zone>(context);
                }
                return zoneRepository;
            }
        }
        public IRepository<DamageRegistry> DamageRegistryRepository
        {
            get
            {
                if (this.damageRegistryRepository == null)
                {
                    this.damageRegistryRepository = new GenericRepository<DamageRegistry>(context);
                }
                return damageRegistryRepository;
            }
        }
        public IRepository<Inspection> InspectionRepository
        {
            get
            {
                if (this.inspectionRepository == null)
                {
                    this.inspectionRepository = new GenericRepository<Inspection>(context);
                }
                return inspectionRepository;
            }
        }
        public IRepository<VehicleMovement> VehicleMovementRepository
        {
            get
            {
                if (this.vehicleMovementRepository == null)
                {
                    this.vehicleMovementRepository = new GenericRepository<VehicleMovement>(context);
                }
                return vehicleMovementRepository;
            }
        }

		public IRepository<BatchTransport> BatchTransportRepository
		{
			get
			{
				if (this.batchTransportRepository == null)
				{
					this.batchTransportRepository = new GenericRepository<BatchTransport>(context);
				}
				return batchTransportRepository;
			}
		}

		public IRepository<UserRol> UserRolRepository
		{
			get
			{
				if (this.userRolRepository == null)
				{
					this.userRolRepository = new GenericRepository<UserRol>(context);
				}
				return userRolRepository;
			}
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}
