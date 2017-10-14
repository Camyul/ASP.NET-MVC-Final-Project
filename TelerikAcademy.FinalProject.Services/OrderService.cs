using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;
using TelerikAcademy.FinalProject.Services.Contracts;

namespace TelerikAcademy.FinalProject.Services
{
    public class OrderService : IOrderService
    {
        private readonly ISaveContext context;
        private readonly IEfRepository<Order> ordersRepo;

        public OrderService(IEfRepository<Order> ordersRepo, ISaveContext context)
        {
            Guard.WhenArgument(ordersRepo, "ordersRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.ordersRepo = ordersRepo;
            this.context = context;
        }

        public Guid Create(Order order)
        {
            this.ordersRepo.Add(order);
            this.context.Commit();
            return order.Id.Value;
        }

        public Guid Delete(Guid? id)
        {
            Guard.WhenArgument(id, nameof(id)).IsNull().Throw();

            var entity = this.GetById(id);
            entity.IsDeleted = true;
            this.ordersRepo.Update(entity);
            this.context.Commit();
            return id.Value;
        }

        public IEnumerable<Order> GetAll()
        {
            return this.ordersRepo
                .All
                .Where(c => c.IsDeleted == false)
                .ToList();
        }

        public Order GetById(Guid? id)
        {
            return id.HasValue ? this.ordersRepo.GetById(id) : null;
        }

        public Guid Update(Order order)
        {
            Order orderToUpdate = this.ordersRepo.GetById(order.Id.Value);
            this.ordersRepo.Update(orderToUpdate);

            this.context.Commit();

            return order.Id.Value;
        }
    }
}
