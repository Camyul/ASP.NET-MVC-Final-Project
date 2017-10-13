using Moq;
using NUnit.Framework;
using System.Data.Entity;
using TelerikAcademy.FinalProject.Data;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;

namespace TelerikAcademy.FinalProject.Web.Tests.Data.EfRepository
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void WorkCorrectly_IfDbContextPassedIsValid()
        {
            // Arrange
            var mockedDbContext = new Mock<MsSqlDbContext>();

            // Act
            var mockedDbSet = new EfRepository<Category>(mockedDbContext.Object);

            // Assert
            Assert.That(mockedDbSet, Is.Not.Null);
        }
    }
}
