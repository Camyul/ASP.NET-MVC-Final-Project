using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Data.Model.Abstracts;

namespace TelerikAcademy.FinalProject.Data.Model
{
    public class Order : DataModel
    {
        private IEnumerable<OrderDetail> orderDetails;

        public Order()
        {
            this.orderDetails = new HashSet<OrderDetail>();
        }

        public DateTime OrderDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public decimal TotalAmount { get; set; }

        //public bool HasBeenConfirmed { get; set; }

        //public bool HasBeenShipped { get; set; }

        //public bool HasBeenClosed { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
        
    }
}
