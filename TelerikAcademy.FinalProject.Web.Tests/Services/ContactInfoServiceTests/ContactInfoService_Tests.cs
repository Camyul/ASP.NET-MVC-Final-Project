using Moq;
using NUnit.Framework;
using System;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;

namespace TelerikAcademy.FinalProject.Web.Tests.Services.ContactInfoService
{
    [TestFixture]
    public class ContactInfoService_Tests
    {
        [Test]
        public void GetAll_Should_CallRepository_All()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<ContactInfo>>();
            var SaveContextStub = new Mock<ISaveContext>();
            var contactInfoService = new TelerikAcademy.FinalProject.Services.ContactInfoService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            contactInfoService.GetAll();

            // Assert
            EfRepositoryStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetById_ShouldReturnsNullWhenContactInfoIdNotValid()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<ContactInfo>>();
            var SaveContextStub = new Mock<ISaveContext>();
            Guid? contactInfoId = Guid.NewGuid();


            var contactInfoService = new TelerikAcademy.FinalProject.Services.ContactInfoService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            ContactInfo contactInfoModel = contactInfoService.GetById(contactInfoId.Value);

            // Assert
            Assert.IsNull(contactInfoModel);
        }

        [Test]
        public void GetById_ShouldReturnsNullWhenContactInfoIdIsNull()
        {
            //Arrange
            var EfRepositoryStub = new Mock<IEfRepository<ContactInfo>>();
            var SaveContextStub = new Mock<ISaveContext>();
            Guid? contactInfoId = Guid.NewGuid();


            var contactInfoService = new TelerikAcademy.FinalProject.Services.ContactInfoService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Act
            ContactInfo contactInfoModel = contactInfoService.GetById(null);

            // Assert
            Assert.IsNull(contactInfoModel);
        }

        [Test]
        public void Create_Should_CallContextCommit()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<ContactInfo>>();
            var SaveContextMock = new Mock<ISaveContext>();
            var contactInfoService = new TelerikAcademy.FinalProject.Services.ContactInfoService(EfRepositoryStub.Object, SaveContextMock.Object);
            ContactInfo contact = new ContactInfo();

            // Act
            contactInfoService.Create(contact);

            // Assert
            SaveContextMock.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Update_Should_CallContextCommit()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<ContactInfo>>();
            var SaveContextMock = new Mock<ISaveContext>();
            var contactInfoService = new TelerikAcademy.FinalProject.Services.ContactInfoService(EfRepositoryStub.Object, SaveContextMock.Object);
            ContactInfo contact = new ContactInfo();

            // Act
            contactInfoService.Update(contact);

            // Assert
            SaveContextMock.Verify(x => x.Commit(), Times.Once);
        }
    }
}
