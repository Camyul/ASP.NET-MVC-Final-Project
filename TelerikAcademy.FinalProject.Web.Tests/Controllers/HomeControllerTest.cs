using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.Controllers;

namespace TelerikAcademy.FinalProject.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void AboutShould_DisplayMessage()
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
        public void ContactShould_ReturnView()
        {
            //Arrange
            var productServiceMock = new Mock<IProductsService>();
            HomeController controller = new HomeController(productServiceMock.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //[Test]
        //public void IndexShould_GetAllCalledExactlyOncee()
        //{
        //    // Arrange

        //    var productServiceMock = new Mock<IProductsService>();
        //    // var mapperMock = new Mock<IMapper>();
        //    HomeController controller = new HomeController(productServiceMock.Object);//, mapperMock.Object);


        //    // Act
        //    var result = controller.Index();

        //    // Assert
        //    productServiceMock.Verify(x => x.GetAll(), Times.Once);
        //}
    }
}
