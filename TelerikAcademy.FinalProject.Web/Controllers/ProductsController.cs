using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.Infrastructure;
using TelerikAcademy.FinalProject.Web.Models.Category;
using TelerikAcademy.FinalProject.Web.Models.Home;

namespace TelerikAcademy.FinalProject.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly ICategoryService categiryService;

        public ProductsController(IProductsService productsService, ICategoryService categiryService)
        {
            Guard.WhenArgument(productsService, "productsService").IsNull().Throw();
            Guard.WhenArgument(categiryService, "categiryService").IsNull().Throw();

            this.productsService = productsService;
            this.categiryService = categiryService;
        }

        // GET: Products
        [HttpGet]
        public ActionResult Index()
        {
            // Without AutoMapper
            var products = this.productsService
                .GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    PictureUrl = x.PictureUrl,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                })
                .ToList();

            var categories = this.categiryService.GetAllCategoriesSortedByName()
                // .Select(x => new CategoriesNavigationViewModel(x))
                .ToList();
            var viewCategory = new List<CategoriesNavigationViewModel>();
            foreach (var cat in categories)
            {
                viewCategory.Add(new CategoriesNavigationViewModel(cat));
            }
           
            ViewData["categories"] = viewCategory;
            ViewData["products"] = products;

            return View();
        }

        public ActionResult Details(Guid? id)
        {
            Product product = this.productsService.GetById(id);

            ProductViewModel viewModel = new ProductViewModel(product);

            return this.View(viewModel);
        }

        public ActionResult ProductsByCategory(Guid? id)
        {
            Guard.WhenArgument(id, "Category Id").IsNull().Throw();
            
            var products = this.productsService
                            .GetByCategory(id)
                            .ToList();

            var categories = this.categiryService.GetAllCategoriesSortedByName()
                .ToList();

            var viewCategory = new List<CategoriesNavigationViewModel>();
            foreach (var cat in categories)
            {
                viewCategory.Add(new CategoriesNavigationViewModel(cat));
            }

            var viewProducts = new List<ProductViewModel>();
            foreach (var product in products)
            {
                viewProducts.Add(new ProductViewModel(product));
            }

            ViewData["categories"] = viewCategory;
            ViewData["products"] = viewProducts;

            return View("Index");
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddProduct()
        {
            var product = new ProductViewModel();

            var categories = this.categiryService.GetAllCategoriesSortedByName()
               // .Select(x => new CategoriesNavigationViewModel(x))
               .ToList();

            var viewCategory = new List<CategoriesNavigationViewModel>();

            foreach (var cat in categories)
            {
                viewCategory.Add(new CategoriesNavigationViewModel(cat));
            }

            ViewData["categories"] = viewCategory;
            ViewData["product"] = product;

            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(ProductViewModel productModel)
        {
            Product product = new Product()
            {
                PictureUrl = productModel.PictureUrl,
                Name = productModel.Name,
                Description = productModel.Description,
                LongDescription = productModel.LongDescription,
                CategoryId = productModel.Category,
                Price = productModel.Price,
                Quantity = productModel.Quantity
            };

            this.productsService.AddProduct(product);

            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult FilteredProducts(string searchName)
        {

            if (string.IsNullOrEmpty(searchName))
            {
                return this.Index();
            }
            else
            {
                var filteredProducts = this.productsService.GetByName(searchName).ToList();

                var viewProducts = new List<ProductViewModel>();
                foreach (var product in filteredProducts)
                {

                    viewProducts.Add(new ProductViewModel(product));
                }

                return this.PartialView("_FilteredProductsPartial", viewProducts);
            }
        }
    }
}