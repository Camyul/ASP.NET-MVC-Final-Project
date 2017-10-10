using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;

namespace TelerikAcademy.FinalProject.Web.Tests.Services.CategoryService
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ConstructorShould_CreateCategoryService()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Category>>();
            var SaveContextStub = new Mock<ISaveContext>();

            // Act
            var categoryServiceMock = new TelerikAcademy.FinalProject.Services.CategoryService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Assert
            Assert.IsNotNull(categoryServiceMock);
        }

        [Test]
        public void ThrowException_WhenEfRepositoryIsNull()
        {
            // Arrange
            var SaveContextStub = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TelerikAcademy.FinalProject.Services.CategoryService(null, SaveContextStub.Object));
        }

        [Test]
        public void ThrowException_WhenSaveContextIsNull()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Category>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TelerikAcademy.FinalProject.Services.CategoryService(EfRepositoryStub.Object, null));
        }
    }
}
