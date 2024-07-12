using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.Loans
{
    internal abstract class Loan
    {
        private double _interestRate { get; set; }
        private decimal _amount { get; set; }
        private int _duration { get; set; }

        public Loan(decimal amount, int duration, double interestRate)
        {
            _interestRate = interestRate;
            _amount = amount;   
            _duration = duration;
        }

        protected decimal CalculateTotalPayment()
        {
            return _amount * (decimal)Math.Pow(1 + _interestRate, _duration);
        }
    }
}
