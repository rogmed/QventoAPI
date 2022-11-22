using QventoAPI.Data;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestQventoAPI
{
    internal sealed class ApiClient : IDisposable
    {
        private readonly System.Net.Http.HttpClient client;

        public ApiClient(System.Net.Http.HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException("client");
        }

        public void Dispose()
        {
        }

        private async Task<HttpResponseMessage> Get(string requestUri)
        {
            return await client.GetAsync(requestUri);
        }

        public async Task<string> TryGetQvento(string qventoId)
        {
            HttpResponseMessage response = await Get($"qvento/{qventoId}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}

