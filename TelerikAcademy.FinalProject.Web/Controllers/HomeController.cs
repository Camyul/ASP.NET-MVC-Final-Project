using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.Infrastructure;
using TelerikAcademy.FinalProject.Web.Models.Home;

namespace TelerikAcademy.FinalProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService productsService;
        // private readonly IMapper mapper;

        public HomeController(IProductsService productsService)// , IMapper mapper)
        {
            this.productsService = productsService;
            // this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            // Without AutoMapper
            if (this.HttpContext.Cache["products"] == null)
            {
                var cachedProducts = this.productsService
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
               .Take(8)
               .ToList();

                //this.HttpContext.Cache["products"] = cachedProducts;
                this.HttpContext.Cache.Insert(
                    "products",     //key
                    cachedProducts, //value to cache
                    null,           //dependecies
                    DateTime.Now.AddSeconds(60), //absolute exp.
                    TimeSpan.Zero  //sliding exp. 
                           // callback delegate
                    );
            }
            var products = this.HttpContext.Cache["products"];

            // With AutoMapper
            //var products = this.productsService
            //    .GetAll()
            //    .OrderByDescending(x => x.CreatedOn)
            //    .ProjectTo<ProductViewModel>()
            //    .Take(4)
            //    .ToList();

            return View(products);
        }

        //[HttpPost]
        //public ActionResult Index(ProductViewModel productViewModel)
        //{
        //    Product product = new Product()
        //    {
        //        PictureUrl = productViewModel.PictureUrl,
        //        Name = productViewModel.Name,
        //        Description = productViewModel.Description,
        //        Price = productViewModel.Price
        //    };

        //    this.productsService.Update(product);

        //    return this.RedirectToAction("Index");
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}