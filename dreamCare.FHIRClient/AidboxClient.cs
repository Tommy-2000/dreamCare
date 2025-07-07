using Aidbox.Client;
using dreamCare.FHIRClient.Security;
using Hl7.Fhir.Rest;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace dreamCare.FHIRClient
{
    public class AidboxClient
    {

        // Declare IConfiguration to access secrets
        private static readonly IConfiguration _config;

        public static FhirClient GetAidboxClient()
        {
            var aidboxUsername = _config["Aidbox_Username"];
            var aidboxPassword = _config["Aidbox_Password"];
            var aidboxClientUrl = _config["Aidbox_Client_Url"];

            List<string> aidboxConfig = [aidboxUsername, aidboxPassword, aidboxClientUrl];

            if (aidboxConfig != null)
            {
                var aidboxAuth = new Auth
                {

                    Method = AuthMethods.BASIC,
                    Credentials = new AuthCredentials
                    {
                        Username = aidboxConfig[0],
                        Password = aidboxConfig[1]
                    }
                };

                var fhirClient = new FhirClient(new Uri(aidboxConfig[2]), new FhirClientSettings
                {
                    Timeout = 10000,
                    PreferredFormat = ResourceFormat.Json,
                    UseAsync = true,
                    VerifyFhirVersion = true,
                    ReturnPreference = ReturnPreference.Representation,

                });

                // Configure handler for FHIRClient
                var authorizationHandler = new FhirAuthorizationHandler();

                // Add the bearerToken to the AuthorizationHandler
                var bearerToken = "";

                authorizationHandler.AuthorisationHeader = new AuthenticationHeaderValue(bearerToken);

                fhirClient.RequestHeaders.Add("Authorization", "Basic ");

                return fhirClient;
            }
            else
            {
                throw new InvalidOperationException("Aidbox Config is null, please add necessary parameters to secrets.json");
            }
        }

    }

}
