using HushållsekonomiUppgift.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HushållsekonomiUppgift.Tests
{
    [TestClass()]
    public class BudgetTests
    {
        private EkonomiPerson person = new EkonomiPerson();

        [TestMethod]
        public void SummeraBudgetInkomstTest()
        {
            // Arrange
            var sut = new Beräkningar();
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
            var sut = new Beräkningar();
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
            var expected = person.TotalInkomst * 0.25m;
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
            var expected = 0m;
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
            var expected = 0m;
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
            var expected = 100m;
            // Act
            decimal actual = sut.BeräkningSpara(person);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BeräkningSparaTestNegative()
        {
            person.TotalInkomst = 16500;
            person.TotalUtgift = 18700;
            person.Spara = person.TotalInkomst * 0.10m;
            // Arrange
            var sut = new Logic();
            var expected = 0m;
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
            var expected = 5000m;
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
            var expected = -1000m;
            // Act
            decimal actual = sut.BeräkningKvar(person);
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}