using Moq;
using NUnit.Framework;
using System;
using TelerikAcademy.FinalProject.Data;
using TelerikAcademy.FinalProject.Data.SaveContext;

namespace TelerikAcademy.FinalProject.Web.Tests.Data.SaveContextTest
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextIsNull()
        {
            //Arrange
            MsSqlDbContext nullContext = null;

            //Act & Assert
            Assert.That(() => new SaveContext(nullContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("Db context is null!"));
        }

        [Test]
        public void ShouldWork_WhenParamsAreValid()
        {
            //Arrange & Act
            var mockDbContext = new Mock<MsSqlDbContext>();
            var saveContext = new SaveContext(mockDbContext.Object);

            //Assert
            Assert.IsNotNull(saveContext);
        }

        [Test]
        public void CreateUowThatImplementsIDisposableAndIUnitOfWork_WhenParametersAreValid()
        {
            //Arrange & Act
            var mockDbContext = new Mock<MsSqlDbContext>();
            var saveContext = new SaveContext(mockDbContext.Object);

            //Assert
            Assert.IsInstanceOf<SaveContext>(saveContext);
        }
    }
}
