using SolidDemo.Accounts;

namespace SolidDemo;

internal interface IBankService
{
    void Withdraw(Customer customer, int accountId, decimal amount, Currency currency = Currency.Peso);
    void Deposit(Customer customer, int accountId, decimal amount, Currency currency = Currency.Peso);
    void GetAllLoans(Customer customer);
}