using Bytes2you.Validation;
using System;
using System.Linq;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;
using TelerikAcademy.FinalProject.Services.Contracts;

namespace TelerikAcademy.FinalProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ISaveContext context;
        private readonly IEfRepository<Category> categoriesRepo;

        public CategoryService(IEfRepository<Category> categoriesRepo, ISaveContext context)
        {
            Guard.WhenArgument(categoriesRepo, "productsRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.categoriesRepo = categoriesRepo;
            this.context = context;
        }

        public IQueryable<Category> GetAllCategoriesSortedByName()
        {
           var result = this.categoriesRepo.All
                                .OrderBy(x => x.Name);
            return result;
         
        }

        public Category GetById(Guid? id)
        {
            Category result = null;
            if (id.HasValue)
            {
                Category product = this.categoriesRepo.All
                    .Where(x => x.Id == id.Value)
                    .SingleOrDefault();

                if (product != null)
                {
                    result = product;
                }
            }

            return result;
        }

        public void AddCategory(Category category)
        {
            this.categoriesRepo.Add(category);
            this.context.Commit();
        }
    }
}
