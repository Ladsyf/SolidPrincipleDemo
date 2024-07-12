using SolidDemo.Loans;

namespace SolidDemo.Accounts;

internal abstract class Account(int accountId, decimal balance)
{
    public int AccountId { get; } = accountId;

    public decimal Balance { get; set; } = balance;

    public virtual void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount) => Balance -= amount;

}
