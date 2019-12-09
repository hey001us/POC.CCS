namespace POC.CCS.Calculators.Implementation
{
    using POC.CCS.Calculators.Interface;
    using POC.CCS.Models;
    using POC.CCS.Services;

    public class CreditCalculator : ICreditCalculator
    {
        private readonly IBureauScoreService bureauScoreService;
        private readonly IMissedPaymentService missedPaymentService;
        private readonly ICompletedPaymentService completedPaymentService;
        private readonly IAvailableCreditService availableCreditService;
        private readonly IAgeThresholdCreditService ageThresholdCreditService;

        public CreditCalculator(IBureauScoreService bureauScoreService
                                , IMissedPaymentService missedPaymentService
                                , ICompletedPaymentService completedPaymentService
                                , IAvailableCreditService availableCreditService
                                , IAgeThresholdCreditService ageThresholdCreditService
                                )
        {
            this.bureauScoreService = bureauScoreService;
            this.missedPaymentService = missedPaymentService;
            this.completedPaymentService = completedPaymentService;
            this.availableCreditService = availableCreditService;
            this.ageThresholdCreditService = ageThresholdCreditService;

        }

        public decimal CalculateCredit(Customer customer)
        {
            var totalPoints = CalculateAgeCreditPoints(customer);
            var availableCredite = this.availableCreditService.GetAvailableCredite(totalPoints);

            return availableCredite.ObtainableCredit;
        }

        private int CalculateAgeCreditPoints(Customer customer)
        {
            var bs = this.bureauScoreService.GetBureauScore(customer.BureauScore);
            var mp = this.missedPaymentService.GetMissedPayment(customer.MissedPaymentCount);
            var cp = this.completedPaymentService.GetCompletedPayment(customer.CompletedPaymentCount);

            var totalPoints = (bs.Points + mp.Points + cp.Points);
            var ageThresholdPoints = this.ageThresholdCreditService.GetAgeThresholdCredit(customer.AgeInYears);

            if (totalPoints > ageThresholdPoints.MaximumPoints)
            {
                return ageThresholdPoints.MaximumPoints;
            }
            return totalPoints;
        }
    }
}
