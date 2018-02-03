using System;
using NUnit.Framework;
using eService.Web.ViewModels.Orders;

namespace eService.Tests.WebTests.ViewModelsTests.Orders
{
    [TestFixture]
    public class OrderViewModelTests
    {
        [Test]
        public void NumberProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = 123;

            // Act
            sut.Number = expected;

            // Assert
            Assert.AreEqual(expected, sut.Number);
        }

        [Test]
        public void DateProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = DateTime.Now;

            // Act
            sut.Date = expected;

            // Assert
            Assert.AreEqual(expected, sut.Date);
        }

        [Test]
        public void WarrantyCardNumberProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = 123;

            // Act
            sut.WarrantyCardNumber = expected;

            // Assert
            Assert.AreEqual(expected, sut.WarrantyCardNumber);
        }

        [Test]
        public void WarrantyCardDateProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = DateTime.Now;

            // Act
            sut.WarrantyCardDate = expected;

            // Assert
            Assert.AreEqual(expected, sut.WarrantyCardDate);
        }

        [Test]
        public void ArticleProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = "laptop";

            // Act
            sut.Article = expected;

            // Assert
            Assert.AreEqual(expected, sut.Article);
        }

        [Test]
        public void SerialNumberProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = "123";

            // Act
            sut.SerialNumber = expected;

            // Assert
            Assert.AreEqual(expected, sut.SerialNumber);
        }

        [Test]
        public void IsHighPriorityProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = true;

            // Act
            sut.IsHighPriority = expected;

            // Assert
            Assert.True(sut.IsHighPriority);
        }

        [Test]
        public void DefectProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = "not working";

            // Act
            sut.Defect = expected;

            // Assert
            Assert.AreEqual(expected, sut.Defect);
        }

        [Test]
        public void InfoProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = "123";

            // Act
            sut.Info = expected;

            // Assert
            Assert.AreEqual(expected, sut.Info);
        }

        [Test]
        public void StatusProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = "returned";

            // Act
            sut.Status = expected;

            // Assert
            Assert.AreEqual(expected, sut.Status);
        }

        [Test]
        public void IsWarrantyServiceProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = false;

            // Act
            sut.IsWarrantyService = expected;

            // Assert
            Assert.False(sut.IsWarrantyService);
        }

        [Test]
        public void CustomerNameProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = "Pesho Goshov";

            // Act
            sut.CustomerName = expected;

            // Assert
            Assert.AreEqual(expected, sut.CustomerName);
        }

        [Test]
        public void CustomerPhoneNumberProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = "123";

            // Act
            sut.CustomerPhoneNumber = expected;

            // Assert
            Assert.AreEqual(expected, sut.CustomerPhoneNumber);
        }

        [Test]
        public void CustomerTownProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = "Plovdiv";

            // Act
            sut.CustomerTown = expected;

            // Assert
            Assert.AreEqual(expected, sut.CustomerTown);
        }

        [Test]
        public void CustomerStreetProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = "Bulgaria Str.";

            // Act
            sut.CustomerStreet = expected;

            // Assert
            Assert.AreEqual(expected, sut.CustomerStreet);
        }

        [Test]
        public void CustomerAddressNumberProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = 123;

            // Act
            sut.CustomerAddressNumber = expected;

            // Assert
            Assert.AreEqual(expected, sut.CustomerAddressNumber);
        }

        [Test]
        public void CustomerAddressEntryProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = "A";

            // Act
            sut.CustomerAddressEntry = expected;

            // Assert
            Assert.AreEqual(expected, sut.CustomerAddressEntry);
        }

        [Test]
        public void CustomerAddressFloorProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = 123;

            // Act
            sut.CustomerAddressFloor = expected;

            // Assert
            Assert.AreEqual(expected, sut.CustomerAddressFloor);
        }

        [Test]
        public void CustomerAddressApartmentNumberProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = 123;

            // Act
            sut.CustomerAddressApartmentNumber = expected;

            // Assert
            Assert.AreEqual(expected, sut.CustomerAddressApartmentNumber);
        }

        [Test]
        public void EmployeeNameProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = "Kiril Genchev";

            // Act
            sut.EmployeeName = expected;

            // Assert
            Assert.AreEqual(expected, sut.EmployeeName);
        }

        [Test]
        public void SupplierNameProperty_ShouldReturnCorrectValue_WhenIsSet()
        {
            // Arrange
            var sut = new OrderViewModel();
            var expected = "Microsoft";

            // Act
            sut.SupplierName = expected;

            // Assert
            Assert.AreEqual(expected, sut.SupplierName);
        }
    }
}
