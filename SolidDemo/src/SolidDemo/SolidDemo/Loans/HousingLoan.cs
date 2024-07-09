using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.Loans
{
    internal class HousingLoan : Loan
    {
        private const double _interestRate = 0.07;

        public HousingLoan(decimal amount, int duration) : base(amount, duration, _interestRate)
        {

        }

        public LoanType LoanType => LoanType.Housing;

        public void DisplayLoadDetails()
        { 
            
        }
    }
}
