using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using QventoAPI;
using QventoAPI.Controllers;
using QventoAPI.Data;

namespace TestQventoAPI

{
    [TestClass]
    public class TestQventoController
    {
        ApiClient apiClient;

        private ApiClient ApiClientFor(System.Net.Http.HttpClient client)
        {
            return apiClient = new ApiClient(client);
        }

        [ClassInitialize]
        public static void TestSetup(TestContext context)
        {
            var task = Vault.GetConnectionString();
            task.Wait();
        }

        [TestMethod]
        public void TestGetFakeQventos()
        {
            var connector = new MockDbConnector();

            var qvento = connector.FindQvento(1);

            var actualTitle = qvento.Title;
            var expectedTitle = "Qvento de prueba cancelado";

            Assert.AreEqual(expectedTitle, actualTitle);
        }

        //[TestMethod]
        //public void TestGetQvento()
        //{
        //    var controller = new QventoController();

        //    var result = controller.GetQvento(100);
        //    var qvento = result.Value;

        //    Assert.AreEqual(qvento.QventoId, 100);
        //    Assert.AreEqual(qvento.CreatedBy, 100);
        //    Assert.AreEqual(qvento.Title, "Fake Qvento 01");
        //    Assert.AreEqual(qvento.DateOfQvento, new DateTime(2022, 12, 01));
        //    Assert.AreEqual(qvento.DateCreated, new DateTime(2022, 11, 01));
        //    Assert.AreEqual(qvento.Status, "A");
        //    Assert.AreEqual(qvento.Description, "El veloz murciélago hindú comía feliz cardillo y kiwi. La cigüeña tocaba el saxofón detrás del palenque de paja.");
        //    Assert.AreEqual(qvento.Location, "Calle Falsa 01, Madrid");
        //}

        //[TestMethod]
        //public void TestGetQventos()
        //{
        //    var controller = new QventoController();

        //    var qventos = controller.GetQventos();

        //    var result = qventos.Value.Count;

        //    Assert.IsTrue(result == 4);
        //}
    }
}