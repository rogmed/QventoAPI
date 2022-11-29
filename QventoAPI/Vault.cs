using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace QventoAPI
{
    public static class Vault
    {
        public static string? connectionString;
        public static void GetConnectionString()
        {
            string keyVaultName = "QventoVault";
            var kvUri = "https://" + Environment.GetEnvironmentVariable("VaultUri") + ".vault.azure.net";
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            var secret = client.GetSecret("connectionString");

            connectionString = secret.Value.Value;
        }
    }
}
