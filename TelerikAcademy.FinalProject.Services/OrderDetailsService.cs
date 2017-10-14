using Bytes2you.Validation;
using System;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;
using TelerikAcademy.FinalProject.Services.Contracts;

namespace TelerikAcademy.FinalProject.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly ISaveContext context;
        private readonly IEfRepository<OrderDetail> ordersDetailsRepo;

        public OrderDetailsService(IEfRepository<OrderDetail> ordersDetailsRepo, ISaveContext context)
        {
            Guard.WhenArgument(ordersDetailsRepo, "ordersDetailsRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.ordersDetailsRepo = ordersDetailsRepo;
            this.context = context;
        }

        public Guid Create(OrderDetail orderDetails)
        {
            this.ordersDetailsRepo.Add(orderDetails);
            this.context.Commit();
            return orderDetails.Id.Value;
        }

        public OrderDetail GetById(Guid? id)
        {
            return id.HasValue ? this.ordersDetailsRepo.GetById(id.Value) : null;
        }

        //public int Delete(int? id)
        //{
        //    Guard.WhenArgument(id, nameof(id)).IsNull().Throw();

        //    var entity = this.GetById(id);
        //    entity.IsDeleted = true;
        //    this.orderDetailsSetWrapper.Update(entity);
        //    return this.dbContext.SaveChanges();
        //}

        //public IEnumerable<OrderDetail> GetAll()
        //{
        //    return this.orderDetailsSetWrapper
        //         .All()
        //         .Where(c => c.IsDeleted == false)
        //         .ToList();
        //}

        public Guid Update(OrderDetail orderDetails)
        {
            OrderDetail orderToUpdate = this.ordersDetailsRepo.GetById(orderDetails.Id.Value);
            this.ordersDetailsRepo.Update(orderToUpdate);
            this.context.Commit();

            return orderDetails.Id.Value;
        }
    }
}
