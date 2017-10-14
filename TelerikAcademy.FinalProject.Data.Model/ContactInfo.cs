using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Common.Constant;
using TelerikAcademy.FinalProject.Data.Model.Abstracts;

namespace TelerikAcademy.FinalProject.Data.Model
{
    public class ContactInfo : DataModel
    {
        public ContactInfo()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid? Id { get; set; }

        [ForeignKey("Customer")]
        public string CustomerID { get; set; }

        public virtual User Customer { get; set; }

        [Required]
        [MinLength(ValidationConstants.StandardMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.StandartMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        [RegularExpression(ValidationConstants.EnBgSpaceMinus, ErrorMessage = ValidationConstants.NotAllowedSymbolsErrorMessage)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ValidationConstants.StandardMinLength, ErrorMessage = ValidationConstants.MinLengthFieldErrorMessage)]
        [MaxLength(ValidationConstants.StandartMaxLength, ErrorMessage = ValidationConstants.MaxLengthFieldErrorMessage)]
        [RegularExpression(ValidationConstants.EnBgSpaceMinus)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.PhoneRegex)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(ValidationConstants.AddressMinLength)]
        [MaxLength(ValidationConstants.AddressMaxLength)]
        [RegularExpression(ValidationConstants.EnBgSpaceMinus)]
        public string AddressLine { get; set; }

        [Required]
        [MinLength(ValidationConstants.StandardMinLength)]
        [MaxLength(ValidationConstants.StandartMaxLength)]
        [RegularExpression(ValidationConstants.EnBgSpaceMinus)]
        public string City { get; set; }

        [Required]
        [MinLength(ValidationConstants.StandardMinLength)]
        [MaxLength(ValidationConstants.StandartMaxLength)]
        [RegularExpression(ValidationConstants.EnBgSpaceMinusDot)]
        public string Area { get; set; }

        [Required]
        public string PostCode { get; set; }
    }
}
