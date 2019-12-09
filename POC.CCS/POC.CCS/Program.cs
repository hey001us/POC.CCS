namespace POC.CCS
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using POC.CCS.Data.Interface;
    using POC.CCS.Data.Implementation;
    using POC.CCS.Calculators.Interface;
    using POC.CCS.Calculators.Implementation;
    using POC.CCS.Services;
    using POC.CCS.Services.Implimentation;
    using POC.CCS.Models;

    class Program
    {
        static void Main(string[] args)
        {
            // Setup DI
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

            var creditCalculator = serviceProvider.GetService<ICreditCalculator>();

            var customer = new Customer(750, 1, 4, 29);


            var credit = creditCalculator.CalculateCredit(customer);

            Console.WriteLine($"Hello World! {credit}");

            Console.ReadLine();
        }
    }
}
