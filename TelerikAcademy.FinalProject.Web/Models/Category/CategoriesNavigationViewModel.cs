using System;
using System.Web.Mvc;

namespace TelerikAcademy.FinalProject.Web.Models.Category
{
    public class CategoriesNavigationViewModel
    {
        public CategoriesNavigationViewModel()
        {
        }

        public CategoriesNavigationViewModel(TelerikAcademy.FinalProject.Data.Model.Category category)
        {
            if (category != null)
            {
                this.Id = category.Id;
                this.Name = category.Name;
            }
        }

        [HiddenInput]
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}