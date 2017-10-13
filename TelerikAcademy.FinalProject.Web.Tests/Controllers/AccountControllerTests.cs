using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TelerikAcademy.FinalProject.Web.Contracts;
using TelerikAcademy.FinalProject.Web.Controllers;
using TelerikAcademy.FinalProject.Web.Models;
using TestStack.FluentMVCTesting;

namespace TelerikAcademy.FinalProject.Web.Tests.Controllers
{
    public class AccountControllerTests
    {
        [Test]
        public void ConstructorShould_CreateAccountController_WhenParamsAreValid()
        {
            // Arrange
            var signInServiceMock = new Mock<ISignInService>();
            var userServiceMock = new Mock<IUserService>();
            AccountController accountController = new AccountController(signInServiceMock.Object, userServiceMock.Object);


            //Act & Assert
            Assert.That(accountController, Is.InstanceOf<AccountController>());
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenUserServiceIsNull()
        {
            //Arrange
            var signInServiceMock = new Mock<ISignInService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AccountController(signInServiceMock.Object, null));
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenSignInServiceIsNull()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AccountController(null, userServiceMock.Object));
        }

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

        [Test]
        public void LoginSgould_ReturnViewWithModel_IfModelstateIsInvalid()
        {
            // Arrange
            var signInServiceMock = new Mock<ISignInService>();
            var userServiceMock = new Mock<IUserService>();
            AccountController accountController = new AccountController(signInServiceMock.Object, userServiceMock.Object);

            accountController.ModelState.AddModelError("", "dummy error");

            LoginViewModel model = new LoginViewModel();
            string returnUrl = "url";

            // Act & Assert
            accountController
                .WithCallTo(c => c.Login(model, returnUrl))
                .ShouldRenderDefaultView()
                .WithModel(model);
        }

        [Test]
        public void LoginSgould_ReturnActionResult_WhenInvoked()
        {
            // Arrange
            var signInServiceMock = new Mock<ISignInService>();
            var userServiceMock = new Mock<IUserService>();
            AccountController accountController = new AccountController(signInServiceMock.Object, userServiceMock.Object);

            LoginViewModel model = new LoginViewModel();
            string returnUrl = "url";

            //Act & Assert
            Assert.IsInstanceOf<Task<ActionResult>>(accountController.Login(model, returnUrl));
        }

        [Test]
        public void RegisterShould_ReturnViewWithModel_IfModelstateIsInvalid()
        {
            // Arrange
            var signInServiceMock = new Mock<ISignInService>();
            var userServiceMock = new Mock<IUserService>();
            AccountController accountController = new AccountController(signInServiceMock.Object, userServiceMock.Object);


            accountController.ModelState.AddModelError("", "dummy error");

            RegisterViewModel model = new RegisterViewModel();

            // Act & Assert
            accountController
                .WithCallTo(c => c.Register(model))
                .ShouldRenderDefaultView()
                .WithModel(model);
        }

        [Test]
        public void RegisterShould_ReturnActionResult_WhenInvoked()
        {
            // Arrange
            var signInServiceMock = new Mock<ISignInService>();
            var userServiceMock = new Mock<IUserService>();
            AccountController accountController = new AccountController(signInServiceMock.Object, userServiceMock.Object);


            RegisterViewModel model = new RegisterViewModel();

            //Act & Assert
            Assert.IsInstanceOf<Task<ActionResult>>(accountController.Register(model));
        }
    }
}
