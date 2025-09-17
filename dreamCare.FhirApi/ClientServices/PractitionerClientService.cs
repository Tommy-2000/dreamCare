using Hl7.Fhir.Model;

namespace dreamCare.FhirApi.ClientServices
{
    public class PractitionerClientService(Hl7.Fhir.Rest.FhirClient fhirClient)
    {
        
        public async Task<Practitioner?> GetPractitionerById(Id practitionerId)
        {
            var practitioner = await fhirClient.ReadAsync<Practitioner>($"fhir/Practitioner?subject=Practitioner/{practitionerId}");
            return practitioner;
        }
        
        public async Task<Practitioner?> GetPatientByGivenName(string practitionerGivenName)
        {
            var practitioner = await fhirClient.ReadAsync<Practitioner>($"fhir/Practitioner?name={practitionerGivenName}");
            return practitioner;
        }
        
        public async Task<Practitioner?> GetPractitionerByFamilyName(string practitionerFamilyName)
        {
            var patient = await fhirClient.ReadAsync<Practitioner>($"fhir/Practitioner?family={practitionerFamilyName}");
            return patient;
        }
        
        
        public async Task<Practitioner?> GetPractitionerByGender(AdministrativeGender patientAdminGender)
        {
            var patient = await fhirClient.ReadAsync<Practitioner>($"fhir/Practitioner?gender={patientAdminGender}");
            return patient;
        }

        public async Task<Practitioner?> GetPractitionerByDateOfBirth(Date practitionerDateOfBirth)
        {
            var patient = await fhirClient.ReadAsync<Practitioner>($"fhir/Practitioner?birthdate={practitionerDateOfBirth}");
            return patient;
        }
        
        
        public async Task<Practitioner?> GetPractitionerByAddress(Address practitionerAddress)
        {
            var patient = await fhirClient.ReadAsync<Practitioner>($"fhir/Practitioner?address=\"{practitionerAddress}\"");
            return patient;
        }
        
        
    }
}
