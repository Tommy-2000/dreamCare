using System.Net.Http.Headers;
using dreamCare.FhirApi.Security;
using Hl7.Fhir.Rest;

namespace dreamCare.FhirApi
{
    public class AidboxClient
    {

        // Declare IConfiguration to access secrets
        private readonly IConfiguration _config;

        // Declare ILogger for the FhirLoggingHandler
        private readonly ILogger _logger;

        public AidboxClient(IConfiguration config, ILogger logger)
        {
            _config = config;
            _logger = logger;
        }

        public FhirClient GetFhirClient()
        {
  
            var aidboxClientUrl = _config["Aidbox_Client_Url"];
            
            if (aidboxClientUrl != null)
            {

                // Configure authorization and logging handlers for FHIRClient
                var authorizationHandler = new FhirAuthHandler();

                authorizationHandler.AuthorisationHeader = new AuthenticationHeaderValue("Authorization", $"Basic 03912j0932f203");
                
                var loggingHandler = new FhirLoggingHandler(_logger)
                {
                    InnerHandler = authorizationHandler
                };
                
                var fhirClient = new FhirClient(aidboxClientUrl, new FhirClientSettings
                {
                    PreferredFormat = ResourceFormat.Json,
                    UseAsync = true,
                    VerifyFhirVersion = true
                }, loggingHandler);

                
                return fhirClient;
            }
            else
            {
                throw new InvalidOperationException("Aidbox Config is null, please add necessary parameters to secrets.json");
            }
        }

    }

}
