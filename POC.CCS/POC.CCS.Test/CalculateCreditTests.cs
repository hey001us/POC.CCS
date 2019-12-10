namespace POC.CCS.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Extensions.DependencyInjection;
    using POC.CCS.Calculators.Interface;
    using POC.CCS.Data.Interface;
    using POC.CCS.Services;
    using POC.CCS.Data.Implementation;
    using POC.CCS.Services.Implimentation;
    using POC.CCS.Calculators.Implementation;
    using POC.CCS.Models;
    using FluentAssertions;

    [TestClass]
    public class CalculateCreditTests
    {
        private ICreditCalculator _sut;

        [TestInitialize]
        public void Init()
        {
            var serviceProvider = new ServiceCollection()
                                   .AddLogging()
                                   .AddSingleton<IBureauScoreRepository, BureauScoreRepository>()
                                   .AddSingleton<IMissedPaymentRepository, MissedPaymentRepository>()
                                   .AddSingleton<ICompletedPaymentRepository, CompletedPaymentRepository>()
                                   .AddSingleton<IAvailableCreditRepository, AvailableCreditRepository>()
                                   .AddSingleton<IAgeThresholdCreditRepository, AgeThresholdCreditRepository>()
                                   .AddSingleton<IBureauScoreService, BureauScoreService>()
                                   .AddSingleton<IMissedPaymentService, MissedPaymentService>()
                                   .AddSingleton<ICompletedPaymentService, CompletedPaymentService>()
                                   .AddSingleton<IAvailableCreditService, AvailableCreditService>()
                                   .AddSingleton<IAgeThresholdCreditService, AgeThresholdCreditService>()
                                   .AddSingleton<ICreditCalculator, CreditCalculator>()
                                   .BuildServiceProvider();

            _sut = serviceProvider.GetService<ICreditCalculator>();
        }

        [TestMethod]
        public void CalculateCredit_Returns_ValidCredit()
        {
            // Assing
            var cutomer = new Customer(750, 1, 4, 29);

            // Act
            var acutal = _sut.CalculateCredit(cutomer);

            // Assert
            acutal.Should().Be(400);
        }

        [TestMethod]
        public void CalculateCredit_Returns_ZeroCredit_For_UnderAge()
        {
            // Assing
            var cutomer = new Customer(750, 1, 4, 17);

            // Act
            var acutal = _sut.CalculateCredit(cutomer);

            // Assert
            acutal.Should().Be(0);
        }

        [TestMethod]
        public void CalculateCredit_Returns_ZeroCredit_For_OverAge()
        {
            // Assing
            var cutomer = new Customer(750, 1, 4, 90);

            // Act
            var acutal = _sut.CalculateCredit(cutomer);

            // Assert
            acutal.Should().Be(500);
        }

        [TestMethod]
        public void Completed_Payments_For_Zero()
        {
            // Assing
            var cutomer = new Customer(750, 1, 0, 27);

            // Act
            var acutal = _sut.CalculateCredit(cutomer);

            // Assert
            acutal.Should().Be(100);
        }

        [TestMethod]
        public void Completed_Payments_For_Greater_Than_Three()
        {
            // Assing
            var cutomer = new Customer(750, 1, 9, 27);

            // Act
            var acutal = _sut.CalculateCredit(cutomer);

            // Assert
            acutal.Should().Be(400);
        }

        [TestMethod]
        public void Missed_Payments_For_Zero_and_Max_Age_Point()
        {
            // Assing
            var cutomer = new Customer(750, 0, 3, 27);

            // Act
            var acutal = _sut.CalculateCredit(cutomer);

            // Assert
            acutal.Should().Be(400);
        }

        [TestMethod]
        public void Missed_Payments_For_Greater_Than_Three()
        {
            // Assing
            var cutomer = new Customer(750, 7, 4, 27);

            // Act
            var acutal = _sut.CalculateCredit(cutomer);

            // Assert
            acutal.Should().Be(0);
        }
    }
}
