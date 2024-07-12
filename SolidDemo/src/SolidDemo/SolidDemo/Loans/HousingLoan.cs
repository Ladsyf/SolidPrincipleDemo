using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.Loans
{
    internal class HousingLoan : Loan, ILoan
    {
        private const double _interestRate = 0.07;

        public HousingLoan(decimal amount, int duration) : base(amount, duration, _interestRate)
        {

        }

        public LoanType LoanType => LoanType.Housing;

        public string GetLoanDetails()
        {
            return $"Loan Type: {LoanType} \n Total Payment: {CalculateTotalPayment()}";
        }
    }
}
