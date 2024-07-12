using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Accounts
{
    internal class DollarAccount(int accountId, decimal balance) : ForeignAccount(accountId, balance, 58.4m), IForeignAccount
    {
        private const decimal _conversionRate = 0.017m;

        public AccountType AccountType => AccountType.USDollar;

        public Currency AccountCurrency => Currency.UsDollar;

    }
}
