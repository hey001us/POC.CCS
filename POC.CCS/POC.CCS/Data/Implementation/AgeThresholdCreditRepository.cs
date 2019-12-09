namespace POC.CCS.Data.Implementation
{
    using Newtonsoft.Json;
    using POC.CCS.Data.Interface;
    using POC.CCS.Models;

    public class AgeThresholdCreditRepository : BaseReadOnlyRepository<AgeThresholdCredit>, IAgeThresholdCreditRepository
    {
        protected override AgeThresholdCredit[] Data
        {
            get
            {
                return JsonConvert.DeserializeObject<AgeThresholdCredit[]>(Helpers.FileReaderHelper.ReadJsonFile(@"Data\DataStore\age-threshold-credit.json"));
            }
        }
    }
}
