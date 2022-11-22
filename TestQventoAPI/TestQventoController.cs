using QventoAPI.Data;
using System.Net.Http.Json;

namespace TestQventoAPI
{
    [TestClass]
    public class TestQventoController
    {
        private ApiWebApplicationFactory _api;
        private HttpClient _client;

        public TestQventoController()
        {
            _api = new ApiWebApplicationFactory();
            _client = _api.CreateClient();
        }

        [TestMethod]
        public async Task TestGetFakeQvento()
        {
            var qventos = await _client.GetFromJsonAsync<List<Qvento>>("/all-qventos");

            Assert.IsNotNull(qventos);

            Assert.AreEqual("Qvento de prueba activo", qventos[0].Title);
            Assert.AreEqual("Qvento de prueba cancelado", qventos[1].Title);
            Assert.AreEqual("Qvento de prueba finalizado", qventos[2].Title);
        }

        [TestMethod]
        public async Task TestGetQvento()
        {
            var qvento = await _client.GetFromJsonAsync<Qvento>("/qvento/100");

            Assert.IsNotNull(qvento);

            Assert.AreEqual(100, qvento.QventoId);
            Assert.AreEqual(100, qvento.CreatedBy);
            Assert.AreEqual("Fake Qvento 01", qvento.Title);
            Assert.AreEqual(new DateTime(2022, 12, 01), qvento.DateOfQvento);
            Assert.AreEqual(new DateTime(2022, 11, 01), qvento.DateCreated);
            Assert.AreEqual("A", qvento.Status);
            Assert.AreEqual("El veloz murciélago hindú comía feliz cardillo y kiwi. " +
                "La cigüeña tocaba el saxofón detrás del palenque de paja.",
                qvento.Description);
            Assert.AreEqual("Calle Falsa 01, Madrid", qvento.Location);
        }
    }
}
