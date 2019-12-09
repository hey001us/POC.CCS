namespace POC.CCS.Services
{
    using POC.CCS.Models;
    using System.Collections.Generic;

    public interface IMissedPaymentService
    {
        MissedPayment GetMissedPayment(int missedPaymentCount);
    }
}
