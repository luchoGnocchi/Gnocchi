using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetizagastiGnocchi.BackEnd.Domain.Entities;

namespace BetizagastiGnocchi.BackEnd.DAL
{

    public class CarManagementContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<DamageRegistry> DamageRegistrys { get; set; }
        public DbSet<VehicleMovement> VehicleMovements { get; set; }
        public DbSet<ActionOperation> ActionOperations { get; set; }
		public DbSet<BatchTransport> BatchTransports { get; set; }

		private static CarManagementContext instance = null;

        public CarManagementContext() : base("name=BetizagastiGnocchiContext") { }

        public void EmptyContext()
        {
            Users.RemoveRange(Users);
            Vehicles.RemoveRange(Vehicles);
            Inspections.RemoveRange(Inspections);
            Batchs.RemoveRange(Batchs);
            Zones.RemoveRange(Zones);
            DamageRegistrys.RemoveRange(DamageRegistrys);
            VehicleMovements.RemoveRange(VehicleMovements);
			BatchTransports.RemoveRange(BatchTransports);

		}

		public static CarManagementContext getInstance()
        {
            if (instance == null)
            {
                instance = new CarManagementContext();

            }
            return instance;
        }
    }
}
