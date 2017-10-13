using NUnit.Framework;
using TelerikAcademy.FinalProject.Data;

namespace TelerikAcademy.FinalProject.Web.Tests.Data.DbContext
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ReturnNewDbContext_WhenParamsAreValid()
        {
            // Arrange & Act
            var newContext = MsSqlDbContext.Create();

            // Assert
            Assert.IsNotNull(newContext);
            Assert.IsInstanceOf<MsSqlDbContext>(newContext);
        }
    }
}
