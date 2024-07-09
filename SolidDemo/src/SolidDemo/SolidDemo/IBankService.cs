using SolidDemo.Accounts;

namespace SolidDemo;

internal interface IBankService
{
    void Withdraw(Customer customer, int accountId, decimal amount);
    void Withdraw(Customer customer, int accountId, decimal amount, Currency currency);
}