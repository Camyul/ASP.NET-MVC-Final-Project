using System;
using TelerikAcademy.FinalProject.Data.Model;

namespace TelerikAcademy.FinalProject.Services.Contracts
{
    public interface IOrderDetailsService
    {
        // IEnumerable<OrderDetail> GetAll();

        OrderDetail GetById(Guid? id);

        //int Update(OrderDetail orderDetails);

        //int Delete(int? id);

        Guid Create(OrderDetail orderDetail);

    }
}
