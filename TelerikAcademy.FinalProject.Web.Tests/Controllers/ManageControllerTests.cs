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
using TestStack.FluentMVCTesting;
using static TelerikAcademy.FinalProject.Web.Controllers.ManageController;

namespace TelerikAcademy.FinalProject.Web.Tests.Controllers
{
    [TestFixture]
    public class ManageControllerTests
    {
        [Test]
        public void ConstructorShould_CreateAccountController_WhenParamsAreValid()
        {
            // Arrange
            var signInServiceMock = new Mock<ISignInService>();
            var userServiceMock = new Mock<IUserService>();
           ManageController manageController = new ManageController(signInServiceMock.Object, userServiceMock.Object);


            //Act & Assert
            Assert.That(manageController, Is.InstanceOf<ManageController>());
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenUserServiceIsNull()
        {
            //Arrange
            var signInServiceMock = new Mock<ISignInService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ManageController(signInServiceMock.Object, null));
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenSignInServiceIsNull()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ManageController(null, userServiceMock.Object));
        }

        [Test]
        public void IndexShould_ReturnValue_WhenParamsAreValid()
        {
            // Arrange
            var signInServiceMock = new Mock<ISignInService>();
            var userServiceMock = new Mock<IUserService>();
            ManageController manageController = new ManageController(signInServiceMock.Object, userServiceMock.Object);

            var result = manageController.Index(ManageMessageId.ChangePasswordSuccess);

            //Act & Assert
            Assert.NotNull(result);
        }
    }
}
