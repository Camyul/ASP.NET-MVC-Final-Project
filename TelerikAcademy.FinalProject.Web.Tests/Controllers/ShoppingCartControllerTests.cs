using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.Areas.Administration.Controllers;
using TelerikAcademy.FinalProject.Web.Areas.Administration.Models.ShoppingCart;
using TelerikAcademy.FinalProject.Web.Contracts;
using TestStack.FluentMVCTesting;

namespace TelerikAcademy.FinalProject.Web.Tests.Controllers
{
    [TestFixture]
    public class ShoppingCartControllerTests
    {
        [Test]
        public void ConstructorShould_ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var productsServiceMock = new Mock<IProductsService>();
            var ordersServiceMock = new Mock<IOrderService>();
            var orderDetailsServiceMock = new Mock<IOrderDetailsService>();
            var contactInfoServiceMock = new Mock<IContactInfoService>();
            var userServiceMock = new Mock<IUserService>();

            // Act
            ShoppingCartController shoppingCartController = new ShoppingCartController(
                productsServiceMock.Object,
                ordersServiceMock.Object,
                orderDetailsServiceMock.Object,
                contactInfoServiceMock.Object,
                userServiceMock.Object
                );

            // Assert
            Assert.IsNotNull(shoppingCartController);
        }

        [Test]
        public void ConstructorShould_ThrowException_WhenProductsServiceAreNull()
        {
            // Arrange 
            var ordersServiceMock = new Mock<IOrderService>();
            var orderDetailsServiceMock = new Mock<IOrderDetailsService>();
            var contactInfoServiceMock = new Mock<IContactInfoService>();
            var userServiceMock = new Mock<IUserService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ShoppingCartController(
                null,
                ordersServiceMock.Object,
                orderDetailsServiceMock.Object,
                contactInfoServiceMock.Object,
                userServiceMock.Object
                ));
        }

        [Test]
        public void ConstructorShould_ThrowException_WhenOrderServiceAreNull()
        {
            // Arrange 
            var productsServiceMock = new Mock<IProductsService>();
            var orderDetailsServiceMock = new Mock<IOrderDetailsService>();
            var contactInfoServiceMock = new Mock<IContactInfoService>();
            var userServiceMock = new Mock<IUserService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ShoppingCartController(
                productsServiceMock.Object,
                null,
                orderDetailsServiceMock.Object,
                contactInfoServiceMock.Object,
                userServiceMock.Object
                ));
        }

        [Test]
        public void ConstructorShould_ThrowException_WhenOrderDetailsServiceAreNull()
        {
            // Arrange 
            var productsServiceMock = new Mock<IProductsService>();
            var ordersServiceMock = new Mock<IOrderService>();
            var contactInfoServiceMock = new Mock<IContactInfoService>();
            var userServiceMock = new Mock<IUserService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ShoppingCartController(
                productsServiceMock.Object,
                ordersServiceMock.Object,
                null,
                contactInfoServiceMock.Object,
                userServiceMock.Object
                ));
        }

        [Test]
        public void ConstructorShould_ThrowException_WhenContactInfoServiceAreNull()
        {
            // Arrange 
            var productsServiceMock = new Mock<IProductsService>();
            var ordersServiceMock = new Mock<IOrderService>();
            var orderDetailsServiceMock = new Mock<IOrderDetailsService>();
            var userServiceMock = new Mock<IUserService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ShoppingCartController(
                productsServiceMock.Object,
                ordersServiceMock.Object,
                orderDetailsServiceMock.Object,
                null,
                userServiceMock.Object
                ));
        }

        [Test]
        public void ConstructorShould_ThrowException_WhenUserServicAreNull()
        {
            // Arrange 
            var productsServiceMock = new Mock<IProductsService>();
            var ordersServiceMock = new Mock<IOrderService>();
            var orderDetailsServiceMock = new Mock<IOrderDetailsService>();
            var contactInfoServiceMock = new Mock<IContactInfoService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ShoppingCartController(
                productsServiceMock.Object,
                ordersServiceMock.Object,
                orderDetailsServiceMock.Object,
                contactInfoServiceMock.Object,
                null
                ));
        }

        [Test]
        public void MyCartShould_ReturnsView()
        {
            // Arrange
            var mockControllerContext = new Mock<ControllerContext>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(s => s["cart"]).Returns(null);
            mockControllerContext.Setup(p => p.HttpContext.Session).Returns(mockSession.Object);

            var productsServiceMock = new Mock<IProductsService>();
            var ordersServiceMock = new Mock<IOrderService>();
            var orderDetailsServiceMock = new Mock<IOrderDetailsService>();
            var contactInfoServiceMock = new Mock<IContactInfoService>();
            var userServiceMock = new Mock<IUserService>();

            ShoppingCartController shoppingCartController = new ShoppingCartController(
                productsServiceMock.Object,
                ordersServiceMock.Object,
                orderDetailsServiceMock.Object,
                contactInfoServiceMock.Object,
                userServiceMock.Object
                );

            shoppingCartController.ControllerContext = mockControllerContext.Object;


            // Act & Assert
            shoppingCartController
                 .WithCallTo(s => s.MyCart())
                     .ShouldRenderView("EmptyCart");
        }

        [Test]
        public void MyCartReturnCart_WhenThereIsProducts()
        {
            // Arrange 
            var controllerContextMock = new Mock<ControllerContext>();
            var sessionMock = new Mock<HttpSessionStateBase>();
            var productServiceMock = new Mock<IProductsService>();
            var orderServiceMock = new Mock<IOrderService>();
            var orderDetailsServiceMock = new Mock<IOrderDetailsService>();
            var contactInfoServiceMock = new Mock<IContactInfoService>();
            var userServiceMock = new Mock<IUserService>();

            ShoppingCartController shoppingCartController = new ShoppingCartController(
                productServiceMock.Object,
                orderServiceMock.Object,
                orderDetailsServiceMock.Object,
                contactInfoServiceMock.Object,
                userServiceMock.Object);
            shoppingCartController.CartItems = new List<OrderDetailViewModel>();

            sessionMock.SetupGet(s => s["cart"]).Returns(shoppingCartController.CartItems);
            controllerContextMock.Setup(p => p.HttpContext.Session).Returns(sessionMock.Object);

            shoppingCartController.ControllerContext = controllerContextMock.Object;

            // Act & Assert
            shoppingCartController
                 .WithCallTo(s => s.MyCart())
                     .ShouldRenderView("MyCart");

        }

        [Test]
        public void DeleteReturnSomeRoute_WhenOrderDetailIsDeleted()
        {
            // Arrange 
            var controllerContextMock = new Mock<ControllerContext>();
            var sessionMock = new Mock<HttpSessionStateBase>();

            var productServiceMock = new Mock<IProductsService>();
            var orderServiceMock = new Mock<IOrderService>();
            var orderDetailsServiceMock = new Mock<IOrderDetailsService>();
            var contactInfoServiceMock = new Mock<IContactInfoService>();
            var userServiceMock = new Mock<IUserService>();

            ShoppingCartController shoppingCartController = new ShoppingCartController(
                productServiceMock.Object,
                orderServiceMock.Object,
                orderDetailsServiceMock.Object,
                contactInfoServiceMock.Object,
                userServiceMock.Object);
            shoppingCartController.CartItems = new List<OrderDetailViewModel>();
            var order = new OrderDetailViewModel();
            shoppingCartController.CartItems.Add(order);

            sessionMock.SetupGet(s => s["cart"]).Returns(shoppingCartController.CartItems);
            controllerContextMock.Setup(p => p.HttpContext.Session).Returns(sessionMock.Object);

            shoppingCartController.ControllerContext = controllerContextMock.Object;

            // Act & Assert
            shoppingCartController
                 .WithCallTo(s => s.Delete(0))
                 .ShouldRedirectToRoute("");

        }
    }
}
