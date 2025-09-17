using Hl7.Fhir.Model;

namespace dreamCare.FhirApi.ClientServices
{
    public class EncounterClientService(Hl7.Fhir.Rest.FhirClient fhirClient)
    {
        
        public async Task<Encounter?> GetEncounterById(Id encounterId)
        {
            var patient = await fhirClient.ReadAsync<Encounter>($"fhir/Encounter?id={encounterId}");
            return patient;
        }
        
        // public async Task<Encounter?> GetEncounterByServiceProvider(ResourceReference encounterServiceProvider)
        // {
        //     var patient = await fhirClient.ReadAsync<Encounter>($"fhir/Encounter?name={patientGivenName}");
        //     return patient;
        // }
        
        public async Task<Encounter?> GetEncounterByFamilyName(string patientFamilyName)
        {
            var patient = await fhirClient.ReadAsync<Encounter>($"fhir/Patient?family={patientFamilyName}");
            return patient;
        }
        
        
        public async Task<Encounter?> GetEncounterByGender(AdministrativeGender patientAdminGender)
        {
            var patient = await fhirClient.ReadAsync<Encounter>($"fhir/Patient?gender={patientAdminGender}");
            return patient;
        }

        public async Task<Encounter?> GetEncounterByDateOfBirth(Date patientDateOfBirth)
        {
            var patient = await fhirClient.ReadAsync<Encounter>($"fhir/Patient?birthdate={patientDateOfBirth}");
            return patient;
        }
        
        
        public async Task<Encounter?> GetEncounterByDateOfDeath(Date patientDateOfDeath)
        {
            var patient = await fhirClient.ReadAsync<Encounter>($"fhir/Patient?death-date={patientDateOfDeath}");
            return patient;
        }
        
        
        
        public async Task<Encounter?> GetEncounterByAddress(Address patientAddress)
        {
            var patient = await fhirClient.ReadAsync<Encounter>($"fhir/Patient?address=\"{patientAddress}\"");
            return patient;
        }
        
        
    }
}
