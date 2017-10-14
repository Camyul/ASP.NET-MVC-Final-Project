using TelerikAcademy.FinalProject.Web.Models.Home;

namespace TelerikAcademy.FinalProject.Web.Areas.Administration.Models.ShoppingCart
{
    public class OrderDetailViewModel
    {


        public OrderDetailViewModel()
        {
        }

        public OrderDetailViewModel(ProductViewModel product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        public ProductViewModel Product { get; private set; }

        public int Quantity { get; private set; }

    }
}