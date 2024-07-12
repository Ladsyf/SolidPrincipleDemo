using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Accounts
{
    internal abstract class ForeignAccount : Account
    {
        private decimal _conversionRate { get; }

        private const decimal _chargeRate = 0.02m;

        public ForeignAccount(int accountId, decimal balance, decimal conversionRate) : base(accountId, balance)
        {
            _conversionRate = conversionRate;
        }

        public decimal PesoToForeign(decimal amount)
        {
            return amount / _conversionRate;
        }
        public decimal ForeignToPeso(decimal amount)
        {
            return amount * _conversionRate;
        }

        public override void Deposit(decimal amount)
        {
            var charge = amount * _chargeRate;
            base.Deposit(amount - charge);
        }
    }
}
