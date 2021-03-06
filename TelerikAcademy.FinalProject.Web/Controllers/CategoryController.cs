﻿using Bytes2you.Validation;
using System.Linq;
using System.Web.Mvc;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.Models.Category;

namespace TelerikAcademy.FinalProject.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            Guard.WhenArgument(categoryService, "categoryService").IsNull().Throw();

            this.categoryService = categoryService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddCategory()
        {
            var category = new CategoryViewModel();

            return View(category);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(CategoryViewModel categoryModel)
        {
            Category category = new Category()
            {
                Name = categoryModel.Name,
                Products = categoryModel.Products
            };

            this.categoryService.AddCategory(category);

            return RedirectToAction("Index", "Products");
        }

        [ChildActionOnly]
        public ActionResult CategoriesNavigation()
        {
            var navigationCategories = this.categoryService.GetAllCategoriesSortedByName()
                       .Select(c => new CategoriesNavigationViewModel(c)).ToList();

            return PartialView("_CategoriesPartial", navigationCategories);
        }
    }
}