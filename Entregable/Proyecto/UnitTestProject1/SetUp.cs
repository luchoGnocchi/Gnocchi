using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using BetizagastiGnocchi.BackEnd.Domain.Enum;
using BetizagastiGnocchi.BackEnd.DAL;

namespace BetizagastiGnocchi.BackEnd.Test
{
    public class SetUp
    {

		protected void CleanDataBase()
		{
			using (var db =  CarManagementContext.getInstance())
			{
				db.EmptyContext();
				db.SaveChanges();
			}
		}
		protected User CreateTestUser()
        {
            var testUser = new User
            {
				Id = 1,
				UserName = "TestUser",
                Password = "testPassword",
                Rol = new UserRol() ,
                Token = Guid.NewGuid()                
            };
            return testUser;
        }
		protected User CreateTestUser2()
		{
			var testUser = new User
			{
				Id = 2,
				UserName = "TestUser",
				Password = "testPassword",
				Rol = new UserRol(),
				Token = Guid.NewGuid()
			};
			return testUser;
		}
		protected Vehicle CreateTestVehicle1()
        {

			var vehicle = new Vehicle
			{
				Id = 1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2018,
                Color = "Rojo",
                VehicleType = "Auto",
                VIN = "AAA-222-CC",
                Inspections = new List<Inspection>(),
                HistoryState = new List<State>()
            };
            return vehicle;
        }

        protected Vehicle CreateTestVehicle2()
        {
            var vehicle = new Vehicle
            {
				Id = 2,
				Brand = "Honda",
                Model = "Civic",
                Year = 2015,
                Color = "Azul",
                VehicleType = "Auto",
                VIN = "BBB-333-FF",
                Inspections = new List<Inspection>(),
                HistoryState = new List<State>()
            };
            return vehicle;
        }

        protected List<Vehicle> CreateTestVehicleList()
        {
            var vehicle1 = CreateTestVehicle1();
            var vehicle2 = CreateTestVehicle2();

            var vehicles = new List<Vehicle>();
            vehicles.Add(vehicle1);
            vehicles.Add(vehicle2);

            return vehicles;
        }

        protected Batch CreateTestBatchWithVehicles()
        {
            Batch testBatch = new Batch
            {
				Id = 1,
				Creator = CreateTestUser(),
                Name = "TestBatch",
                Description = "TestDescription",
                Vehicles = CreateTestVehicleList()
            };

            return testBatch;
        }

        protected Batch CreateEmptyTestBatch()
        {
			Batch testBatch = new Batch
			{
				Id = 2,
				Creator = CreateTestUser(),
                Name = "TestBatch",
                Description = "TestDescription",
                Vehicles = new List<Vehicle>()
            };

            return testBatch;
        }

        protected DamageRegistry CreateTestDamageRegistry1()
        {
            var damageRegistry = new DamageRegistry
            {
				Id = 1,
				Description = "TestDamageRegistryDescription1"
            };

            return damageRegistry;
        }

        protected DamageRegistry CreateTestDamageRegistry2()
        {
            var damageRegistry = new DamageRegistry
            {
				Id = 2,
				Description = "TestDamageRegistryDescription2"
            };

            return damageRegistry;
        }

        protected List<DamageRegistry> CreateTestDamageRegistryList()
        {
            var damageRegistry1 = CreateTestDamageRegistry1();
            var damageRegistry2 = CreateTestDamageRegistry2();
            var damageRegistries = new List<DamageRegistry>();
            damageRegistries.Add(damageRegistry1);
            damageRegistries.Add(damageRegistry2);

            return damageRegistries;
        }

        protected Inspection CreateTestInspectionOK()
        {
			var inspection = new Inspection()
			{
				Id = 1,
				DamageRegistries = new List<DamageRegistry>(),
                DateAndTime = DateTime.Now,
                Inspector = CreateTestUser(),
                Status = InspectionStatus.OK,
                Place = InspectionPlace.Patio,
                Vehicle = CreateTestVehicle1()
            };

            return inspection;
        }

