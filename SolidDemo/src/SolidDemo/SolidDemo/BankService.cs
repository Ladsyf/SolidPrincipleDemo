

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
    
    public void Withdraw(Customer customer, int accountId, decimal amount)
    {
        var account = customer.GetAccount(accountId);

        if (!_accountValidations.TryGetValue(account.AccountType, out var accountValidation))
            throw new ArgumentException("Account type {account} is not Valid");

        if (accountValidation.IsValid(account, amount))
        {
            account.Withdraw(amount);
            _loggingService.LogMessage($"Withdrawal of {amount} successful. New balance: {account.Balance}");
        }
        else
        {
            if (account is ITimeDepositAccount timeDeposit)
                LogTimeDepositError(timeDeposit);
            else
                _loggingService.LogMessage("Withdrawal failed. Check the amount and balance.");
        }
    }

    public void Withdraw(Customer customer, int accountId, decimal amount, Currency currency)
    {
        var account = customer.GetAccount(accountId);
        amount = ConvertCurrency(account, amount, currency);

        if (!_accountValidations.TryGetValue(account.AccountType, out var accountValidation))
            throw new ArgumentException("Account type {account} is not Valid");

        if (accountValidation.IsValid(account, amount))
        {
            account.Withdraw(amount);
            _loggingService.LogMessage($"Withdrawal of {amount} successful. New balance: {account.Balance}");
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
            var totalAmountToPay = loan.CalculateTotalPayment();
            _loggingService.LogMessage($"Total Payable Amount: {totalAmountToPay:n}");
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