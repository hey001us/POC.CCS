namespace POC.CCS.Data.Implementation
{
    using Newtonsoft.Json;
    using POC.CCS.Data.Interface;
    using POC.CCS.Models;

    public class CompletedPaymentRepository : BaseReadOnlyRepository<CompletedPayment>, ICompletedPaymentRepository
    {
        protected override CompletedPayment[] Data
        {
            get
            {
                return JsonConvert.DeserializeObject<CompletedPayment[]>(Helpers.FileReaderHelper.ReadJsonFile(@"Data\DataStore\completed-payment.json"));
            }
        }
    }
}
