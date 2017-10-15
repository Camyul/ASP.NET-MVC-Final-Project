using Moq;
using NUnit.Framework;
using System;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;
using TelerikAcademy.FinalProject.Services;

namespace TelerikAcademy.FinalProject.Web.Tests.Services.OrderServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ConstructorShould_CreateCategoryInfoService()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Order>>();
            var SaveContextStub = new Mock<ISaveContext>();

            // Act
            var orderService = new OrderService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Assert
            Assert.IsNotNull(orderService);
        }

        [Test]
        public void ThrowException_WhenEfRepositoryIsNull()
        {
            // Arrange
            var SaveContextStub = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new OrderService(null, SaveContextStub.Object));
        }

        [Test]
        public void ThrowException_WhenSaveContextIsNull()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Order>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new OrderService(EfRepositoryStub.Object, null));
        }
    }
}
