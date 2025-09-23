using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace dreamCare.FhirApi.FhirServices
{
    public class ObservationFhirService(FhirClient fhirClient)
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

        public async Task<Observation?> RefreshObservation(Observation observation)
        {
            return await fhirClient.RefreshAsync(observation);
        }

        public async Task<Observation?> CreateObservation(Observation observation)
        {
            return await fhirClient.CreateAsync(observation);
        }

        public async Task<Observation?> UpdateObservation(Observation observation)
        {
            return await fhirClient.UpdateAsync(observation);
        }

    }
}
