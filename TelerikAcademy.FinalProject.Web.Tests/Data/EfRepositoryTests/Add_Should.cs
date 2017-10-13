using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;
using TelerikAcademy.FinalProject.Data;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;

namespace TelerikAcademy.FinalProject.Web.Tests.Data.EfRepository
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenArgumentIsNull()
        {
            //Arrange
            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedModel = new Mock<DbSet<Category>>();
            var mockedCategory = new Mock<Category>();

            //Act
            mockedDbContext.Setup(x => x.Set<Category>()).Returns(mockedModel.Object);
            var mockedDbSet = new EfRepository<Category>(mockedDbContext.Object);
            Category entity = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => mockedDbSet.Add(entity));
        }
    }
}
