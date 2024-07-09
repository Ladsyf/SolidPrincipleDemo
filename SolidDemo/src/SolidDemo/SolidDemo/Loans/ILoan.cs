namespace SolidDemo.Loans
{
    internal interface ILoan
    {
        LoanType LoanType { get; set; }
        decimal CalculateTotalPayment();
        void DisplayLoanDetails();
    }
}