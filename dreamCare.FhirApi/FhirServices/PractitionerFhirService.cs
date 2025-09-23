using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace dreamCare.FhirApi.FhirServices
{
    public class PractitionerFhirService(FhirClient fhirClient)
    {
        
        public async Task<Practitioner?> GetPractitionerById(Id practitionerId)
        {
            var resourceLocation = new Uri($"fhir/Practitioner?subject=Practitioner/{practitionerId}");
            var practitioner = await fhirClient.ReadAsync<Practitioner>(resourceLocation);
            return practitioner;
        }
        
        public async Task<Practitioner?> GetPractitionerByName(FhirString practitionerName)
        {
            var resourceLocation = new Uri($"fhir/Practitioner?name={practitionerName}");
            var practitioner = await fhirClient.ReadAsync<Practitioner>(resourceLocation);
            return practitioner;
        }
        
        
        public async Task<Practitioner?> GetPractitionerByAddress(Address practitionerAddress)
        {
            var resourceLocation = new Uri($"fhir/Practitioner?address=\"{practitionerAddress}\"");
            var practitioner = await fhirClient.ReadAsync<Practitioner>(resourceLocation);
            return practitioner;
        }

        public async Task<Practitioner?> GetPractitionerByTelecom(FhirString practitionerTelecom)
        {
            var resourceLocation = new Uri($"fhir/Practitioner?telecom=\"{practitionerTelecom}\"");
            var practitioner = await fhirClient.ReadAsync<Practitioner>(resourceLocation);
            return practitioner;
        }

        //public async Task<List<Practitioner>?> GetActivePractitioners(FhirString activeRecord)
        //{
        //    var resourceLocation = new Uri($"fhir/Practitioner?active=\"{activeRecord}\"");
        //    var practitioner = await fhirClient.ReadAsync<List<Practitioner>>(resourceLocation);
        //    return practitioner;
        //}

        public async Task<Practitioner?> RefreshPractitioner(Practitioner practitioner)
        {
            return await fhirClient.RefreshAsync(practitioner);
        }

        public async Task<Practitioner?> CreatePractitioner(Practitioner practitioner)
        {
            return await fhirClient.CreateAsync(practitioner);
        }

        public async Task<Practitioner?> UpdatePractitioner(Practitioner practitioner)
        {
            return await fhirClient.UpdateAsync(practitioner);
        }

    }
}
