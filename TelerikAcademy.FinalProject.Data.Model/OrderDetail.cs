using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelerikAcademy.FinalProject.Common.Constant;
using TelerikAcademy.FinalProject.Data.Model.Abstracts;

namespace TelerikAcademy.FinalProject.Data.Model
{
    public class OrderDetail : DataModel
    {
        public OrderDetail()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid? Id { get; set; }

        [ForeignKey("Order")]
        public Guid? OrderId { get; set; }

        public virtual Order Order { get; set; }

        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        [Range(
           ValidationConstants.QuantityMinValue,
           ValidationConstants.QuantityMaxValue,
           ErrorMessage = ValidationConstants.QuаntityOutOfRangeErrorMessage)]
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SubTotal { get; set; }

        public DateTime OrderedDate { get; set; }
    }
}
