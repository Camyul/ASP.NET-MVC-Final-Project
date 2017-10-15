using Moq;
using NUnit.Framework;
using System;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;

namespace TelerikAcademy.FinalProject.Web.Tests.Services.CategoryService
{
    [TestFixture]
    public class CategoryService_Tests
    {
        [Test]
        public void GetAllCategoriesSortedByName_Should_CallRepository_All()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Category>>();
            var SaveContextStub = new Mock<ISaveContext>();
            var categoryServiceMock = new TelerikAcademy.FinalProject.Services.CategoryService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            categoryServiceMock.GetAllCategoriesSortedByName();

            // Assert
            EfRepositoryStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetById_ShouldReturnsNullWhenCategoryIdNotValid()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Category>>();
            var SaveContextStub = new Mock<ISaveContext>();
            Guid? categoryId = Guid.NewGuid();


            var categoryService = new TelerikAcademy.FinalProject.Services.CategoryService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            Category categoryModel = categoryService.GetById(categoryId.Value);

            // Assert
            Assert.IsNull(categoryModel);
        }

        [Test]
        public void GetById_ShouldReturnsNullWhenCategoryIdIsNull()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Category>>();
            var SaveContextStub = new Mock<ISaveContext>();


            var categoryService = new TelerikAcademy.FinalProject.Services.CategoryService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            Category categoryModel = categoryService.GetById(null);

            // Assert
            Assert.IsNull(categoryModel);
        }
    }
}
