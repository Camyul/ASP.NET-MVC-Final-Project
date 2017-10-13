using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.Controllers;
using TelerikAcademy.FinalProject.Web.Models.Home;
using TestStack.FluentMVCTesting;

namespace TelerikAcademy.FinalProject.Web.Tests.Controllers
{
    [TestFixture]
    public class ProductsControllerTests
    {
        [Test]
        public void ConstructorShould_ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var productsServiceMock = new Mock<IProductsService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            // Act
            ProductsController productsController = new ProductsController(productsServiceMock.Object, categoryServiceMock.Object);

            // Assert
            Assert.IsNotNull(productsController);
        }

        [Test]
        public void ConstructorShould_ThrowException_WhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ProductsController(null, null));
        }

        [Test]
        public void IndexShould_ReturnsView()
        {
            //Arrange
            var productServiceMock = new Mock<IProductsService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            ProductsController controller = new ProductsController(productServiceMock.Object, categoryServiceMock.Object);


            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddProductShould_InvocedAddProduct()
        {
            //Arrange
            var productServiceMock = new Mock<IProductsService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            ProductsController controller = new ProductsController(productServiceMock.Object, categoryServiceMock.Object);
            Category category = new Category();
            Product product = new Product() { Category = category};
            ProductViewModel viewModel = new ProductViewModel(product);

            // Act
            controller.AddProduct(viewModel);

            // Assert
            productServiceMock.Setup(p => p.AddProduct(product)).Verifiable();
        }

        [Test]
        public void AddProductShould_ReturnsView()
        {
            //Arrange
            var productServiceMock = new Mock<IProductsService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            ProductsController controller = new ProductsController(productServiceMock.Object, categoryServiceMock.Object);

            // Act
            ViewResult result = controller.AddProduct() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void DetailsShould_ReturnViewWithModelWithCorrectProperties_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            var productsServiceMock = new Mock<IProductsService>();

            var productModel = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "name",
                Description = "descr",
                Category = new Category(),
                LongDescription = "sdkijs",
                Quantity = 3,
                PictureUrl = "picUrl",
                Price = 5.55M,
            };

            var productViewModel = new ProductViewModel(productModel);
            var categoryServiceMock = new Mock<ICategoryService>();

            productsServiceMock.Setup(m => m.GetById(productModel.Id)).Returns(productModel);

            ProductsController productsController = new ProductsController(productsServiceMock.Object, categoryServiceMock.Object);

            //Act & Assert
            productsController
                .WithCallTo(b => b.Details(productModel.Id))
                .ShouldRenderDefaultView()
                .WithModel<ProductViewModel>(viewModel =>
                {
                    Assert.AreEqual(productModel.Id, viewModel.Id);
                    Assert.AreEqual(productModel.Name, viewModel.Name);
                    Assert.AreEqual(productModel.Quantity, viewModel.Quantity);
                    Assert.AreEqual(productModel.PictureUrl, viewModel.PictureUrl);
                    Assert.AreEqual(productModel.Price, viewModel.Price);
                });
        }

        [Test]
        public void ProductsByCategory_ReturnsView()
        {
            //Arrange
            var productsServiceMock = new Mock<IProductsService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            IEnumerable<Product> categoryList = new List<Product>();
            var category = new Category();

            // Act
            ProductsController controller = new ProductsController(productsServiceMock.Object, categoryServiceMock.Object);

            ViewResult result = controller.ProductsByCategory(category.Id.Value) as ViewResult;

            //  Assert

            Assert.NotNull(result);
        }

        [Test]
        public void FilteredProducts_ReturnsPartialView_WhenPassedValidString()
        {
            //Arrange
            var productsServiceMock = new Mock<IProductsService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            string searchName = "test";

            // Act
            ProductsController controller = new ProductsController(productsServiceMock.Object, categoryServiceMock.Object);

    


            //  Assert
            controller
                .WithCallTo(c => c.FilteredProducts(searchName))
                .ShouldRenderPartialView("_FilteredProductsPartial");
        }

        [Test]
        public void FilteredProducts_ReturnsView_WhenPassedValidString()
        {
            //Arrange
            var productsServiceMock = new Mock<IProductsService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            // Act
            ProductsController controller = new ProductsController(productsServiceMock.Object, categoryServiceMock.Object);




            //  Assert
            controller
                .WithCallTo(c => c.FilteredProducts(null))
                .ShouldRenderDefaultView();
        }
    }
}
