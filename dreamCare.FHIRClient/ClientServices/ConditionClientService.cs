using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace dreamCare.FHIRClient.ClientServices
{
    public class ConditionClientService(FhirClient fhirClient)
    {
        
        public async Task<Condition?> GetConditionById(Id conditionId)
        {
            var condition = await fhirClient.ReadAsync<Condition>($"fhir/Condition?id={conditionId}");
            return condition;
        }
        
        public async Task<Condition?> GetConditionByCode(Code conditionCode)
        {
            var condition = await fhirClient.ReadAsync<Condition>($"fhir/Condition?code={conditionCode}");
            return condition;
        }
        
        
        
    }
}
