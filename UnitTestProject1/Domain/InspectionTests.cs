using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BetizagastiGnocchi.BackEnd.Domain.Enum;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using System.Collections.Generic;

namespace BetizagastiGnocchi.BackEnd.Test.Domain
{
    [TestClass]
    public class InspectionTests : SetUp
    {
        [TestMethod]
        public void CreateOKInspectionTest()
        {
            Inspection inspection = new Inspection
            {
                Status = InspectionStatus.OK,
                DateAndTime = DateTime.Now,
                Place =InspectionPlace.Patio,
                Inspector = CreateTestUser(),
                Vehicle = CreateTestVehicle1(),
                DamageRegistries = new List<DamageRegistry>()
            };

            Assert.AreEqual(inspection.Place, InspectionPlace.Patio);
            Assert.AreEqual(inspection.DateAndTime.Date, DateTime.Now.Date);
            Assert.IsNotNull(inspection.Inspector);
            Assert.IsNotNull(inspection.Vehicle);
            Assert.AreEqual(inspection.Status, InspectionStatus.OK);
            Assert.IsTrue(inspection.DamageRegistries.Count == 0);

        }

        [TestMethod]
        public void CreateDAMAGEDInspectionTest()
        {
            Inspection inspection = new Inspection
            {
                Status = InspectionStatus.DAMAGED,
                DateAndTime = DateTime.Now,
                Place = InspectionPlace.Patio,
                Inspector = CreateTestUser(),
                Vehicle = CreateTestVehicle1(),
                DamageRegistries = CreateTestDamageRegistryList()
            };

            Assert.AreEqual(inspection.Place, InspectionPlace.Patio);
            Assert.AreEqual(inspection.DateAndTime.Date, DateTime.Now.Date);
            Assert.IsNotNull(inspection.Inspector);
            Assert.IsNotNull(inspection.Vehicle);
            Assert.AreEqual(inspection.Status, InspectionStatus.DAMAGED);
            Assert.IsTrue(inspection.DamageRegistries.Count == 2);

        }

    }
}
