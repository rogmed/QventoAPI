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

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            Environment.SetEnvironmentVariable("SQLAZURECONNSTR_QVENTODB", Vault.connectionString);

            builder.ConfigureAppConfiguration(config => { });

            builder.ConfigureTestServices(services => { });
        }
    }
}
