using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Data;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.App_Start;

namespace TelerikAcademy.FinalProject.Web.IntegrationTests.Services.ProductServiceTests
{
    [TestFixture]
    public class GetById_Should
    {

        //private static Product dbProduct = new Product()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = "name",
        //    Description = "description",
        //    PictureUrl = "testtest",
        //    Quantity = 2,
        //    Price = 13
        //};

        //private static IKernel kernel;

        //[SetUp]
        //public void TestInit()
        //{
        //    kernel = InjectionConfig.CreateKernel();
        //    MsSqlDbContext dbContext = kernel.Get<MsSqlDbContext>();


        //    dbContext.Products.Add(dbProduct);
        //    dbContext.SaveChanges();
        //}

        //[TearDown]
        //public void TestCleanup()
        //{
        //    MsSqlDbContext dbContext = kernel.Get<MsSqlDbContext>();

        //    dbContext.Products.Attach(dbProduct);
        //    dbContext.Products.Remove(dbProduct);

        //    dbContext.SaveChanges();
        //}

        //[Test]
        //public void ReturnModelWithCorrectProperties_WhenThereIsAModelWithThePassedId()
        //{
        //    // Arrange
        //    IProductsService productsService = kernel.Get<IProductsService>();

        //    // Act
        //    Product result = productsService.GetById(dbProduct.Id);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(dbProduct.Id, result.Id);
        //    Assert.AreEqual(dbProduct.Name, result.Name);
        //    Assert.AreEqual(dbProduct.Description, result.Description);
        //    Assert.AreEqual(dbProduct.Quantity, result.Quantity);
        //    Assert.AreEqual(dbProduct.Price, result.Price);
        //}

        //[Test]
        //public void ReturnNull_WhenIdIsNull()
        //{
        //    // Arrange
        //    IProductsService productsService = kernel.Get<IProductsService>();

        //    // Act
        //    Product productModel = productsService.GetById(null);

        //    // Assert
        //    Assert.IsNull(productModel);
        //}

        //[Test]
        //public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        //{
        //    // Arrange
        //    IProductsService productsService = kernel.Get<IProductsService>();

        //    // Act
        //    Product productModel = productsService.GetById(Guid.NewGuid());

        //    // Assert
        //    Assert.IsNull(productModel);
        //}
    }
}
