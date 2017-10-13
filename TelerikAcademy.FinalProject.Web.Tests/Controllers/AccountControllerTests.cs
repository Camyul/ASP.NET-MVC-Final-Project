using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Web.Contracts;
using TelerikAcademy.FinalProject.Web.Controllers;
using TestStack.FluentMVCTesting;

namespace TelerikAcademy.FinalProject.Web.Tests.Controllers
{
    public class AccountControllerTests
    {
        [Test]
        public void LoginSgould_ReturnViewWithReturnUrlInViewBag()
        {
            // Arrange
            var signInServiceMock = new Mock<ISignInService>();
            var userServiceMock = new Mock<IUserService>();

            string returnUrl = "url";

            AccountController accountController = new AccountController(signInServiceMock.Object, userServiceMock.Object);

            //Act & Assert
            accountController
                .WithCallTo(c => c.Login(returnUrl))
                .ShouldRenderDefaultView();

            Assert.AreEqual(returnUrl, accountController.ViewBag.ReturnUrl);
        }
    }
}
