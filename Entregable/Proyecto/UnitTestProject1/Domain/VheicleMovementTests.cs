using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BetizagastiGnocchi.BackEnd.Domain.Entities;

namespace BetizagastiGnocchi.BackEnd.Test.Domain
{
    [TestClass]
    public class VheicleMovementTests : SetUp
    {
        [TestMethod]
        public void CreateVehicleMovement()
        {
            VehicleMovement vehicleMovement = new VehicleMovement()
            {
                Time = DateTime.Now.Hour,
                User = CreateTestUser(),
                Vehicle = CreateTestVehicle1(),
                OriginZone = CreateTestZone50Cap(),
                DestinationZone = CreateTestZone50Cap()
            };

            Assert.AreEqual(vehicleMovement.Time, DateTime.Now.Hour);
            Assert.IsNotNull(vehicleMovement.User);
            Assert.IsNotNull(vehicleMovement.Vehicle);
            Assert.IsNotNull(vehicleMovement.OriginZone);
            Assert.IsNotNull(vehicleMovement.DestinationZone);
        }
    }
}
