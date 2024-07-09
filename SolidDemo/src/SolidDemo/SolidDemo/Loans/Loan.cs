using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.Loans
{
    internal abstract class Loan : ILoan
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

        public LoanType LoanType { get; set; }

        protected decimal CalculateTotalPayment()
        {
            return _amount * (decimal)Math.Pow(1 + _interestRate, _duration);
            // _amount * (1 + _interestRate) ^ (_duration / 12)
        }

        public void DisplayLoanDetails()
        { 
            DisplayAdditionalDetails();
        }

        public abstract void DisplayAdditionalDetails();
    }
}
