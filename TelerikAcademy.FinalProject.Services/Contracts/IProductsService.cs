using System;
using System.Linq;
using TelerikAcademy.FinalProject.Data.Model;

namespace TelerikAcademy.FinalProject.Services.Contracts
{
    public interface IProductsService
    {
        IQueryable<Product> GetAll();

        Product GetById(Guid? id);

        void AddProduct(Product product);

        void Update(Product product);
    }
}