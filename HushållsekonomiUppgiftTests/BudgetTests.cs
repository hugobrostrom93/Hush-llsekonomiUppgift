using Microsoft.VisualStudio.TestTools.UnitTesting;
using HushållsekonomiUppgift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.X509.SigI;

namespace HushållsekonomiUppgift.Tests
{
    [TestClass()]
    public class BudgetTests
    {
        EkonomiPerson person = new EkonomiPerson();
        [TestMethod]
        public void SummeraBudgetInkomstTest()
        {
            // Arrange
            var sut = new Budget();
            var expected = 14625;
            // Act
            var actual = sut.SummeraBudgetInkomst("Hanna");
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SummeraBudgetUtgiftTest()
        {
            // Arrange
            var sut = new Budget();
            var expected = 13409;
            // Act
            var actual = sut.SummeraBudgetUtgift("Hanna");
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BeräkningOanadeTestPositive()
        {
            person.TotalInkomst = 1000;
            // Arrange
            var sut = new Logic();
            var expected = (person.TotalInkomst * 25) / 100;
            // Act
            decimal actual = sut.BeräkningOanade(person);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BeräkningOanadeTestNegative()
        {
            person.TotalInkomst = -1000;
            // Arrange
            var sut = new Logic();
            var expected = (decimal)0;
            // Act
            decimal actual = sut.BeräkningOanade(person);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void OanadeOchTotUtgiftTestPositive()
        {
            person.Oanadeutgifter = 1000;
            person.Utgift = 1000;
            // Arrange
            var sut = new Logic();
            var expected = person.Oanadeutgifter + person.Utgift;
            // Act
            decimal actual = sut.OanadeOchTotUtgift(person);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void OanadeOchTotUtgiftTestNegative()
        {
            person.Oanadeutgifter = -1000;
            person.Utgift = -1000;
            // Arrange
            var sut = new Logic();
            var expected = (decimal)0;
            // Act
            decimal actual = sut.OanadeOchTotUtgift(person);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BeräkningSparaTestPositive()
        {
            person.TotalInkomst = 1000;
            person.Utgift = 0;
            // Arrange
            var sut = new Logic();
            var expected = (decimal)100;
            // Act
            decimal actual = sut.BeräkningSpara(person);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BeräkningSparaTestNegative()
        {
            person.TotalInkomst = 16500;
            person.Utgift = 18700;
            person.Spara = person.TotalInkomst * (decimal)0.10;
            // Arrange
            var sut = new Logic();
            var expected = (decimal)0;
            // Act
            decimal actual = sut.BeräkningSpara(person);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BeräkningKvarTestPositive()
        {
            person.TotalInkomst = 16000;
            person.Utgift = 8000;
            person.Oanadeutgifter = 3000;
            person.Spara = 0;
            // Arrange
            var sut = new Logic();
            var expected = (decimal)5000;
            // Act
            decimal actual = sut.BeräkningKvar(person);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BeräkningKvarTestNegative()
        {
            person.TotalInkomst = 10000;
            person.Utgift = 8000;
            person.Oanadeutgifter = 3000;
            person.Spara = 0;
            // Arrange
            var sut = new Logic();
            var expected = (decimal)-1000;
            // Act
            decimal actual = sut.BeräkningKvar(person);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void AdderaInkomsterTest2()
        //{
        //    // Arrange
        //    var sut = new Budget();
        //    sut.AddLists(); // Måste lägga till denna för att få in värden i listorna
        //    var expected = 26000;
        //    // Act
        //    var actual = sut.AdderaInkomster();
        //    // Assert
        //    Assert.AreEqual(expected, actual);
        //}


    }
}