        protected Inspection CreateTestInspectionDAMAGED()
        {
            var inspection = new Inspection()
            {
				Id = 2,
				DamageRegistries = CreateTestDamageRegistryList(),
                DateAndTime = DateTime.Now,
                Inspector = CreateTestUser(),
                Status = InspectionStatus.DAMAGED,
                Place = InspectionPlace.Patio,
                Vehicle = CreateTestVehicle1()
            };

            return inspection;
        }
        protected List<Inspection> CreateTestInspectionsList()
        {
            List<Inspection> inspections = new List<Inspection>();
            inspections.Add(CreateTestInspectionDAMAGED());
            inspections.Add(CreateTestInspectionOK());
                return inspections;
        }

        protected State CreateTestPortState()
        {
            return new State() { PlaceInMoment = Place.Puerto, CurrentDate = DateTime.Now.Date };
        }

        protected State CreateTestParkingState()
        {
            return new State() { PlaceInMoment = Place.Patio, CurrentDate = DateTime.Now.Date };
        }

        protected Batch CreateReadyForTransportTestBatch()
        {
            var testBatch = CreateEmptyTestBatch();
            var testVehicle = CreateTestVehicle1();
			var inspection = CreateTestInspectionOK();
			testBatch.Creator = CreateTestUser();
			testVehicle.Inspections.Add(inspection);
            testVehicle.HistoryState.Add(CreateTestPortState());
            inspection.Vehicle = testVehicle;
			inspection.VehicleId = testVehicle.Id;
			testBatch.Vehicles.Add(testVehicle);
			testVehicle.BatchId = testBatch.Id;
			testVehicle.Batch = testBatch;
			return testBatch;
        }

        protected List<Batch> CreateReadyForTransportTestBatchList()
        {
            var batchs = new List<Batch>();

            batchs.Add(CreateReadyForTransportTestBatch());

            return batchs;
        }

        protected Zone CreateTestZone50Cap()
        {
            var zone = new Zone()
            {
				Id = 1,
				MaxCapacity = 50,
                Name = "testZone50",
                SubZones = new List<Zone>(),
                UsedCapacity = 0
            };

            return zone;
        }

        protected List<Zone> CreateSubZoneMaxCap100()
        {
            var subZones = new List<Zone>();
            var zone1 = CreateTestZone50Cap();
            var zone2 = CreateTestZone50Cap();

            subZones.Add(zone1);
            subZones.Add(zone2);

            return subZones;
        }
        protected List<User> GetUsers()
		{
			return new List<User>
		   {
				 new User
			{
					 Id = 1,
				UserName = "TestUser",
				Password = "testPassword",
				Rol = new UserRol() ,
				Token = Guid.NewGuid()
			},
			new User()
				{
				Id = 2,
					UserName = "TestUser2",
				Password = "testPassword2",
				Rol = new UserRol() ,
				Token = Guid.NewGuid()
				}
			};
		}
        protected List<VehicleMovement> CreateVehicleMovementsTest()
        {
            var vehicleMovements = new List<VehicleMovement>();
             VehicleMovement movement = new VehicleMovement()
        {
            Time = DateTime.Now.Hour,
            User = CreateTestUser(),
            Vehicle = CreateTestVehicle1(),
            OriginZone = CreateTestZone50Cap(),
            DestinationZone = CreateTestZone50Cap()
        };

            movement.Id = 1;
            vehicleMovements.Add(movement);
    
            VehicleMovement movementTwo = new VehicleMovement()
            {
                Time = DateTime.Now.Hour,
                User = CreateTestUser(),
                Vehicle = CreateTestVehicle1(),
                OriginZone = CreateTestZone50Cap(),
                DestinationZone = CreateTestZone50Cap()
            };
            movementTwo.Id = 2;
            vehicleMovements.Add(movementTwo);

            return vehicleMovements;
        }

     
    }
}
