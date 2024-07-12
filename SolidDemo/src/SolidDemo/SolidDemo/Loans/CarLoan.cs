using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.Loans
{
    internal class CarLoan : Loan, ILoan
    {
        private const double _interestRate = 0.05;
        private string _carModel { get; set; }
        public CarLoan(decimal amount, int duration, string carModel) : base(amount, duration, _interestRate)
        {
            _carModel = carModel;
        }

        public LoanType LoanType => LoanType.Car;

        public string GetLoanDetails()
        {
            return $"Loan Type: {LoanType}\n Car Model: {_carModel} \n Total Payment: {CalculateTotalPayment()}";
        }
    }
}
