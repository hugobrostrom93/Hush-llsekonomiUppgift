using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HushållsekonomiUppgift;

namespace UnitTestProject1
{
    [TestClass]
    internal class UnitTest1
    {
        [TestMethod]
        public void AdderaInkomsterTest()
        {
            // Arrange
            var sut = new Budgetawdawd();
            var expected = 26000;
            // Act
            var actual = budget.AdderaInkomster();
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
