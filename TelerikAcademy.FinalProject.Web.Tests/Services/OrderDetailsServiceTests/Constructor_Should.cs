using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;
using TelerikAcademy.FinalProject.Services;

namespace TelerikAcademy.FinalProject.Web.Tests.Services.OrderDetailsServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ConstructorShould_CreateCategoryInfoService()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<OrderDetail>>();
            var SaveContextStub = new Mock<ISaveContext>();

            // Act
            var orderService = new OrderDetailsService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Assert
            Assert.IsNotNull(orderService);
        }

        [Test]
        public void ThrowException_WhenEfRepositoryIsNull()
        {
            // Arrange
            var SaveContextStub = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new OrderDetailsService(null, SaveContextStub.Object));
        }

        [Test]
        public void ThrowException_WhenSaveContextIsNull()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<OrderDetail>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new OrderDetailsService(EfRepositoryStub.Object, null));
        }
    }
}
