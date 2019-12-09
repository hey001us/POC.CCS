namespace POC.CCS.Data.Implementation
{
    using Newtonsoft.Json;
    using POC.CCS.Data.Interface;
    using POC.CCS.Models;

    public class AvailableCreditRepository : BaseReadOnlyRepository<AvailableCredit>, IAvailableCreditRepository
    {
        protected override AvailableCredit[] Data
        {
            get
            {
                return JsonConvert.DeserializeObject<AvailableCredit[]>(Helpers.FileReaderHelper.ReadJsonFile(@"Data\DataStore\available-credit.json"));
            }
        }
    }
}
