using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Accounts
{
    enum Currency { 
        peso,
        usdollar,
    }
    internal class DollarAccount(int accountId, decimal balance) : Account(accountId, balance), IForeignAccount
    {
        private const decimal _conversionRate = 0.017m;
        public decimal PesoToForeign(decimal amount) 
        {
            return amount * _conversionRate;
        }
        public decimal ForeignToPeso(decimal amount)
        {
            return amount/_conversionRate;
        }
        public AccountType AccountType => AccountType.Dollar;

        public Currency AccountCurrency => Currency.usdollar;

        //public void Withdraw(decimal amount, Currency currency) 
        //{
        //    switch (currency) { 
        //        case Currency.peso:
        //            amount = PesoToDollarRate * amount;
        //            Balance -= amount;
        //            break;
        //        case Currency.usdollar:
        //        default:
        //            Balance -= amount; 
        //            break;
        //    }
        //};

        //public override void Deposit(decimal amount)
        //{
        //    var depositCharge = (amount * 0.02);
        //    amount -= depositCharge;

        //    Balance += amount;
        //}
    }
}
