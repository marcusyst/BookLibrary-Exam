using BookLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        public void CreateLoan(Loan blogToAdd);
        public void UpdateLoan(Loan blog, int blogId);
        public void DeleteLoan(int blogId);

        public List<Loan> GetLoans();
        public Loan GetLoanById(int id);

    }
}
