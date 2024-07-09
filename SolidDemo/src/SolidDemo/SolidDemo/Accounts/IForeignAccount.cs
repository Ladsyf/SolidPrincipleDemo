namespace SolidDemo.Accounts
{
    internal interface IForeignAccount : IAccount
    {
        Currency AccountCurrency { get; }
        decimal PesoToForeign(decimal amount);
        decimal ForeignToPeso(decimal amount);
    }
}