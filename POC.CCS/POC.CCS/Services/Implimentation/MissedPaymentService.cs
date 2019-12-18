namespace POC.CCS.Services.Implimentation
{
    using System.Linq;
    using POC.CCS.Data.Interface;
    using POC.CCS.Models;

    public class MissedPaymentService : IMissedPaymentService
    {
        private readonly IMissedPaymentRepository repository;

        public MissedPaymentService(IMissedPaymentRepository repository)
        {
            this.repository = repository;
        }

        public MissedPayment GetMissedPayment(int missedPaymentCount)
        {
            var maxMissedPaymentCount = this.repository.GetAll().ToList().OrderByDescending(x => x.MissedPaymentCount).First();
            if (missedPaymentCount > maxMissedPaymentCount.MissedPaymentCount)
            {
                return this.repository.Get(x => maxMissedPaymentCount.MissedPaymentCount == x.MissedPaymentCount);
            }

            var missedPayment = this.repository.Get(x => missedPaymentCount == x.MissedPaymentCount);

            if (null == missedPayment) { return new MissedPayment(); }
            return missedPayment;
        }
    }
}
