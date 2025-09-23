using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace dreamCare.FhirApi.FhirServices
{
    public class ConditionFhirService(FhirClient fhirClient)
    {
        
        public async Task<Condition?> GetConditionById(Id conditionId)
        {
            var condition = await fhirClient.ReadAsync<Condition>($"fhir/Condition?id={conditionId}");
            return condition;
        }
        
        //public async Task<List<Condition>?> GetConditionsByCode(Code conditionCode)
        //{
        //    var condition = await fhirClient.ReadAsync<List<Condition>>($"fhir/Condition?code={conditionCode}");
        //    return condition;
        //}

        public async Task<Condition?> GetConditionsByCategory(FhirString conditionCategory)
        {
            var condition = await fhirClient.ReadAsync<Condition>($"fhir/Condition?category={conditionCategory}");
            return condition;
        }

        public async Task<Condition?> RefreshCondition(Condition condition)
        {
            return await fhirClient.RefreshAsync(condition);
        }

        public async Task<Condition?> CreateCondition(Condition condition)
        {
            return await fhirClient.CreateAsync(condition);
        }

        public async Task<Condition?> UpdateCondition(Condition condition)
        {
            return await fhirClient.UpdateAsync(condition);
        }

    }
}
