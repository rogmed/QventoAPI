using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using QventoAPI;

namespace TestQventoAPI
{
    internal class ApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        public IConfiguration? Configuration { get; private set; }
        public static string? connectionString;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var task = Vault.GetConnectionString();
            task.Wait();

            Environment.SetEnvironmentVariable("SQLAZURECONNSTR_QVENTODB", connectionString);

            builder.ConfigureAppConfiguration(config => { });

            builder.ConfigureTestServices(services => { });
        }
        public static async Task GetConnectionString()
        {
            string keyVaultName = "QventoVault";
            var kvUri = "https://" + keyVaultName + ".vault.azure.net";
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            var secret = await client.GetSecretAsync("connectionString");

            connectionString = secret.Value.Value;
        }
    }
}
