using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Data;
using TelerikAcademy.FinalProject.Data.SaveContext;

namespace TelerikAcademy.FinalProject.Web.Tests.Data.SaveContextTests
{
    [TestFixture]
    public class Commit_Should
    {
        [Test]
        public void BeInvokedOnce()
        {
            //Arrange
            var mockedContext = new Mock<MsSqlDbContext>();
            var saveContext = new SaveContext(mockedContext.Object);

            //Act
            saveContext.Commit();

            //Assert
            mockedContext.Verify(mock => mock.SaveChanges(), Times.Once());
        }
    }
}
