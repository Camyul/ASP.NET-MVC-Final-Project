using Bytes2you.Validation;
using System;
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

        public IQueryable<Product> GetByCategory(Guid? id)
        {
            return this.productsRepo.All
                        .Where(c => c.CategoryId == id)
                        .OrderBy(c => c.Name);
        }

        public Product GetById(Guid? id)
        {
            Product result = null;
            if (id.HasValue)
            {
                Product product = this.productsRepo.All
                    .Where(x => x.Id == id.Value)
                    .SingleOrDefault();

                if (product != null)
                {
                    result = product;
                }
            }

            return result;
        }

        public void AddProduct(Product product)
        {
            this.productsRepo.Add(product);
            this.context.Commit();
        }

        public void Update(Product product)
        {
            this.productsRepo.Update(product);
            this.context.Commit();
        }
    }
}
