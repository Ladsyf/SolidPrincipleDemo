using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.Loans
{
    internal class PersonalLoan : Loan
    {
        private const double _interestRate = 0.02;
        private string _purpose {  get; set; }
        public PersonalLoan(decimal amount, int duration, string purpose) : base(amount, duration, _interestRate)
        {
            _purpose = purpose;
        }

        public LoanType LoanType => LoanType.Personal;

        public override void DisplayLoanDetails(ILoggingService loggingService)
        {
        }
    }
}
