using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Web.Infrastructure;

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
            this.Category = product.Category;
            this.Quantity = product.Quantity;
            this.PictureUrl = product.PictureUrl;
            this.Price = product.Price;
        }

        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string LongDescription { get; set; }
        public TelerikAcademy.FinalProject.Data.Model.Category Category { get; set; }

        public int Quantity { get; set; }

        public string PictureUrl { get; set; }

        public decimal Price { get; set; }

        //public void CreateMappings(IMapperConfigurationExpression configuration)
        //{
        //    configuration.CreateMap<Product, ProductViewModel>()
        //        .ForMember(productViewModel => productViewModel.Name, cfg => cfg.MapFrom(product => product.Name))
        //        .ForMember(productViewModel => productViewModel.Description, cfg => cfg.MapFrom(product => product.Description));
        //}
    }
}