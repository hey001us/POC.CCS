namespace POC.CCS.Services
{
    using POC.CCS.Models;
    using System.Collections.Generic;

    public interface ICompletedPaymentService
    {
        CompletedPayment GetCompletedPayment(int completedPaymentCount);
    }
}
