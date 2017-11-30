using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BetizagastiGnocchi.BackEnd.Test;
using BetizagastiGnocchi.BackEnd.Domain.Entities;
using System.Collections.Generic;

namespace BetizagastiGnocchi.BackEnd.Test.Domain
{
    [TestClass]
    public class BatchTests : SetUp
    {
        [TestMethod]
        public void CreateBatchTest()
        {
            
            Batch testBatch = new Batch
            {
                Creator = CreateTestUser(),
                Name = "TestBatch",
                Description = "TestDescription",
                Vehicles = CreateTestVehicleList()
            };

            Assert.AreEqual(testBatch.Name, "TestBatch");
            Assert.AreEqual(testBatch.Description, "TestDescription");
            Assert.IsNotNull(testBatch.Vehicles);
            Assert.IsNotNull(testBatch.Creator);
        }

        [TestMethod]
        public void BatchToStringTest()
        {
            var testBatch = CreateTestBatchWithVehicles();
            String toString = testBatch.ToString();

            Assert.AreEqual(toString, "Lote: TestBatch || TestDescription");
        }

        [TestMethod]
        public void BatchReadyForTransportTest()
        {
            var testBatch = CreateEmptyTestBatch();
            var testVehicle = CreateTestVehicle1();
            testVehicle.Inspections.Add(CreateTestInspectionOK());
            testVehicle.HistoryState.Add(CreateTestPortState());
            testBatch.Vehicles.Add(testVehicle);

            Assert.IsTrue(testBatch.ReadyForTransport());
        }

        [TestMethod]
        public void EmptyBatchReadyForTransport()
        {
            var testBatch = CreateEmptyTestBatch();

            Assert.IsTrue(testBatch.ReadyForTransport());
        }

        [TestMethod]
        public void BatchNotReadyForTransportTest()
        {
            var testBatch = CreateEmptyTestBatch();

            var testVehicle = CreateTestVehicle1();
            testVehicle.Inspections.Add(CreateTestInspectionOK());
            testVehicle.HistoryState.Add(CreateTestPortState());
            testBatch.Vehicles.Add(testVehicle);

            var testVehicle2 = CreateTestVehicle2();
            testVehicle2.Inspections.Add(CreateTestInspectionDAMAGED());
            testVehicle2.HistoryState.Add(CreateTestPortState());
            testBatch.Vehicles.Add(testVehicle2);

            Assert.IsFalse(testBatch.ReadyForTransport());
        }

        [TestMethod]
        public void BatchNotReadyForTransportTest2()
        {
            var testBatch = CreateEmptyTestBatch();

            var testVehicle = CreateTestVehicle1();
            testVehicle.Inspections.Add(CreateTestInspectionDAMAGED());
            testBatch.Vehicles.Add(testVehicle);

            Assert.IsFalse(testBatch.ReadyForTransport());
        }

    }
}
