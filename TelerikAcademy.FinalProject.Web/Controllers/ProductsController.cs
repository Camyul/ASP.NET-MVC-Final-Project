﻿using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.Models.Home;

namespace TelerikAcademy.FinalProject.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            Guard.WhenArgument(productsService, "productsService").IsNull().Throw();

            this.productsService = productsService;
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
                    PictureUrl = x.PictureUrl,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                })
                .ToList();

            return View(products);
        }

        //[HttpGet]
        //public ActionResult Search()
        //{
        //    return this.View(new List<ProductViewModel>());
        //}
        //[HttpPost]
        //public ActionResult Search(string searchName)
        //{
        //    var products = this.productsService
        //        .GetAll()
        //        .OrderByDescending(x => x.CreatedOn)
        //        .Select(x => new ProductViewModel()
        //        {
        //            PictureUrl = x.PictureUrl,
        //            Name = x.Name,
        //            Description = x.Description,
        //            Price = x.Price
        //        })
        //        .Where(x => x.Name.ToLower().Contains(searchName.ToLower()))
        //        .ToList();

        //    return View(products);
        //}
    }
}