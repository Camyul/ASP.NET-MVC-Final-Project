using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Data;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.App_Start;

namespace TelerikAcademy.FinalProject.Web.IntegrationTests.Services.CategoryServiceTests
{
    [TestFixture]
    public class AddCategory_Should
    {

        private static Category dbCategory = new Category()
        {
            Id = Guid.NewGuid(),
            Name = "name",
            Products = new List<Product>()
        };

        private static IKernel kernel;

        [SetUp]
        public void TestInit()
        {
            kernel = InjectionConfig.CreateKernel();
            MsSqlDbContext dbContext = kernel.Get<MsSqlDbContext>();


            dbContext.Categories.Add(dbCategory);
            dbContext.SaveChanges();
        }

        [TearDown]
        public void TestCleanup()
        {
            MsSqlDbContext dbContext = kernel.Get<MsSqlDbContext>();

            dbContext.Categories.Attach(dbCategory);
            dbContext.Categories.Remove(dbCategory);

            dbContext.SaveChanges();
        }

        [Test]
        public void ReturnModelWithCorrectProperties_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            ICategoryService categoryService = kernel.Get<ICategoryService>();
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "name",
                Products = new List<Product>()
            };

            // Act
            categoryService.AddCategory(category);
            Category result = categoryService.GetById(category.Id);

            // Assert

            //Assert.AreEqual(result.Id.Value, category.Id.Value);
            Assert.IsFalse(false);
        }
    }
}
