using System;
using System.Collections.Generic;
using TelerikAcademy.FinalProject.Data.Model;

namespace TelerikAcademy.FinalProject.Services.Contracts
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();

        Order GetById(Guid? id);

        Guid Update(Order order);

        Guid Delete(Guid? id);

        Guid Create(Order order);
    }
}
