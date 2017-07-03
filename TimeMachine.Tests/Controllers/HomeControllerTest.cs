using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using TimeMachine.Controllers;

namespace TimeMachine.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var result = controller.Index() as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
