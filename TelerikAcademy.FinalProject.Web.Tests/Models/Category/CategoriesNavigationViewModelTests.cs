using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Web.Models.Category;

namespace TelerikAcademy.FinalProject.Web.Tests.Models.Category
{
    [TestFixture]
    public class CategoriesNavigationViewModelTests
    {
        [Test]
        public void ConstructorShould_SetCorrectName_WhenCorrectCategoryModelIsPassed()
        {
            // Arrange
            TelerikAcademy.FinalProject.Data.Model.Category categoryModel = new TelerikAcademy.FinalProject.Data.Model.Category();

            //Act
            categoryModel.Name = "Test";
            CategoriesNavigationViewModel viewModel = new CategoriesNavigationViewModel(categoryModel);

            //Assert
            Assert.AreEqual(viewModel.Name, categoryModel.Name);
        }
    }
}
