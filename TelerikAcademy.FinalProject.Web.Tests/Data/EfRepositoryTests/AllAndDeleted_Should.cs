using Moq;
using NUnit.Framework;
using System.Data.Entity;
using TelerikAcademy.FinalProject.Data;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;

namespace TelerikAcademy.FinalProject.Web.Tests.Data.EfRepository
{
    [TestFixture]
    public class AllAndDeleted_Should
    {
        [Test]
        public void ReturnValue_WhenCalled()
        {
            // Arrange
            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedModel = new Mock<DbSet<Category>>();

            mockedDbContext.Setup(x => x.Set<Category>()).Returns(mockedModel.Object);
            var mockedDbSet = new EfRepository<Category>(mockedDbContext.Object);

            // Act
            var result = mockedDbSet.AllAndDeleted;

            // Assert
            Assert.NotNull(result);
        }
    }
}
