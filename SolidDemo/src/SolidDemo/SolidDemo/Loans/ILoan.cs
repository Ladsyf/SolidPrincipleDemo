namespace SolidDemo.Loans
{
    internal interface ILoan
    {
        LoanType LoanType { get; }
        string GetLoanDetails();
    }
}