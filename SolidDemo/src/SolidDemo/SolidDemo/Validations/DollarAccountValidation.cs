using SolidDemo.Accounts;

namespace SolidDemo.Validations;
internal class DollarAccountValidation : IAccountValidation
{
    public AccountType AccountType => AccountType.Dollar;

    public bool IsValid(IAccount account, decimal amount)
    {
        return !(amount <= 0 || amount > account.Balance);
    }
}
