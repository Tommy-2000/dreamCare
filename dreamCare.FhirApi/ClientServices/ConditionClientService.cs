using Hl7.Fhir.Model;

namespace dreamCare.FhirApi.ClientServices
{
    public class ConditionClientService(Hl7.Fhir.Rest.FhirClient fhirClient)
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
