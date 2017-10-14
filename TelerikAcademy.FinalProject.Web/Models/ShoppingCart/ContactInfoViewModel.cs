using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TelerikAcademy.FinalProject.Common.Constant;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Web.Areas.Administration.Models.ShoppingCart;

namespace TelerikAcademy.FinalProject.Web.Models.ShoppingCart
{
    public class ContactInfoViewModel
    {

        public ContactInfoViewModel()
        {
        }

        public ContactInfoViewModel(ContactInfo contactInfo)
        {
            this.Id = contactInfo.Id;
            this.FirstName = contactInfo.FirstName;
            this.LastName = contactInfo.LastName;
            this.PhoneNumber = contactInfo.PhoneNumber;
            this.AddressLine = contactInfo.AddressLine;
            this.City = contactInfo.City;
            this.Area = contactInfo.Area;
            this.PostCode = contactInfo.PostCode;
            this.OrderDetails = new List<OrderDetailViewModel>();
        }

        public Guid? Id { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        [MinLength(ValidationConstants.StandardMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.StandartMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        [RegularExpression(ValidationConstants.EnBgSpaceMinus, ErrorMessage = ValidationConstants.NotAllowedSymbolsErrorMessage)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        [MinLength(ValidationConstants.StandardMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.StandartMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        [RegularExpression(ValidationConstants.EnBgSpaceMinus)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [RegularExpression(ValidationConstants.PhoneRegex)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        [MinLength(ValidationConstants.AddressMinLength)]
        [MaxLength(ValidationConstants.AddressMaxLength)]
        [RegularExpression(ValidationConstants.EnBgSpaceMinus)]
        public string AddressLine { get; set; }

        [Required]
        [Display(Name = "City")]
        [MinLength(ValidationConstants.StandardMinLength)]
        [MaxLength(ValidationConstants.StandartMaxLength)]
        [RegularExpression(ValidationConstants.EnBgSpaceMinus)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Area")]
        [MinLength(ValidationConstants.StandardMinLength)]
        [MaxLength(ValidationConstants.StandartMaxLength)]
        [RegularExpression(ValidationConstants.EnBgSpaceMinusDot)]
        public string Area { get; set; }

        [Required]
        [Display(Name = "PostCode")]
        public string PostCode { get; set; }

        public IList<OrderDetailViewModel> OrderDetails { get; set; }
    }
}