using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace dreamCare.FhirApi.FhirServices
{
    public class DiagnosticReportsFhirService(FhirClient fhirClient)
    {
        
        public async Task<DiagnosticReport?> GetDiagnosticReportById(Id diagnosticReportId)
        {
            var resourceLocation = new Uri($"fhir/DiagnosticReport?id={diagnosticReportId}");
            return await fhirClient.ReadAsync<DiagnosticReport>(resourceLocation);
        }
        
        public async Task<DiagnosticReport?> RefreshDiagnosticReport(DiagnosticReport diagnosticReport)
        {
            return await fhirClient.RefreshAsync(diagnosticReport);
        }

        public async Task<DiagnosticReport?> CreateDiagnosticReport(DiagnosticReport diagnosticReport)
        {
            return await fhirClient.CreateAsync(diagnosticReport);
        }

        public async Task<DiagnosticReport?> UpdateDiagnosticReport(DiagnosticReport diagnosticReport)
        {
            return await fhirClient.UpdateAsync(diagnosticReport);
        }

    }
}
