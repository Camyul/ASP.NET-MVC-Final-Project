using Moq;
using NUnit.Framework;
using System;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;
using TelerikAcademy.FinalProject.Services;

namespace TelerikAcademy.FinalProject.Web.Tests.Services.OrderDetailsServiceTests
{
    [TestFixture]
    public class OrderDetailsService_Tests
    {
        [Test]
        public void GetById_ShouldReturnsNullWhenOrderDetailIdNotValid()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<OrderDetail>>();
            var SaveContextStub = new Mock<ISaveContext>();
            Guid? orderDetailId = Guid.NewGuid();


            var orderDetailsService = new OrderDetailsService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            OrderDetail orderDetailsModel = orderDetailsService.GetById(orderDetailId.Value);

            // Assert
            Assert.IsNull(orderDetailsModel);
        }

        [Test]
        public void GetById_ShouldReturnsNullWhenOrderDetailIdIsNull()
        {
            //Arrange
            var EfRepositoryStub = new Mock<IEfRepository<OrderDetail>>();
            var SaveContextStub = new Mock<ISaveContext>();


            var orderDetailsService = new OrderDetailsService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            OrderDetail orderDetailModel = orderDetailsService.GetById(null);

            // Assert
            Assert.IsNull(orderDetailModel);
        }

        [Test]
        public void Create_Should_CallContextCommit()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<OrderDetail>>();
            var SaveContextMock = new Mock<ISaveContext>();
            var orederDetailsService = new OrderDetailsService(EfRepositoryStub.Object, SaveContextMock.Object);

            OrderDetail orderDetail = new OrderDetail();

            // Act
            orederDetailsService.Create(orderDetail);

            // Assert
            SaveContextMock.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Update_Should_CallContextCommit()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<OrderDetail>>();
            var SaveContextMock = new Mock<ISaveContext>();
            var orederDetailsService = new OrderDetailsService(EfRepositoryStub.Object, SaveContextMock.Object);
            OrderDetail orderDetail = new OrderDetail();

            // Act
            orederDetailsService.Update(orderDetail);

            // Assert
            SaveContextMock.Verify(x => x.Commit(), Times.Once);
        }
    }
}
