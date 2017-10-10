using System;
using System.Collections.Generic;
using TelerikAcademy.FinalProject.Data.Model;

namespace TelerikAcademy.FinalProject.Web.Models.Category
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {

        }

        public CategoryViewModel(TelerikAcademy.FinalProject.Data.Model.Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.Products = category.Products;
        }

        public Guid? Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}