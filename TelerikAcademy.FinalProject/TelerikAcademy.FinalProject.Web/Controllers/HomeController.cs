using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.Models.Home;

namespace TelerikAcademy.FinalProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        public ActionResult Index()
        {
            var products = this.productsService
                .GetAll()
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new ProductViewModel()
                {
                    PictureUrl = x.PictureUrl,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                })
                .Take(8)
                .ToList();

            return View(products);
        }

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