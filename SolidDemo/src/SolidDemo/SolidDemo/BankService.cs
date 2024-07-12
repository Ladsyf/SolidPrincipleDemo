

using SolidDemo.Accounts;
using SolidDemo.Loans;
using SolidDemo.Validations;

namespace SolidDemo;

internal class BankService : IBankService
{

    private readonly ILoggingService _loggingService;
    private readonly IDictionary<AccountType, IAccountValidation> _accountValidations;

    public BankService(ILoggingService loggingService, IEnumerable<IAccountValidation> accountValidations)
    {
        _loggingService = loggingService;
        _accountValidations = accountValidations.ToDictionary(x => x.AccountType, y => y);
    }
    
    public void Withdraw(Customer customer, int accountId, decimal amount, Currency currency = Currency.Peso)
    {
        var account = customer.GetAccount(accountId);
        amount = ConvertCurrency(account, amount, currency);
        Withdraw(amount, account);
    }

    public void Deposit(Customer customer, int accountId, decimal amount, Currency currency = Currency.Peso)
    {
        var account = customer.GetAccount(accountId);
        amount = ConvertCurrency(account, amount, currency);
        
        account.Deposit(amount);

        _loggingService.LogMessage($"New {account.AccountType} balance : {account.Balance:n}");
    }

    private void Withdraw(decimal amount, IAccount account)
    {
        if (!_accountValidations.TryGetValue(account.AccountType, out var accountValidation))
            throw new ArgumentException("Account type {account} is not Valid");

        if (accountValidation.IsValid(account, amount))
        {
            account.Withdraw(amount);
            _loggingService.LogMessage($"Withdrawal of {amount:n}   successful. New balance: {account.Balance:n}");
        }
        else
        {
            if (account is ITimeDepositAccount timeDeposit)
                LogTimeDepositError(timeDeposit);
            else
                _loggingService.LogMessage("Withdrawal failed. Check the amount and balance.");
        }
    }

    public void GetAllLoans(Customer customer)
    {
        foreach (var loan in customer.Loans)
        {
            var loanDetails = loan.GetLoanDetails();
            _loggingService.LogMessage($"{loanDetails} \n\n\n");
        }
    }

    private decimal ConvertCurrency(IAccount account, decimal amount, Currency currency)
    {
        if (account is IForeignAccount foreignAccount)
        {
            if (currency != foreignAccount.AccountCurrency)
                return foreignAccount.PesoToForeign(amount);
        }
        return amount;
    }

    private void LogTimeDepositError(ITimeDepositAccount timeDeposit)
    {
        if (!timeDeposit.IsMatured())
            _loggingService.LogMessage("Time Deposit account did not reach maturity date");
    }
}