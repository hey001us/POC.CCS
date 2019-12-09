namespace POC.CCS.Data.Implementation
{
    using Newtonsoft.Json;
    using POC.CCS.Data.Interface;
    using POC.CCS.Models;

    public class MissedPaymentRepository : BaseReadOnlyRepository<MissedPayment>, IMissedPaymentRepository
    {
        protected override MissedPayment[] Data
        {
            get
            {
                return JsonConvert.DeserializeObject<MissedPayment[]>(Helpers.FileReaderHelper.ReadJsonFile(@"Data\DataStore\missed-payment.json"));
            }
        }
    }
}
