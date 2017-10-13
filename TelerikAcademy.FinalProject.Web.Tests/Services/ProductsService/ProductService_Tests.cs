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

namespace TelerikAcademy.FinalProject.Web.Tests.Services.ProductsService
{
    [TestFixture]
    public class ProductService_Tests
    {
        [Test]
        public void GetAll_Should_InvocedRepository_All()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Product>>();
            var SaveContextStub = new Mock<ISaveContext>();
            var productsServiceMock = new TelerikAcademy.FinalProject.Services.ProductsService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            productsServiceMock.GetAll();

            // Assert
            EfRepositoryStub.Verify(x => x.All, Times.Once);
        }


        [Test]
        public void Update_Should_InvocedRepository_Update()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Product>>();
            var SaveContextStub = new Mock<ISaveContext>();
            var product = new Product();
            var productsServiceMock = new TelerikAcademy.FinalProject.Services.ProductsService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            productsServiceMock.Update(product);

            // Assert
            EfRepositoryStub.Verify(x => x.Update(product), Times.Once);
        }

        [Test]
        public void GetById_ShouldReturnsNullWhenProductIdNotValid()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Product>>();
            var SaveContextStub = new Mock<ISaveContext>();
            Guid? productId = Guid.NewGuid();


            var productService = new TelerikAcademy.FinalProject.Services.ProductsService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            Product productModel = productService.GetById(productId.Value);

            // Assert
            Assert.IsNull(productModel);
        }

        [Test]
        public void GetById_ShouldReturnsNullWhenProductIdIsNull()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Product>>();
            var SaveContextStub = new Mock<ISaveContext>();


            var productService = new TelerikAcademy.FinalProject.Services.ProductsService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            Product productModel = productService.GetById(null);

            // Assert
            Assert.IsNull(productModel);
        }

        [Test]
        public void GetByCategory_Should_InvocedRepository_All()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Product>>();
            var SaveContextStub = new Mock<ISaveContext>();
            var productsServiceMock = new TelerikAcademy.FinalProject.Services.ProductsService(EfRepositoryStub.Object, SaveContextStub.Object);
            var category = new Category();

            // Act
            productsServiceMock.GetByCategory(category.Id.Value);

            // Assert
            EfRepositoryStub.Verify(x => x.All, Times.Once);
        }
    }
}
