namespace POC.CCS.Services
{
    using POC.CCS.Models;

    public interface IAgeThresholdCreditService
    {
         AgeThresholdCredit GetAgeThresholdCredit(int age);
    }
}
