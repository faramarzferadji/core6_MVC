using Azure.Identity;
using NuGet.Packaging;
using PayPalCheckoutSdk.Core;
//using PayPalCheckoutSdk.Core.Credentials;


namespace Project_shst.Models
{
    public class PayPalService
    {
        //private PayPalHttpClient client;

        public PayPalService(string clientId, string secretKey)
        {
            //var credentials = new ClientSecretCredential("AeDq_OSydtDvep_F1GFGqotvI_TApHeKRqrsYwwfRe6ki7aF8M8Tfvt0DyhPXxlEHm6ydmdJMncWkJWs", "EATxBQmluGzUtE2jQ0mtD0XfLDTTJ0Gumcn1KsCTyU_R5-Wny6uaJfgj7bvXVW1tdP2wfv5D4inTJUpw");
            //var environment = new SandboxEnvironment("sb-gkowg25130128@business.example.com");
            ////this.client = new PayPalHttpClient(environment, credentials);
        }
    }
}
