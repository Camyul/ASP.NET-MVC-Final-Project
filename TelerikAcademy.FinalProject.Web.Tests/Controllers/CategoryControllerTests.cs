﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.Controllers;
using TelerikAcademy.FinalProject.Web.Models.Category;

namespace TelerikAcademy.FinalProject.Web.Tests.Controllers
{
    [TestFixture]
    public class CategoryControllerTests
    {
        [Test]
        public void ConstructorShould_ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var categoryServiceMock = new Mock<ICategoryService>();

            // Act
            CategoryController categoryController = new CategoryController(categoryServiceMock.Object);

            // Assert
            Assert.IsNotNull(categoryController);
        }

        [Test]
        public void ConstructorShould_ThrowException_WhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CategoryController(null));
        }

        [Test]
        public void AddProductShould_InvocedAddCategory()
        {
            //Arrange
            var categoryServiceMock = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(categoryServiceMock.Object);
            Category category = new Category();
            CategoryViewModel viewModel = new CategoryViewModel(category);

            // Act
            controller.AddCategory(viewModel);

            // Assert
            categoryServiceMock.Setup(p => p.AddCategory(category)).Verifiable();
        }

        [Test]
        public void AddCategoryShould_ReturnsView()
        {
            //Arrange
            var categoryServiceMock = new Mock<ICategoryService>();
            CategoryController controller = new CategoryController(categoryServiceMock.Object);

            // Act
            ViewResult result = controller.AddCategory() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
