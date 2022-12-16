using Microsoft.VisualStudio.TestTools.UnitTesting;
using HushållsekonomiUppgift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushållsekonomiUppgift.Tests
{
    [TestClass()]
    public class BudgetTests
    {
        [TestMethod]
        public void AdderaInkomsterTest1()
        {
        Assert.Fail();
        }

        [TestMethod]
        public void AdderaInkomsterTest2()
        {
            // Arrange
            var sut = new Budget();
            sut.AddLists(); // Måste lägga till denna för att få in värden i listorna
            var expected = 26000;
            // Act
            var actual = sut.AdderaInkomster();
            // Assert
            Assert.AreEqual(expected, actual);
        }


    }
}