using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;
using TelerikAcademy.FinalProject.Services;

namespace TelerikAcademy.FinalProject.Web.Tests.Services.OrderServiceTests
{
    class OrderService_Tests
    {
        [Test]
        public void GetAll_Should_CallRepository_All()
        {

            // Arrange
            var EfRepositoryMock = new Mock<IEfRepository<Order>>();
            var SaveContextStub = new Mock<ISaveContext>();
            var orderService = new OrderService(EfRepositoryMock.Object, SaveContextStub.Object);

            // Act
            orderService.GetAll();

            // Assert
            EfRepositoryMock.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetById_ShouldReturnsNullWhenOrderIdNotValid()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Order>>();
            var SaveContextStub = new Mock<ISaveContext>();
            Guid? orderId = Guid.NewGuid();


            var orderService = new OrderService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            Order orderModel = orderService.GetById(orderId.Value);

            // Assert
            Assert.IsNull(orderModel);
        }

        [Test]
        public void GetById_ShouldReturnsNullWhenOrderIdIsNull()
        {
            //Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Order>>();
            var SaveContextStub = new Mock<ISaveContext>();


            var orderService = new OrderService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            Order orderModel = orderService.GetById(null);

            // Assert
            Assert.IsNull(orderModel);
        }

        [Test]
        public void Create_Should_CallContextCommit()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Order>>();
            var SaveContextMock = new Mock<ISaveContext>();
            var orederService = new OrderService(EfRepositoryStub.Object, SaveContextMock.Object);
            Order order = new Order();

            // Act
            orederService.Create(order);

            // Assert
            SaveContextMock.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Update_Should_CallContextCommit()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Order>>();
            var SaveContextMock = new Mock<ISaveContext>();
            var orederService = new OrderService(EfRepositoryStub.Object, SaveContextMock.Object);
            Order order = new Order();

            // Act
            orederService.Update(order);

            // Assert
            SaveContextMock.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Delete_Should_CallContextCommit()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<Order>>();
            var SaveContextMock = new Mock<ISaveContext>();
            var orederService = new OrderService(EfRepositoryStub.Object, SaveContextMock.Object);
            Guid guid = Guid.NewGuid();
            Order order = new Order(){ Id = guid };

            EfRepositoryStub.Setup(x => x.GetById(order.Id.Value)).Returns(order);

            // Act
            orederService.Delete(order.Id.Value);

            // Assert
            SaveContextMock.Verify(x => x.Commit(), Times.Once);
        }
    }
}
