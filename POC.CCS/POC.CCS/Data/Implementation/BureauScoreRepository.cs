namespace POC.CCS.Data.Implementation
{
    using Newtonsoft.Json;
    using POC.CCS.Data.Interface;
    using POC.CCS.Models;

    public class BureauScoreRepository : BaseReadOnlyRepository<BureauScore>, IBureauScoreRepository
    {
        protected override BureauScore[] Data
        {
            get
            {
                return JsonConvert.DeserializeObject<BureauScore[]>(Helpers.FileReaderHelper.ReadJsonFile(@"Data\DataStore\bureau-score.json"));
            }
        }
    }
}
