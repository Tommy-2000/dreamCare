using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace dreamCare.FHIRClient.ClientServices
{
    public class ObservationClientService(FhirClient fhirClient)
    {
        
        public async Task<Observation?> GetObservationById(Id observationId)
        {
            var observation = await fhirClient.ReadAsync<Observation>($"fhir/Observation?id={observationId}");
            return observation;
        }
        
        public async Task<Observation?> GetObservationByPatientId(Id observationPatientId)
        {
            var observation = await fhirClient.ReadAsync<Observation>($"fhir/Observation?subject=Patient/{observationPatientId}");
            return observation;
        }
        
        public async Task<Observation?> GetObservationByPatientGivenName(string observationPatientGivenName)
        {
            var observation = await fhirClient.ReadAsync<Observation>($"fhir/Observation?subject=Patient/{observationPatientGivenName}");
            return observation;
        }
        
        
        public async Task<Observation?> GetObservationByPatientFamilyName(string observationPatientFamilyName)
        {
            var observation = await fhirClient.ReadAsync<Observation>($"fhir/Observation?subject=Patient/{observationPatientFamilyName}");
            return observation;
        }

        public async Task<Observation?> GetObservationByLastUpdated(Date observationLastUpdated)
        {
            var observation = await fhirClient.ReadAsync<Observation>($"fhir/Observation?lastUpdated={observationLastUpdated}");
            return observation;
        }
        
        
        public async Task<Observation?> GetObservationByDateOfDeath(Date patientDateOfDeath)
        {
            var observation = await fhirClient.ReadAsync<Observation>($"fhir/Observation?death-date={patientDateOfDeath}");
            return observation;
        }
        
        
        
        public async Task<Observation?> GetObservationByAddress(Address patientAddress)
        {
            var observation = await fhirClient.ReadAsync<Observation>($"fhir/Observation?address=\"{patientAddress}\"");
            return observation;
        }
        
        
    }
}
