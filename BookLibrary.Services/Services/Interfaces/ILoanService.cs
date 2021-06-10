using BookLibrary.Services.Models;
using System.Collections.Generic;

namespace BookLibrary.Services.Services.Interfaces
{
    public interface ILoanService
    {
        public void CreateLoan(LoanModel loanToAdd);
        public void UpdateLoan(LoanModel loan, int loanId);
        public void DeleteLoan(int loanId);

        public List<LoanModel> GetLoans();
        public LoanModel GetLoanById(int id);
    }
}
