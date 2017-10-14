using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Web.Areas.Administration.Models.ShoppingCart;
using TelerikAcademy.FinalProject.Services.Contracts;
using TelerikAcademy.FinalProject.Web.Contracts;
using Bytes2you.Validation;
using TelerikAcademy.FinalProject.Web.Models.Home;
using TelerikAcademy.FinalProject.Web.Models.ShoppingCart;

namespace TelerikAcademy.FinalProject.Web.Areas.Administration.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IProductsService productService;
        private IOrderService orderService;
        private IOrderDetailsService orderDetailsService;
        private IContactInfoService contactInfoService;
        private IUserService userService;

        public ShoppingCartController(
            IProductsService productService,
            IOrderService orderService,
            IOrderDetailsService orderDetailsService,
            IContactInfoService contactInfoService,
            IUserService userService)
        {
            Guard.WhenArgument(productService, "productService").IsNull().Throw();
            Guard.WhenArgument(orderService, "orderService").IsNull().Throw();
            Guard.WhenArgument(orderDetailsService, "orderDetailsService").IsNull().Throw();
            Guard.WhenArgument(contactInfoService, "contactInfoService").IsNull().Throw();
            Guard.WhenArgument(userService, nameof(userService)).IsNull().Throw();

            this.productService = productService;
            this.orderService = orderService;
            this.orderDetailsService = orderDetailsService;
            this.contactInfoService = contactInfoService;
            this.userService = userService;
        }

        public List<OrderDetailViewModel> CartItems { get; set; }

        [HttpGet]
        public ActionResult MyCart()
        {
            if (Session["cart"] == null)
            {
                ViewBag.Count = 0;
                return View("EmptyCart");
            }
            else
            {
                this.CartItems = (List<OrderDetailViewModel>)Session["cart"];
                ViewBag.Count = CartItems.Count;
                return View("MyCart", Session["cart"]);
            }
        }

        [HttpPost]
        public ActionResult OrderNow(Guid? id)
        {
            var productToAdd = new ProductViewModel(this.productService.GetById(id));

            var productQuantity = int.Parse(this.Request.Params["Quantity"]);

            if (Session["cart"] == null)
            {
                this.CartItems = new List<OrderDetailViewModel>();
            }
            else
            {
                this.CartItems = (List<OrderDetailViewModel>)Session["cart"];
            }

            CartItems.Add(new OrderDetailViewModel(productToAdd, productQuantity));
            Session["cart"] = CartItems;

            return RedirectToAction("MyCart");
        }

        public ActionResult Delete(int index)
        {
            this.CartItems = (List<OrderDetailViewModel>)Session["cart"];
            this.CartItems.RemoveAt(index);

            if (this.CartItems.Count > 0)
            {
                Session["cart"] = this.CartItems;
            }
            else
            {
                Session["cart"] = null;
            }

            return RedirectToAction("MyCart");
        }

        [HttpGet]
        [Authorize]
        public ActionResult CheckOut()
        {
            this.CartItems = (List<OrderDetailViewModel>)Session["cart"];

            var userId = User.Identity.GetUserId();
            var currentUser = this.userService.FindById(userId);
            var userShippingInfo = currentUser.ContactInfos.FirstOrDefault();

            if (userShippingInfo == null)
            {
                var shippingInfo = new ContactInfoViewModel();
                shippingInfo.OrderDetails = this.CartItems;
                return View("CheckOut");
            }
            else
            {
                var shippingInfo = new ContactInfoViewModel(userShippingInfo);
                shippingInfo.OrderDetails = this.CartItems;
                return View("CheckOut");
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(ContactInfoViewModel newOrder)
        {
            this.CartItems = (List<OrderDetailViewModel>)Session["cart"];
            var userId = User.Identity.GetUserId();
            var currentUser = this.userService.FindById(userId.ToString());

            if (this.ModelState.IsValid)
            {
                // Get or safe user info
                ContactInfo userShippingInfo = currentUser.ContactInfos.FirstOrDefault();

                if (userShippingInfo == null)
                {
                    userShippingInfo = new ContactInfo();

                    userShippingInfo.FirstName = newOrder.FirstName;
                    userShippingInfo.LastName = newOrder.LastName;
                    userShippingInfo.PhoneNumber = newOrder.PhoneNumber;
                    userShippingInfo.AddressLine = newOrder.AddressLine;
                    userShippingInfo.City = newOrder.City;
                    userShippingInfo.Area = newOrder.Area;
                    userShippingInfo.PostCode = newOrder.PostCode;
                    userShippingInfo.Customer = currentUser;
                    userShippingInfo.CustomerID = userId;
                    Guid? conactInfoId = Guid.NewGuid(); //this.contactInfoService.Create(userShippingInfo);
                    currentUser.ContactInfos.Add(userShippingInfo);
                }

                // save Order
                Order order = new Order();
                order.OrderDate = DateTime.Now;
                order.IsDeleted = false;
                order.HasBeenConfirmed = false;
                order.HasBeenShipped = false;
                order.HasBeenClosed = false;
                order.UserId = userId;
                Guid? orderId = this.orderService.Create(order);

                // save order details
                foreach (var item in this.CartItems)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.ProductId = item.Product.Id;
                    orderDetail.IsDeleted = false;
                    orderDetail.OrderId = orderId.Value;
                    orderDetail.Quantity = item.Quantity;
                    orderDetail.IsDeleted = false;
                    orderDetail.UnitPrice = (decimal)item.Product.Price;
                    orderDetail.SubTotal = orderDetail.UnitPrice * orderDetail.Quantity;
                    orderDetail.OrderedDate = DateTime.Now;

                    order.TotalAmount += orderDetail.SubTotal;
                    Guid? orderDetailsId = this.orderDetailsService.Create(orderDetail);
                }

                this.orderService.Update(order);
                //currentUser.Orders.Add(order);
                //this.userService.Update(currentUser);
                Session["cart"] = null;

                return View("Thanks");
            }
            else
            {
                return View();
            }
        }
    }
}