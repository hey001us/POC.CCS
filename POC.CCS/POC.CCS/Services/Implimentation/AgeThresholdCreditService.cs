﻿namespace POC.CCS.Services.Implimentation
{
    using System.Linq;
    using POC.CCS.Data.Interface;
    using POC.CCS.Models;

    public class AgeThresholdCreditService : IAgeThresholdCreditService
    {
        private readonly IAgeThresholdCreditRepository repository;

        public AgeThresholdCreditService(IAgeThresholdCreditRepository repository)
        {
            this.repository = repository;
        }

        public AgeThresholdCredit GetAgeThresholdCredit(int age)
        {
            var minAge = this.repository.GetAll().ToList().Min(x => x.StartAge);

            if (age < minAge)
            {
                return new AgeThresholdCredit { MaximumPoints = 0 };
            }

            var ageThresholdCredit = this.repository.Get(x => age >= x.StartAge && age <= x.EndAge);

            if (null == ageThresholdCredit) { return new AgeThresholdCredit(); }
            return ageThresholdCredit;
        }
    }
}
