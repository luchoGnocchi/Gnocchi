using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BetizagastiGnocchi.BackEnd.Domain.Entities;

namespace BetizagastiGnocchi.BackEnd.Test.Domain
{
    [TestClass]
    public class BatchTransportTests: SetUp
    {
        [TestMethod]
        public void CreateBatchTransportTest()
        {
            BatchTransport batchTransport = new BatchTransport()
            {
                Batchs = CreateReadyForTransportTestBatchList(),
                Transporter = CreateTestUser(),
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now
            };

            Assert.IsNotNull(batchTransport.Batchs);
            Assert.IsNotNull(batchTransport.Transporter);
            Assert.AreEqual(batchTransport.StartDate.Date, DateTime.Now.Date);

        }
    }
}
