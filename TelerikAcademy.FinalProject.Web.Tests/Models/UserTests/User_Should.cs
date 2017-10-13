using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Data.Model;

namespace TelerikAcademy.FinalProject.Web.Tests.Models.UserTests
{
    [TestFixture]
    class User_Should
    {
        [TestCase("erwrer32")]
        public void SetDataCorrectly(string userId)
        {
            //Arrange
            var user = new User { Id = userId };

            //Act & Assert
            Assert.AreEqual(user.Id, userId);
        }
    }
}
