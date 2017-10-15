using Moq;
using NUnit.Framework;
using System;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;

namespace TelerikAcademy.FinalProject.Web.Tests.Services.ContactInfoService
{

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ConstructorShould_CreateCategoryInfoService()
        {

            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<ContactInfo>>();
            var SaveContextStub = new Mock<ISaveContext>();

            // Act
            var contactInfoService = new TelerikAcademy.FinalProject.Services.ContactInfoService(EfRepositoryStub.Object, SaveContextStub.Object);

            // Assert
            Assert.IsNotNull(contactInfoService);
        }

        [Test]
        public void ThrowException_WhenEfRepositoryIsNull()
        {
            // Arrange
            var SaveContextStub = new Mock<ISaveContext>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TelerikAcademy.FinalProject.Services.ContactInfoService(null, SaveContextStub.Object));
        }

        [Test]
        public void ThrowException_WhenSaveContextIsNull()
        {
            // Arrange
            var EfRepositoryStub = new Mock<IEfRepository<ContactInfo>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TelerikAcademy.FinalProject.Services.ContactInfoService(EfRepositoryStub.Object, null));
        }
    }
}
