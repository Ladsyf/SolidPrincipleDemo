﻿using Microsoft.Extensions.DependencyInjection;
using SolidDemo.Accounts;
using SolidDemo.Validations;

namespace SolidDemo;

internal class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddScoped<ILoggingService, LoggingService>();
        serviceCollection.AddScoped<IBankService, BankService>();  
        serviceCollection.AddScoped<IAccountValidation, SavingsAccountValidation>();
        serviceCollection.AddScoped<IAccountValidation, CurrentAccountValidation>();
        serviceCollection.AddScoped<IAccountValidation, TimeDepositValidation>();
        serviceCollection.AddScoped<IAccountValidation, DollarAccountValidation>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var bankService = serviceProvider.GetRequiredService<IBankService>();

        ///account (account no, balance)
        ///

        var savingsAccount = new SavingsAccount(1001, 500.00m);
        var currentAccount = new CurrentAccount(1002, 500.00m, 100m);
        var timeDepositAccount = new TimeDepositAccount(1003, 500m, DateTime.Today.Subtract(TimeSpan.FromDays(29)), 30);
        var dollarAccount = new DollarAccount(1004, 500.00m);


        var customer = new Customer(1, "Juan Dela Cruz", new List<IAccount>
        {
            dollarAccount,
            savingsAccount,
            currentAccount,
            timeDepositAccount,
        });


        bankService.Withdraw(customer, 1001, 100.00m);
        bankService.Withdraw(customer, 1002, 600.00m);
        bankService.Withdraw(customer, 1003, 1000.00m);
        bankService.Withdraw(customer, 1004, 500.00m, Currency.usdollar);
        Console.ReadLine();
    }
}