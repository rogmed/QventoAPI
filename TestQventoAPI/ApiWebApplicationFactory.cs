using Azure.Identity;
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
            //var task = Vault.GetConnectionString();
            //task.Wait();

            Environment.SetEnvironmentVariable("SQLAZURECONNSTR_QVENTODB", "Server=tcp:qvento-db.database.windows.net,1433;Initial Catalog=qventodb;Persist Security Info=False;User ID=rogelio11903@linkiafp.es;Password=lTitojik18++;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication='Active Directory Password';");

            builder.ConfigureAppConfiguration(config => { });

            builder.ConfigureTestServices(services => { });
        }
    }
}
