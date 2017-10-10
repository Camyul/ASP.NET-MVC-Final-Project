using System;
using System.Linq;
using TelerikAcademy.FinalProject.Data.Model;

namespace TelerikAcademy.FinalProject.Services.Contracts
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAllCategoriesSortedByName();

        Category GetById(Guid? id);

        void AddCategory(Category category);
    }
}