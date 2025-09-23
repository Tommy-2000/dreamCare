using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace dreamCare.FhirApi.FhirServices
{
    public class EncounterFhirService(FhirClient fhirClient)
    {
        
        public async Task<Encounter?> GetEncounterById(Id encounterId)
        {
            var patient = await fhirClient.ReadAsync<Encounter>($"fhir/Encounter?id={encounterId}");
            return patient;
        }
        
       
        public async Task<Encounter?> GetEncounterByGender(AdministrativeGender patientAdminGender)
        {
            var patient = await fhirClient.ReadAsync<Encounter>($"fhir/Patient?gender={patientAdminGender}");
            return patient;
        }
        

        public async Task<Encounter?> GetEncounterByAddress(Address patientAddress)
        {
            var patient = await fhirClient.ReadAsync<Encounter>($"fhir/Patient?address=\"{patientAddress}\"");
            return patient;
        }


        public async Task<Encounter?> RefreshEncounter(Encounter encounter)
        {
            return await fhirClient.RefreshAsync(encounter);
        }


        public async Task<Encounter?> CreateEncounter(Encounter encounter)
        {
            return await fhirClient.CreateAsync(encounter);
        }


        public async Task<Encounter?> UpdateEncounter(Encounter encounter)
        {
            return await fhirClient.UpdateAsync(encounter);
        }


    }
}
