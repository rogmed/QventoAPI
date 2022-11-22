using Newtonsoft.Json;
using QventoAPI.Data;
using QventoAPI.Controllers;
using Azure.Core;

namespace TestQventoAPI

{
    [TestClass]
    public class TestQventoController
    {
        [TestMethod]
        public void TestFindQvento()
        {
            var controller = new QventoController();

            var result = controller.GetQvento(1).Result;

            Assert.IsNotNull(result);
        }
    }
}