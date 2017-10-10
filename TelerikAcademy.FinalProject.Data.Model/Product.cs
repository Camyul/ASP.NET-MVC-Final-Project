using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelerikAcademy.FinalProject.Common.Constant;
using TelerikAcademy.FinalProject.Data.Model.Abstracts;

namespace TelerikAcademy.FinalProject.Data.Model
{
    public class Product : DataModel
    {
        //public Product()
        //{
           
        //}

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.StandardMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.StandartMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        [RegularExpression(ValidationConstants.EnBgDigitSpaceMinus, ErrorMessage = ValidationConstants.NotAllowedSymbolsErrorMessage)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [MinLength(ValidationConstants.DescriptionMinLength, ErrorMessage = ValidationConstants.MinLengthDescriptionErrorMessage)]
        [MaxLength(ValidationConstants.DescriptionMaxLength, ErrorMessage = ValidationConstants.MaxLengthDescriptionErrorMessage)]
        [RegularExpression(ValidationConstants.DescriptionRegex, ErrorMessage = ValidationConstants.NotAllowedSymbolsErrorMessage)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        [MinLength(ValidationConstants.DescriptionMinLength, ErrorMessage = ValidationConstants.MinLengthDescriptionErrorMessage)]
        [MaxLength(ValidationConstants.LongDescriptionMaxLength, ErrorMessage = ValidationConstants.MaxLengthLongDescriptionErrorMessage)]
        [RegularExpression(ValidationConstants.DescriptionRegex, ErrorMessage = ValidationConstants.NotAllowedSymbolsErrorMessage)]
        public string LongDescription { get; set; }

        [Required]
        [Range(
            ValidationConstants.QuantityMinValue,
            ValidationConstants.QuantityMaxValue,
            ErrorMessage = ValidationConstants.QuаntityOutOfRangeErrorMessage)]
        public int Quantity { get; set; }
        
        [ForeignKey("Category")]
        public Guid? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [MinLength(ValidationConstants.ImageUrlMinLength, ErrorMessage = ValidationConstants.MinLengthUrlErrorMessage)]
        [MaxLength(ValidationConstants.ImageUrlMaxLength, ErrorMessage = ValidationConstants.MaxLengthUrlErrorMessage)]
        public string PictureUrl { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
