using dreamCare.FhirApi.Aidbox.HL7_Fhir_R4_Core;

namespace dreamCare.FhirApi.Endpoints;

public static class ConditionEndpoints
{
    public static void MapConditionEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Condition").WithTags(nameof(Condition));

        group.MapGet("/", () =>
        {
            return new [] { new Condition.ConditionEvidence() };
        })
        .WithName("GetAllConditions")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Condition { ID = id };
        })
        .WithName("GetConditionById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Condition input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateCondition")
        .WithOpenApi();

        group.MapPost("/", (Condition model) =>
        {
            //return TypedResults.Created($"/api/Conditions/{model.ID}", model);
        })
        .WithName("CreateCondition")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Condition { ID = id });
        })
        .WithName("DeleteCondition")
        .WithOpenApi();
    }
}
