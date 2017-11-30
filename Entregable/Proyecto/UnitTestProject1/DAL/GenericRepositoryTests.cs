using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using System.Data.Entity;
using BetizagastiGnocchi.BackEnd.DAL;
using System.Linq.Expressions;
using Moq;
using BetizagastiGnocchi.BackEnd.Domain.Enum;

namespace BetizagastiGnocchi.BackEnd.Test.DAL
{
    [TestClass()]
    public class GenericRepositoryTests : SetUp
    {
        #region Pruebas Usuarios
        private List<User> GetUsersForTests()
        {
            return new List<User>
           {
                new User()
                {
                    Id=1,
                    UserName = "Admin",
                    Password = "Admin",
                    Token = Guid.NewGuid(),
                    Rol =new UserRol()
                },
                new User()
                {
                        Id=2,
                    UserName = "Conductor",
                    Password = "Conductor",
                    Token = Guid.NewGuid(),
                    Rol = new UserRol()
                }
            };
        }

        [TestMethod()]
        public void GetAllUsersTestBD()
        {


            var data = GetUsersForTests();
            var set = new Mock<DbSet<User>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<User>()).Returns(set.Object);
            var unitOfWork = new UnitOfWork(context.Object);


            Expression<Func<User, bool>> filter = dto => dto.Id == 1;
            Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = query => query.OrderBy(dto => dto.Id);
            string includeProperties = "tesst";

            IEnumerable<User> result = unitOfWork.UserRepository.Get(filter, orderBy, includeProperties);

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod()]
        public void GetUserByIdTestUsers()
        {
            var data = GetUsersForTests();
            var set = new Mock<DbSet<User>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<User>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);


            User result = unitOfWork.UserRepository.GetByID(1);

