using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.Controllers;
using TelerikAcademy.FinalProject.Web.Models.Home;

namespace TelerikAcademy.FinalProject.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            
            var productServiceMock = new Mock<IProductsService>();
            // var mapperMock = new Mock<IMapper>();
            HomeController controller = new HomeController(productServiceMock.Object);//, mapperMock.Object);
         

            // Act
           var result = controller.Index();

            // Assert
            productServiceMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void About()
        {
            // Arrange
            var productServiceMock = new Mock<IProductsService>();
            HomeController controller = new HomeController(productServiceMock.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [Test]
        public void Contact()
        {
            var productServiceMock = new Mock<IProductsService>();
            HomeController controller = new HomeController(productServiceMock.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
