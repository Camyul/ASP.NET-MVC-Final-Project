using NUnit.Framework;
using TelerikAcademy.FinalProject.Data;

namespace TelerikAcademy.FinalProject.Web.Tests.Data.DbContext
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfIMsSqlDbContext_WhenParamsAreValid()
        {
            //Arrange
            var context = new MsSqlDbContext();

            //Act & Assert
            Assert.IsInstanceOf<MsSqlDbContext>(context);
        }
    }
}
