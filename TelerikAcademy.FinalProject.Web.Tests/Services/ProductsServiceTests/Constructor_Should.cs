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
using TelerikAcademy.FinalProject.Services.Contracts;

namespace TelerikAcademy.FinalProject.Web.Tests.Services.ProductsService
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ConstructorShould_CreateProductService()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Product>>();
            var SaveContextStub = new Mock<ISaveContext>();

            // Act
            var productServiceMock = new TelerikAcademy.FinalProject.Services.ProductsService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Assert
            Assert.IsNotNull(productServiceMock);
        }

        [Test]
        public void ThrowException_WhenEfRepositoryIsNull()
        {
            // Arrange
            var SaveContextStub = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TelerikAcademy.FinalProject.Services.ProductsService(null, SaveContextStub.Object));
        }

        [Test]
        public void ThrowException_WhenSaveContextIsNull()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Product>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TelerikAcademy.FinalProject.Services.ProductsService(EfRepositoryStub.Object, null));
        }
    }
}
