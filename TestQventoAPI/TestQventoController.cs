using Newtonsoft.Json;
using QventoAPI;
using QventoAPI.Controllers;
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
        public async Task TestFindQvento()
        {
            var qventos = await _client.GetFromJsonAsync<List<Qvento>>("/all-qventos");

            Assert.IsNotNull(qventos);
        }
    }
}