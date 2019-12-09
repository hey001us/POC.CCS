namespace POC.CCS.Services
{
    using POC.CCS.Models;
    using System.Collections.Generic;

    public interface IAvailableCreditService
    {
        AvailableCredit GetAvailableCredite(int points);
    }
}
