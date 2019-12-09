namespace POC.CCS.Services.Implimentation
{
    using System.Linq;
    using POC.CCS.Data.Interface;
    using POC.CCS.Models;

    public class AvailableCreditService : IAvailableCreditService
    {
        private readonly IAvailableCreditRepository repository;

        public AvailableCreditService(IAvailableCreditRepository repository)
        {
            this.repository = repository;
        }

        public AvailableCredit GetAvailableCredite(int points)
        {
            if (points < 0) { return new AvailableCredit { TotalPoints = 0, ObtainableCredit = 0 }; }

            var maxTotalPoints = this.repository.GetAll().ToList().Max(x => x.TotalPoints);
            if (points > maxTotalPoints)
            {
                return this.repository.Get(x => maxTotalPoints == x.TotalPoints);
            }

            var availableCredit =  this.repository.Get(x => points == x.TotalPoints);

            if (null == availableCredit) { return new AvailableCredit(); }
            return availableCredit;
        }

    }
}
