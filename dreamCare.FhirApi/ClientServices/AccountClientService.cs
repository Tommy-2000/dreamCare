using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace dreamCare.FhirApi.ClientServices
{
    public class AccountClientService(FhirClient fhirClient)
    {
        
        public async Task<Account?> GetAccount(Account account)
        {
            return await fhirClient.ReadAsync<Account>($"Account?=subject={account}");
        }

        public async Task<Patient?> GetPatientById(Id accountId)
        {
            return await fhirClient.ReadAsync<Patient>($"Account?subject=Account/{accountId}");
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
