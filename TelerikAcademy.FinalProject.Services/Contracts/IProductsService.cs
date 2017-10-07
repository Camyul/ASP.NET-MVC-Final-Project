using System.Linq;
using TelerikAcademy.FinalProject.Data.Model;

namespace TelerikAcademy.FinalProject.Services.Contracts
{
    public interface IProductsService
    {
        IQueryable<Product> GetAll();

        void Update(Product product);
    }
}