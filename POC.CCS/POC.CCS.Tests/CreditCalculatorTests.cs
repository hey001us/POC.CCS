namespace POC.CCS.Tests
{
    using FakeItEasy;
    using POC.CCS.Calculators.Interface;
    using POC.CCS.Models;
    using System;
    using Xunit;
    using FluentAssertions;
    using POC.CCS.Services;
    using POC.CCS.Calculators.Implementation;

    public class CreditCalculatorTests
    {
        private readonly CreditCalculator _sut;
        private readonly IBureauScoreService bureauScoreService;
        private readonly IMissedPaymentService missedPaymentService;
        private readonly ICompletedPaymentService completedPaymentService;
        private readonly IAvailableCreditService availableCreditService;
        private readonly IAgeThresholdCreditService ageThresholdCreditService;

        public CreditCalculatorTests()
        {
            bureauScoreService = A.Fake<IBureauScoreService>();
            missedPaymentService = A.Fake<IMissedPaymentService>();
            completedPaymentService = A.Fake<ICompletedPaymentService>();
            availableCreditService = A.Fake<IAvailableCreditService>();
            ageThresholdCreditService = A.Fake<IAgeThresholdCreditService>();
            _sut = new CreditCalculator(bureauScoreService,
                missedPaymentService,
                completedPaymentService,
                availableCreditService,
                ageThresholdCreditService);
        }

        [Fact]
        public void CalculateCreditReturnsValidCredit()
        {
            // Assing
            var cutomer = new Customer(750, 1, 4, 29);

            // Act
            var acutal = _sut.CalculateCredit(cutomer);

            // Assert
            acutal.Should().Be(400);
        }
    }
}
