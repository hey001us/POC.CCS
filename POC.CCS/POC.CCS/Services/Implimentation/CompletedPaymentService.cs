namespace POC.CCS.Services.Implimentation
{
    using System.Linq;
    using POC.CCS.Data.Interface;
    using POC.CCS.Models;

    public class CompletedPaymentService : ICompletedPaymentService
    {
        private readonly ICompletedPaymentRepository repository;

        public CompletedPaymentService(ICompletedPaymentRepository repository)
        {
            this.repository = repository;
        }

        public CompletedPayment GetCompletedPayment(int completedPaymentCount)
        {

            var maxCompletedPayment = this.repository.GetAll().ToList().Max(x => x.CompletedPaymentCount);
            if (completedPaymentCount > maxCompletedPayment)
            { 
                return this.repository.Get(x => maxCompletedPayment == x.CompletedPaymentCount);
            }

            var completedPayment = this.repository.Get(x => completedPaymentCount == x.CompletedPaymentCount);

            if (null == completedPayment) { return new CompletedPayment(); }
            return completedPayment;
        }
    }
}
