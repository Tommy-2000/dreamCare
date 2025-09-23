using dreamCare.FhirApi.FhirServices;
using Hl7.Fhir.Model;

namespace dreamCare.FhirApi.Endpoints;

public static class DiagnosticReportsEndpoints
{

    public static void MapDiagnosticReportEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/fhir/DiagnosticReport").WithTags(nameof(DiagnosticReport));

        group.MapGet("/{id}", (Id diagnosticReportId, DiagnosticReportsFhirService diagnosticReportsFhirService) =>
        {
            var returnedDiagnosticReport = diagnosticReportsFhirService.GetDiagnosticReportById(diagnosticReportId);
            return TypedResults.Ok(returnedDiagnosticReport);
        })
        .WithName("GetDiagnosticReportById")
        .WithOpenApi();

        group.MapPut("/{id}", (Id diagnosticReportId, DiagnosticReport inputDiagnosticReport, DiagnosticReportsFhirService diagnosticReportFhirService) =>
        {
            var returnedDiagnosticReport = diagnosticReportFhirService.UpdateDiagnosticReport(inputDiagnosticReport);
            return TypedResults.Ok(returnedDiagnosticReport);
        })
        .WithName("UpdateDiagnosticReportById")
        .WithOpenApi();

        group.MapPost("/", (DiagnosticReport inputDiagnosticReport, DiagnosticReportsFhirService diagnosticReportFhirService) =>
        {
            var returnedDiagnosticReport = diagnosticReportFhirService.CreateDiagnosticReport(inputDiagnosticReport);
            return TypedResults.Created($"/fhir/DiagnosticReport/{returnedDiagnosticReport.Id}", returnedDiagnosticReport);
        })
        .WithName("CreateDiagnosticReport")
        .WithOpenApi();


    }
}
