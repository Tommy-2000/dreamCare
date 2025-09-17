using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace dreamCare.FhirApi.ClientServices
{
    public class PatientClientService(FhirClient fhirClient)
    {
        
        public async Task<Patient?> GetPatient(Patient patient)
        {
            return await fhirClient.ReadAsync<Patient>($"Patient?=subject={patient}");
        }

        public async Task<Patient?> GetPatientById(Id patientId)
        {
            return await fhirClient.ReadAsync<Patient>($"Patient?subject=Patient/{patientId}");
        }
        
        public async Task<Patient?> GetPatientByGivenName(string patientGivenName)
        {
            return await fhirClient.ReadAsync<Patient>($"Patient?name={patientGivenName}");
        }
        
        public async Task<Patient?> GetPatientByFamilyName(string patientFamilyName)
        {
            return await fhirClient.ReadAsync<Patient>($"Patient?family={patientFamilyName}");
        }
        
        public async Task<Patient?> GetPatientsByGender(AdministrativeGender patientAdminGender)
        {
            return await fhirClient.ReadAsync<Patient>($"Patient?gender={patientAdminGender}");
        }

        public async Task<Patient?> GetPatientByDateOfBirth(Date patientDateOfBirth)
        {
            return await fhirClient.ReadAsync<Patient>($"Patient?birthdate={patientDateOfBirth}");
        }
        
        
        public async Task<Patient?> GetPatientByDateOfDeath(Date patientDateOfDeath)
        {
            return await fhirClient.ReadAsync<Patient>($"Patient?death-date={patientDateOfDeath}");
        }
        
        
        public async Task<Patient?> GetPatientByAddress(Address patientAddress)
        {
            return await fhirClient.ReadAsync<Patient>($"Patient?address=\"{patientAddress}\"");
        }

        public async Task<Patient?> CreatePatient(Patient patient)
        {
            return await fhirClient.CreateAsync(patient);
        }
        
    }
}
