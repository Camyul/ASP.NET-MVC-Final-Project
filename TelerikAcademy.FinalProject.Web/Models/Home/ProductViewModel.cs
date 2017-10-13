using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Web.Infrastructure;
using System.ComponentModel.DataAnnotations;
using TelerikAcademy.FinalProject.Common.Constant;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelerikAcademy.FinalProject.Web.Models.Home
{
    public class ProductViewModel //: IMapFrom<Product>, IHaveCustomMappings
    {
        public ProductViewModel()
        {

        }

        public ProductViewModel(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Description = product.Description;
            this.LongDescription = product.LongDescription;
            this.Category = product.Category.Id;
            this.Quantity = product.Quantity;
            this.PictureUrl = product.PictureUrl;
            this.Price = product.Price;
        }

        public Guid? Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.StandardMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.StandartMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        [RegularExpression(ValidationConstants.EnBgDigitSpaceMinus, ErrorMessage = ValidationConstants.NotAllowedSymbolsErrorMessage)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [MinLength(ValidationConstants.DescriptionMinLength, ErrorMessage = ValidationConstants.MinLengthDescriptionErrorMessage)]
        [MaxLength(ValidationConstants.DescriptionMaxLength, ErrorMessage = ValidationConstants.MaxLengthDescriptionErrorMessage)]
        [RegularExpression(ValidationConstants.DescriptionRegex, ErrorMessage = ValidationConstants.NotAllowedSymbolsErrorMessage)]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [MinLength(ValidationConstants.DescriptionMinLength, ErrorMessage = ValidationConstants.MinLengthDescriptionErrorMessage)]
        [MaxLength(ValidationConstants.LongDescriptionMaxLength, ErrorMessage = ValidationConstants.MaxLengthLongDescriptionErrorMessage)]
        [RegularExpression(ValidationConstants.DescriptionRegex, ErrorMessage = ValidationConstants.NotAllowedSymbolsErrorMessage)]
        public string LongDescription { get; set; }
        public Guid? Category { get; set; }
        //public TelerikAcademy.FinalProject.Data.Model.Category Category { get; set; }

        [Required]
        [Range(
                ValidationConstants.QuantityMinValue,
                   ValidationConstants.QuantityMaxValue,
                    ErrorMessage = ValidationConstants.QuаntityOutOfRangeErrorMessage)]
        public int Quantity { get; set; }

        [MinLength(ValidationConstants.ImageUrlMinLength, ErrorMessage = ValidationConstants.MinLengthUrlErrorMessage)]
        [MaxLength(ValidationConstants.ImageUrlMaxLength, ErrorMessage = ValidationConstants.MaxLengthUrlErrorMessage)]
        public string PictureUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        //public void CreateMappings(IMapperConfigurationExpression configuration)
        //{
        //    configuration.CreateMap<Product, ProductViewModel>()
        //        .ForMember(productViewModel => productViewModel.Name, cfg => cfg.MapFrom(product => product.Name))
        //        .ForMember(productViewModel => productViewModel.Description, cfg => cfg.MapFrom(product => product.Description));
        //}
    }
}