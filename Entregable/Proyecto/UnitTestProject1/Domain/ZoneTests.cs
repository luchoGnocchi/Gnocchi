using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BetizagastiGnocchi.BackEnd.Domain.Entities;

namespace BetizagastiGnocchi.BackEnd.Test.Domain
{
    [TestClass]
    public class ZoneTests : SetUp
    {
        [TestMethod]
        public void CreateZoneTest()
        {
            List<Zone> subZonesTest = CreateSubZoneMaxCap100();
            Zone testZone = new Zone()
            {
                Name = "TestName",
                SubZones = subZonesTest,
                MaxCapacity = 100,
                UsedCapacity = 0
            };

            Assert.AreEqual(testZone.Name, "TestName");
            Assert.AreEqual(testZone.MaxCapacity, 100);
            Assert.IsNotNull(testZone.SubZones);
        }

        [TestMethod]
        public void ValidateSubZoneCapacityTrueTest()
        {
            List<Zone> subZonesTest = CreateSubZoneMaxCap100();
            Zone testZone = new Zone()
            {
                Name = "TestName",
                SubZones = subZonesTest,
                MaxCapacity = 100,
                UsedCapacity = 0
            };

            bool result = testZone.ValidateSubZonesCapacity();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateSubZoneCapacityFalseTest()
        {
            List<Zone> subZonesTest = CreateSubZoneMaxCap100();
            Zone testZone = new Zone()
            {
                Name = "TestName",
                SubZones = subZonesTest,
                MaxCapacity = 90,
                UsedCapacity = 0
            };

            bool result = testZone.ValidateSubZonesCapacity();

            Assert.IsFalse(result);
        }
    }
}
