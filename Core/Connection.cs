using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace CoreRequisicaoCEP
{
    public static class Connection
    {
        public static string GetServiceBusConnection()
        {
            return GetSecret("sc-requisicaocepsbconnection");
        }

        public static string GetServiceSQLServerConnection()
        {
            return GetSecret("sc-requisicaocepsqlconnection");
        }

        private static string GetSecret(string secretName)
        {
            string clientId = "d94fc964-b445-4003-a0cd-575162d481b1";
            string tenantId = "5600e0fc-d3c3-462e-a39f-bb66431964c2";

            string clientSecret = "4gc8Q~CZxLv-AfmhBPb7P7ooK6VebLtqJ4fDKbuJ";

            string keyVaultUri = "https://kv-requisicaocep.vault.azure.net/";

            var credentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var client = new SecretClient(new Uri(keyVaultUri), credentials);
            KeyVaultSecret secret = client.GetSecret(secretName);
            return secret.Value;
        }
    }
}
