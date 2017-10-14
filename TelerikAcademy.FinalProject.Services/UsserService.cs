using Bytes2you.Validation;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;

namespace TelerikAcademy.FinalProject.Services
{
    public class UsserService
    {
        //private readonly ISaveContext context;
        //private readonly IEfRepository<User> usersRepo;

        //public UsserService(IEfRepository<User> usersRepo, ISaveContext context)
        //{
        //    Guard.WhenArgument(usersRepo, "usersRepo").IsNull().Throw();
        //    Guard.WhenArgument(context, "context").IsNull().Throw();

        //    this.usersRepo = usersRepo;
        //    this.context = context;
        //}

        //public IEnumerable<User> GetAll()
        //{
        //    return this.usersRepo
        //        .All
        //        .Where(c => c.IsDeleted == false)
        //        .ToList();
        //}


        //public void Update(User user)
        //{
        //    this.usersRepo.Update(user);
        //    this.context.Commit();
        //}

        //public User GetByUserName(string name)
        //{
        //    return this.userSetWrapper.GetByName(name);
        //}

        //public User GetById(string id)
        //{
        //    return this.usersRepo.GetById(id);
        //}
    }
}
