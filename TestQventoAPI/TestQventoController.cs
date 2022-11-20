using Newtonsoft.Json;
using QventoAPI;
using QventoAPI.Controllers;

namespace TestQventoAPI

{
    [TestClass]
    public class TestQventoController
    {
        [TestMethod]
        public void TestFindQvento()
        {
            var controller = new QventoController();

            var qvento = controller.GetQvento("1").Result;

            var actualTitle = qvento.Title;
            var expectedTitle = "Qvento de prueba cancelado";

            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }
}