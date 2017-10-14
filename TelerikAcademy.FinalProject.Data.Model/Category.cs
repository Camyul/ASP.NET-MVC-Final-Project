using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelerikAcademy.FinalProject.Common.Constant;
using TelerikAcademy.FinalProject.Data.Model.Abstracts;

namespace TelerikAcademy.FinalProject.Data.Model
{
    public class Category : DataModel
    {
        private ICollection<Product> products;
        //private ICollection<Category> subCategories;

        public Category()
        {
            this.Products = new HashSet<Product>();
            this.Id = Guid.NewGuid();
            //this.SubCategories = new HashSet<Category>();
        }

        [Key]
        public Guid? Id { get; set; }


        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.StandardMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.StandartMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        [RegularExpression(ValidationConstants.EnBgDigitSpaceMinus, ErrorMessage = ValidationConstants.NotAllowedSymbolsErrorMessage)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                this.products = value;
            }
        }

            //public virtual ICollection<Category> SubCategories
            //{
            //    get
            //    {
            //        return this.subCategories;
            //    }

            //    set
            //    {
            //        this.subCategories = value;
            //    }
            //}
        }
}
