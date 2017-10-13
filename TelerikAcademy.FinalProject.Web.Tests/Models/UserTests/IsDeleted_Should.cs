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
    class IsDeleted_Should
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SetDataCorrectly(bool isDeleted)
        {
            //Arrange
            var user = new User { IsDeleted = isDeleted };

            //Act & Assert
            Assert.AreEqual(user.IsDeleted, isDeleted);
        }
    }
}
