using System.Linq;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Services.Contracts;

namespace TelerikAcademy.FinalProject.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IEfRepository<Product> productsRepo;

        public ProductsService(IEfRepository<Product> productsRepo)
        {
            this.productsRepo = productsRepo;
        }

        public IQueryable<Product> GetAll()
        {
            return this.productsRepo.All;
        }
    }
}
