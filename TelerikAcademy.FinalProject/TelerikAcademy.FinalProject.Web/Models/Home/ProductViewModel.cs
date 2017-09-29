using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikAcademy.FinalProject.Web.Models.Home
{
    public class ProductViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string PictureUrl { get; set; }

        public decimal Price { get; set; }
    }
}