using SolidDemo.Accounts;
using SolidDemo.Loans;
using System.Collections.Generic;
namespace SolidDemo;

internal class Customer(int customerId, string name, IReadOnlyList<IAccount> accounts, IReadOnlyList<ILoan> loans)
{
    public int CustomerId { get; } = customerId;

    public string Name { get; } = name;

    public IReadOnlyList<ILoan> Loans = loans;

    public IReadOnlyList<IAccount> Accounts { get; } = accounts;

    public IAccount GetAccount(int accountId) => Accounts.First(a => a.AccountId == accountId);
}

