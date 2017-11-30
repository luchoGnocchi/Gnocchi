using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BetizagastiGnocchi.BackEnd.Domain.Entities;

namespace BetizagastiGnocchi.BackEnd.Test.Domain
{
    [TestClass]
    public class DamageRegistryTests : SetUp
    {
        [TestMethod]
        public void CreateDamageRegistryTest()
        {
            DamageRegistry damageRegistry = new DamageRegistry()
            {
                Description = "TestDescription"
            };

            Assert.AreEqual(damageRegistry.Description, "TestDescription");
        }
    }
}
