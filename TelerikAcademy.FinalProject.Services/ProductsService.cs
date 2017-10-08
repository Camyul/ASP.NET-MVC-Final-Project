using Bytes2you.Validation;
using System.Linq;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;
using TelerikAcademy.FinalProject.Services.Contracts;

namespace TelerikAcademy.FinalProject.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ISaveContext context;
        private readonly IEfRepository<Product> productsRepo;

        public ProductsService(IEfRepository<Product> productsRepo, ISaveContext context)
        {
            Guard.WhenArgument(productsRepo, "productsRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.productsRepo = productsRepo;
            this.context = context;
        }

        public IQueryable<Product> GetAll()
        {
            return this.productsRepo.All;
        }

        public void Update(Product product)
        {
            this.productsRepo.Update(product);
            this.context.Commit();
        }
    }
}
