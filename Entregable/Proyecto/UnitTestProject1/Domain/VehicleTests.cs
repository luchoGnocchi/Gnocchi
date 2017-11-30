using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using System.Collections.Generic;

namespace BetizagastiGnocchi.BackEnd.Test.Domain
{
	[TestClass]
	public class VehicleTests : SetUp
	{
		[TestMethod]
		public void CreateVehicleTest()
		{
            Vehicle vehicleTest = new Vehicle()
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2018,
                Color = "Rojo",
                VehicleType = "Auto",
                VIN = "AAA-222-CC",
                Inspections = new List<Inspection>()
            };


            Assert.AreEqual(vehicleTest.Brand, "Toyota");
            Assert.AreEqual(vehicleTest.Model, "Corolla");
            Assert.AreEqual(vehicleTest.Year, 2018);
            Assert.AreEqual(vehicleTest.Color, "Rojo");
            Assert.AreEqual(vehicleTest.VehicleType, "Auto");
            Assert.AreEqual(vehicleTest.VIN, "AAA-222-CC");
        }

        [TestMethod]
        public void VehicleToStringTest()
        {
            var testVehicle = CreateTestVehicle1();
            String toString = testVehicle.ToString();

            Assert.AreEqual(toString, "Auto Toyota Corolla 2018, Color Rojo, VIN: AAA-222-CC");
        }

        [TestMethod]
        public void VehicleReadyToGoTest()
        {
            var testVehicle = CreateTestVehicle1();
            var inspection = CreateTestInspectionOK();

            testVehicle.Inspections.Add(inspection);
            testVehicle.HistoryState.Add(CreateTestPortState());

            Assert.IsTrue(testVehicle.ReadyToGo());
        }

        [TestMethod]
        public void VehicleReadyToGoTest2()
        {
            var testVehicle = CreateTestVehicle1();
            var inspection = CreateTestInspectionOK();
            var inspection2 = CreateTestInspectionDAMAGED();

            testVehicle.Inspections.Add(inspection2);
            testVehicle.HistoryState.Add(CreateTestPortState());
            testVehicle.Inspections.Add(inspection);
            testVehicle.HistoryState.Add(CreateTestPortState());

            Assert.IsTrue(testVehicle.ReadyToGo());
        }

        [TestMethod]
        public void VehicleNOTReadyToGoTest()
        {
            var testVehicle = CreateTestVehicle1();
            var inspection = CreateTestInspectionDAMAGED();

            testVehicle.Inspections.Add(inspection);

            Assert.IsFalse(testVehicle.ReadyToGo());
        }

        [TestMethod]
        public void VehicleNOTReadyToGoTest2()
        {
            var testVehicle = CreateTestVehicle1();
            var inspection = CreateTestInspectionOK();
            var inspection2 = CreateTestInspectionDAMAGED();

            testVehicle.Inspections.Add(inspection);
            testVehicle.Inspections.Add(inspection2);

            Assert.IsFalse(testVehicle.ReadyToGo());
        }
    }
}
