using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System.Runtime.InteropServices;

namespace dreamCare.FhirApi.FhirServices
{
    public class PatientFhirService(FhirClient fhirClient)
    {
        
        public async Task<Patient?> GetPatient(Patient patient)
        {
            var resourceLocation = new Uri($"Patient?=subject={patient}");
            return await fhirClient.ReadAsync<Patient>(resourceLocation);
        }

        public async Task<Patient?> GetPatientById(Id patientId)
        {
            var resourceLocation = new Uri($"Patient?subject=Patient/{patientId}");
            return await fhirClient.ReadAsync<Patient>(resourceLocation);
        }
        
        public async Task<Patient?> GetPatientByGivenName(string patientGivenName)
        {
            var resourceLocation = new Uri($"Patient?name={patientGivenName}");
            return await fhirClient.ReadAsync<Patient>(resourceLocation);
        }
        
        public async Task<Patient?> GetPatientByFamilyName(string patientFamilyName)
        {
            var resourceLocation = new Uri($"Patient?family={patientFamilyName}");
            return await fhirClient.ReadAsync<Patient>(resourceLocation);
        }
        
        public async Task<Patient?> GetPatientsByGender(AdministrativeGender patientAdminGender)
        {
            var resourceLocation = new Uri($"Patient?gender={patientAdminGender}");
            return await fhirClient.ReadAsync<Patient>(resourceLocation);
        }

        public async Task<Patient?> GetPatientByDateOfBirth(Date patientDateOfBirth)
        {
            var resourceLocation = new Uri($"Patient?birthdate={patientDateOfBirth}");

            return await fhirClient.ReadAsync<Patient>(resourceLocation);
        }
        
        
        public async Task<Patient?> GetPatientByDateOfDeath(Date patientDateOfDeath)
        {
            var resourceLocation = new Uri($"Patient?death-date={patientDateOfDeath}");
            return await fhirClient.ReadAsync<Patient>(resourceLocation);
        }
        
        
        public async Task<Patient?> GetPatientByAddress(Address patientAddress)
        {
            var resourceLocation = new Uri($"Patient?address=\"{patientAddress}\"");
            return await fhirClient.ReadAsync<Patient>(resourceLocation);
        }

        public async Task<Patient?> RefreshPatient(Patient patient)
        {
            return await fhirClient.RefreshAsync(patient);
        }

        public async Task<Patient?> CreatePatient(Patient patient)
        {
            return await fhirClient.CreateAsync(patient);
        }

        public async Task<Patient?> UpdatePatient(Patient patient)
        {
            return await fhirClient.UpdateAsync(patient);
        }

    }
}