            Assert.AreEqual(result, data.FirstOrDefault());
        }


        [TestMethod()]
        public void InsertTestUsers()
        {
            var data = GetUsersForTests();
            var set = new Mock<DbSet<User>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<User>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.UserRepository.Insert(data.FirstOrDefault());

            set.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
        }

        [TestMethod()]
        public void DeleteTestUser()
        {
            var data = GetUsersForTests();
            var set = new Mock<DbSet<User>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<User>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.UserRepository.Delete(data.FirstOrDefault().Id);

            set.Verify(m => m.Attach(It.IsAny<User>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<User>()), Times.Once());
        }


        [TestMethod()]
        public void DeleteObjectTestUsers()
        {
            var data = GetUsersForTests();
            var set = new Mock<DbSet<User>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<User>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.UserRepository.Delete(1);

            set.Verify(m => m.Find(It.IsAny<int>()), Times.Once());
            set.Verify(m => m.Attach(It.IsAny<User>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<User>()), Times.Once());
        }

        [TestMethod()]
        public void UpdateTestUsers()
        {
            var data = GetUsersForTests();
            var set = new Mock<DbSet<User>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<User>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            var item = data.FirstOrDefault();
            item.Password = "lolo";

            unitOfWork.UserRepository.Update(item, item.Id);

            set.Verify(m => m.Attach(It.IsAny<User>()), Times.Once());
        }
        #endregion
        #region Pruebas Vehiculo
        [TestMethod()]
        public void GetAllVehicleTestBD()
        {
            var data = CreateTestVehicleList();
            var set = new Mock<DbSet<Vehicle>>().SetupData(data);

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Vehicle>()).Returns(set.Object);

            var unitOfWork = new UnitOfWork(context.Object);

            Expression<Func<Vehicle, bool>> filter = dto => dto.Id == 1;
            Func<IQueryable<Vehicle>, IOrderedQueryable<Vehicle>> orderBy = query => query.OrderBy(dto => dto.Id); ;
            string includeProperties = "tesst";

            IEnumerable<Vehicle> result = unitOfWork.VehicleRepository.Get(filter, orderBy, includeProperties);

            Assert.AreEqual(result.Count(), 1);
        }


        [TestMethod()]
        public void GetVehicleByIdTest()
        {
            var data = CreateTestVehicleList();
            var set = new Mock<DbSet<Vehicle>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Vehicle>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);


            Vehicle result = unitOfWork.VehicleRepository.GetByID(1);

            Assert.AreEqual(result, data.FirstOrDefault());
        }


        [TestMethod()]
        public void InsertTestVehicle()
        {
            var data = CreateTestVehicleList();
            var set = new Mock<DbSet<Vehicle>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Vehicle>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.VehicleRepository.Insert(data.FirstOrDefault());

            set.Verify(m => m.Add(It.IsAny<Vehicle>()), Times.Once());
        }

        [TestMethod()]
        public void DeleteTestVehicle()
        {
            var data = CreateTestVehicleList();
            var set = new Mock<DbSet<Vehicle>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Vehicle>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.VehicleRepository.Delete(data.FirstOrDefault().Id);

            set.Verify(m => m.Attach(It.IsAny<Vehicle>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<Vehicle>()), Times.Once());
        }


        [TestMethod()]
        public void DeleteObjectTestVehicle()
        {
            var data = CreateTestVehicleList();
            var set = new Mock<DbSet<Vehicle>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Vehicle>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.VehicleRepository.Delete(1);

            set.Verify(m => m.Find(It.IsAny<int>()), Times.Once());
            set.Verify(m => m.Attach(It.IsAny<Vehicle>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<Vehicle>()), Times.Once());
        }

        [TestMethod()]
        public void UpdateTestVehicle()
        {
            var data = CreateTestVehicleList();
            var set = new Mock<DbSet<Vehicle>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Vehicle>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.VehicleRepository.Update(data.FirstOrDefault(), data.FirstOrDefault().Id);

            set.Verify(m => m.Attach(It.IsAny<Vehicle>()), Times.Once());
        }
        #endregion
        #region Pruebas Lote


        [TestMethod()]
        public void GetAllBatchsTestBD()
        {
            var data = CreateReadyForTransportTestBatchList();
            var set = new Mock<DbSet<Batch>>().SetupData(data);

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Batch>()).Returns(set.Object);

            var unitOfWork = new UnitOfWork(context.Object);

            Expression<Func<Batch, bool>> filter = dto => dto.Id > -1;
            Func<IQueryable<Batch>, IOrderedQueryable<Batch>> orderBy = query => query.OrderBy(dto => dto.Id); ;
            string includeProperties = "tesst";

            IEnumerable<Batch> result = unitOfWork.BatchRepository.Get(filter, orderBy, includeProperties);

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod()]
        public void GetBatchByIdTestBatchs()
        {
            var data = CreateReadyForTransportTestBatchList();
            var set = new Mock<DbSet<Batch>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Batch>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);


            Batch result = unitOfWork.BatchRepository.GetByID(1);

            Assert.AreEqual(result, data.FirstOrDefault());
        }


        [TestMethod()]
        public void InsertTestBatchs()
        {
            var data = CreateReadyForTransportTestBatchList();
            var set = new Mock<DbSet<Batch>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Batch>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.BatchRepository.Insert(data.FirstOrDefault());

            set.Verify(m => m.Add(It.IsAny<Batch>()), Times.Once());
        }

        [TestMethod()]
        public void DeleteTestBatch()
        {
            var data = CreateReadyForTransportTestBatchList();
            var set = new Mock<DbSet<Batch>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Batch>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.BatchRepository.Delete(data.FirstOrDefault().Id);

            set.Verify(m => m.Attach(It.IsAny<Batch>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<Batch>()), Times.Once());
        }


        [TestMethod()]
        public void DeleteObjectTestBatchs()
        {
            var data = CreateReadyForTransportTestBatchList();
            var set = new Mock<DbSet<Batch>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Batch>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.BatchRepository.Delete(1);

            set.Verify(m => m.Find(It.IsAny<int>()), Times.Once());
            set.Verify(m => m.Attach(It.IsAny<Batch>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<Batch>()), Times.Once());
        }

        [TestMethod()]
        public void UpdateTestBatchs()
        {
            //var data = CreateReadyForTransportTestBatchList();
            //var set = new Mock<DbSet<Batch>>().SetupData(data);
            //set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            //var context = new Mock<CarManagementContext>();
            //context.Setup(ctx => ctx.Set<Batch>()).Returns(set.Object);


            //var unitOfWork = new UnitOfWork(context.Object);

            //unitOfWork.BatchRepository.Update(data.FirstOrDefault());

            //set.Verify(m => m.Attach(It.IsAny<Batch>()), Times.Once());
        }
        #endregion
        #region Pruebas Zona


        [TestMethod()]
        public void GetAllZoneTestBD()
        {
            var data = CreateSubZoneMaxCap100();
            var set = new Mock<DbSet<Zone>>().SetupData(data);

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Zone>()).Returns(set.Object);

            var unitOfWork = new UnitOfWork(context.Object);

            Expression<Func<Zone, bool>> filter = dto => dto.Id > -1;
            Func<IQueryable<Zone>, IOrderedQueryable<Zone>> orderBy = query => query.OrderBy(dto => dto.Id); ;
            string includeProperties = "tesst";

            IEnumerable<Zone> result = unitOfWork.ZoneRepository.Get(filter, orderBy, includeProperties);

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod()]
        public void GetZoneByIdTestZones()
        {
            var data = CreateSubZoneMaxCap100();
            var set = new Mock<DbSet<Zone>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Zone>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);


            Zone result = unitOfWork.ZoneRepository.GetByID(1);

            Assert.AreEqual(result, data.FirstOrDefault());
        }


        [TestMethod()]
        public void InsertTestZone()
        {
            var data = CreateSubZoneMaxCap100();
            var set = new Mock<DbSet<Zone>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Zone>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.ZoneRepository.Insert(data.FirstOrDefault());

            set.Verify(m => m.Add(It.IsAny<Zone>()), Times.Once());
        }

        [TestMethod()]
        public void DeleteTestZone()
        {
            var data = CreateSubZoneMaxCap100();
            var set = new Mock<DbSet<Zone>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Zone>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.ZoneRepository.Delete(data.FirstOrDefault().Id);

            set.Verify(m => m.Attach(It.IsAny<Zone>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<Zone>()), Times.Once());
        }


        [TestMethod()]
        public void DeleteObjectTestZones()
        {
            var data = CreateSubZoneMaxCap100();
            var set = new Mock<DbSet<Zone>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Zone>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.ZoneRepository.Delete(1);

            set.Verify(m => m.Find(It.IsAny<int>()), Times.Once());
            set.Verify(m => m.Attach(It.IsAny<Zone>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<Zone>()), Times.Once());
        }

        [TestMethod()]
        public void UpdateTestZones()
        {
            var data = CreateSubZoneMaxCap100();
            var set = new Mock<DbSet<Zone>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Zone>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.ZoneRepository.Update(data.FirstOrDefault(), data.FirstOrDefault().Id);

            set.Verify(m => m.Attach(It.IsAny<Zone>()), Times.Once());
        }
        #endregion
        #region Prueba Registro de daños


        [TestMethod()]
        public void GetAllDamageRegistryTestBD()
        {
            var data = CreateTestDamageRegistryList();
            var set = new Mock<DbSet<DamageRegistry>>().SetupData(data);

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<DamageRegistry>()).Returns(set.Object);

            var unitOfWork = new UnitOfWork(context.Object);

            Expression<Func<DamageRegistry, bool>> filter = dto => dto.Id > -1;
            Func<IQueryable<DamageRegistry>, IOrderedQueryable<DamageRegistry>> orderBy = query => query.OrderBy(dto => dto.Id); ;
            string includeProperties = "tesst";

            IEnumerable<DamageRegistry> result = unitOfWork.DamageRegistryRepository.Get(filter, orderBy, includeProperties);

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod()]
        public void GetDamageRegistryByIdTestDamageRegistrys()
        {
            var data = CreateTestDamageRegistryList();
            var set = new Mock<DbSet<DamageRegistry>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<DamageRegistry>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);


            DamageRegistry result = unitOfWork.DamageRegistryRepository.GetByID(1);

            Assert.AreEqual(result, data.FirstOrDefault());
        }


        [TestMethod()]
        public void InsertTestDamageRegistry()
        {
            var data = CreateTestDamageRegistryList();
            var set = new Mock<DbSet<DamageRegistry>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<DamageRegistry>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.DamageRegistryRepository.Insert(data.FirstOrDefault());

            set.Verify(m => m.Add(It.IsAny<DamageRegistry>()), Times.Once());
        }

        [TestMethod()]
        public void DeleteTestDamageRegistry()
        {
            var data = CreateTestDamageRegistryList();
            var set = new Mock<DbSet<DamageRegistry>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<DamageRegistry>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.DamageRegistryRepository.Delete(data.FirstOrDefault().Id);

            set.Verify(m => m.Attach(It.IsAny<DamageRegistry>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<DamageRegistry>()), Times.Once());
        }


        [TestMethod()]
        public void DeleteObjectTestDamageRegistrys()
        {
            var data = CreateTestDamageRegistryList();
            var set = new Mock<DbSet<DamageRegistry>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<DamageRegistry>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.DamageRegistryRepository.Delete(1);

            set.Verify(m => m.Find(It.IsAny<int>()), Times.Once());
            set.Verify(m => m.Attach(It.IsAny<DamageRegistry>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<DamageRegistry>()), Times.Once());
        }

        [TestMethod()]
        public void UpdateTestDamageRegistrys()
        {
            var data = CreateTestDamageRegistryList();
            var set = new Mock<DbSet<DamageRegistry>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<DamageRegistry>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.DamageRegistryRepository.Update(data.FirstOrDefault(), data.FirstOrDefault().Id);

            set.Verify(m => m.Attach(It.IsAny<DamageRegistry>()), Times.Once());
        }
        #endregion
        #region Prueba Inspeciones


        [TestMethod()]
        public void GetAllInspectionTestBD()
        {
            var data = CreateTestInspectionsList();
            var set = new Mock<DbSet<Inspection>>().SetupData(data);

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Inspection>()).Returns(set.Object);

            var unitOfWork = new UnitOfWork(context.Object);

            Expression<Func<Inspection, bool>> filter = dto => dto.Id > -1;
            Func<IQueryable<Inspection>, IOrderedQueryable<Inspection>> orderBy = query => query.OrderBy(dto => dto.Id); ;
            string includeProperties = "tesst";

            IEnumerable<Inspection> result = unitOfWork.InspectionRepository.Get(filter, orderBy, includeProperties);

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod()]
        public void GetInspectionByIdTestInspections()
        {
            var data = CreateTestInspectionsList();
            var set = new Mock<DbSet<Inspection>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Inspection>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);


            Inspection result = unitOfWork.InspectionRepository.GetByID(1);

            Assert.AreEqual(result, data.FirstOrDefault());
        }


        [TestMethod()]
        public void InsertTestInspection()
        {
            var data = CreateTestInspectionsList();
            var set = new Mock<DbSet<Inspection>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Inspection>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.InspectionRepository.Insert(data.FirstOrDefault());

            set.Verify(m => m.Add(It.IsAny<Inspection>()), Times.Once());
        }

        [TestMethod()]
        public void DeleteTestInspection()
        {
            var data = CreateTestInspectionsList();
            var set = new Mock<DbSet<Inspection>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Inspection>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.InspectionRepository.Delete(data.FirstOrDefault().Id);

            set.Verify(m => m.Attach(It.IsAny<Inspection>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<Inspection>()), Times.Once());
        }


        [TestMethod()]
        public void DeleteObjectTestInspections()
        {
            var data = CreateTestInspectionsList();
            var set = new Mock<DbSet<Inspection>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<Inspection>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.InspectionRepository.Delete(1);

            set.Verify(m => m.Find(It.IsAny<int>()), Times.Once());
            set.Verify(m => m.Attach(It.IsAny<Inspection>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<Inspection>()), Times.Once());
        }

        [TestMethod()]
        public void UpdateTestInspections()
        {
            //var data = CreateReadyForTransportTestInspectionList();
            //var set = new Mock<DbSet<Inspection>>().SetupData(data);
            //set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            //var context = new Mock<CarManagementContext>();
            //context.Setup(ctx => ctx.Set<Inspection>()).Returns(set.Object);


            //var unitOfWork = new UnitOfWork(context.Object);

            //unitOfWork.InspectionRepository.Update(data.FirstOrDefault());

            //set.Verify(m => m.Attach(It.IsAny<Inspection>()), Times.Once());
        }
        #endregion
        #region Prueba movimiento de vehiculos


        [TestMethod()]
        public void GetAllVehicleMovementTestBD()
        {
            //var data = createTestVehicleMovement();
            //var set = new Mock<DbSet<VehicleMovement>>().SetupData(data);

            //var context = new Mock<CarManagementContext>();
            //context.Setup(ctx => ctx.Set<VehicleMovement>()).Returns(set.Object);

            //var unitOfWork = new UnitOfWork(context.Object);

            //Expression<Func<VehicleMovement, bool>> filter = dto => dto.Id > -1;
            //Func<IQueryable<VehicleMovement>, IOrderedQueryable<VehicleMovement>> orderBy = query => query.OrderBy(dto => dto.Id); ;
            //string includeProperties = "tesst";

            //IEnumerable<VehicleMovement> result = unitOfWork.VehicleMovementRepository.Get(filter, orderBy, includeProperties);

            //Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod()]
        public void GetVehicleMovementByIdTestVehicleMovements()
        {
            var data = CreateVehicleMovementsTest();
            var set = new Mock<DbSet<VehicleMovement>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<VehicleMovement>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);


            VehicleMovement result = unitOfWork.VehicleMovementRepository.GetByID(1);

            Assert.AreEqual(result, data.FirstOrDefault());
        }


        [TestMethod()]
        public void InsertTestVehicleMovement()
        {
            var data = CreateVehicleMovementsTest();
            var set = new Mock<DbSet<VehicleMovement>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<VehicleMovement>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.VehicleMovementRepository.Insert(data.FirstOrDefault());

            set.Verify(m => m.Add(It.IsAny<VehicleMovement>()), Times.Once());
        }

        [TestMethod()]
        public void DeleteTestVehicleMovement()
        {
            var data = CreateVehicleMovementsTest();
            var set = new Mock<DbSet<VehicleMovement>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<VehicleMovement>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.VehicleMovementRepository.Delete(data.FirstOrDefault().Id);

            set.Verify(m => m.Attach(It.IsAny<VehicleMovement>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<VehicleMovement>()), Times.Once());
        }


        [TestMethod()]
        public void DeleteObjectTestVehicleMovements()
        {
            var data = CreateVehicleMovementsTest();
            var set = new Mock<DbSet<VehicleMovement>>().SetupData(data);
            set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            var context = new Mock<CarManagementContext>();
            context.Setup(ctx => ctx.Set<VehicleMovement>()).Returns(set.Object);


            var unitOfWork = new UnitOfWork(context.Object);

            unitOfWork.VehicleMovementRepository.Delete(1);

            set.Verify(m => m.Find(It.IsAny<int>()), Times.Once());
            set.Verify(m => m.Attach(It.IsAny<VehicleMovement>()), Times.Once());
            set.Verify(m => m.Remove(It.IsAny<VehicleMovement>()), Times.Once());
        }

        [TestMethod()]
        public void UpdateTestVehicleMovements()
        {
            //var data = CreateReadyForTransportTestVehicleMovementList();
            //var set = new Mock<DbSet<VehicleMovement>>().SetupData(data);
            //set.Setup(m => m.Find(It.IsAny<int>())).Returns(data.FirstOrDefault());

            //var context = new Mock<CarManagementContext>();
            //context.Setup(ctx => ctx.Set<VehicleMovement>()).Returns(set.Object);


            //var unitOfWork = new UnitOfWork(context.Object);

            //unitOfWork.VehicleMovementRepository.Update(data.FirstOrDefault());

            //set.Verify(m => m.Attach(It.IsAny<VehicleMovement>()), Times.Once());
        }
        #endregion
    }

}
