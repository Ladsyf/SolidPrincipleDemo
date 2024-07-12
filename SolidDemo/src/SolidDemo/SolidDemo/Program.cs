using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using SolidDemo.Accounts;
using SolidDemo.Loans;
using SolidDemo.Validations;

namespace SolidDemo;

internal class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        ConfigureDependencies(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var bankService = serviceProvider.GetRequiredService<IBankService>();
        Account(bankService);
        //Loans(bankService);
    }

    private static void Account(IBankService bankService)
    {
        var savingsAccount = new SavingsAccount(1001, 500.00m);
        var currentAccount = new CurrentAccount(1002, 500.00m, 100m);
        var timeDepositAccount = new TimeDepositAccount(1003, 500m, DateTime.Today.Subtract(TimeSpan.FromDays(29)), 30);
        var dollarAccount = new DollarAccount(1004, 0);

        var customer = new Customer(1, "Juan Dela Cruz", new List<IAccount>
        {
            dollarAccount,
            savingsAccount,
            currentAccount,
            timeDepositAccount,
        }, new List<ILoan>());

        bankService.Withdraw(customer, 1001, 100.00m);
        bankService.Withdraw(customer, 1002, 600.00m);
        bankService.Withdraw(customer, 1003, 1000.00m);

        //bankService.Withdraw(customer, 1004, 500.00m, Currency.Peso);
        //user will withdraw currency dollar in dollar account
        bankService.Withdraw(customer, 1004, 600.00m, Currency.UsDollar);


        bankService.Deposit(customer, 1004, 1000);
        bankService.Deposit(customer, 1004, 100, Currency.UsDollar);
    }

    private static void Loans(IBankService bankService)
    {
        var carLoan = new CarLoan(500000m, 5, "Toyota");
        var personalLoan = new PersonalLoan(500000m, 5, "Secret hehe");
        var housingLoan = new HousingLoan(500000m, 5);

        var customer = new Customer(1, "Juan Dela Cruz", new List<IAccount>{}, new List<ILoan> { carLoan, personalLoan, housingLoan });

        bankService.GetAllLoans(customer);
    }

    private static void ConfigureDependencies(ServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ILoggingService, LoggingService>();
        serviceCollection.AddScoped<IBankService, BankService>();
        serviceCollection.AddScoped<IAccountValidation, SavingsAccountValidation>();
        serviceCollection.AddScoped<IAccountValidation, CurrentAccountValidation>();
        serviceCollection.AddScoped<IAccountValidation, TimeDepositValidation>();
        serviceCollection.AddScoped<IAccountValidation, DollarAccountValidation>();
    }
}


