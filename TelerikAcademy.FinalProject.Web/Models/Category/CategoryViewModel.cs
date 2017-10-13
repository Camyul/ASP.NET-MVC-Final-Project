using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TelerikAcademy.FinalProject.Common.Constant;
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

        [Required]
        [MinLength(ValidationConstants.StandardMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.StandartMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        [RegularExpression(ValidationConstants.EnBgDigitSpaceMinus, ErrorMessage = ValidationConstants.NotAllowedSymbolsErrorMessage)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}