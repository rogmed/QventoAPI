using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace QventoAPI
{
    public static class Vault
    {
        public static string? connectionString;
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
