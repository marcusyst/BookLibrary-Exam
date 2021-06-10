using BookLibrary.DAL.Entities;
using BookLibrary.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.DAL.Repositories.Implementations
{
    public class LoanRepository: ILoanRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;
        private readonly ILogger<LoanRepository> _logger;

        public LoanRepository(BibliotecaContext bibliotecaContext, ILogger<LoanRepository> logger)
        {
            _bibliotecaContext = bibliotecaContext;
            _logger = logger;
        }

        public void CreateLoan(Loan loanToAdd)
        {
            try
            {
                if (loanToAdd != null)
                {
                    _bibliotecaContext.Add(loanToAdd);
                    _bibliotecaContext.SaveChanges();
                }
                else throw new ArgumentNullException();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the action");
            }
        }
        public void UpdateLoan(Loan loan, int loanId)
        {
            try
            {
                Loan updateLoan = _bibliotecaContext.Loans.Find(loanId);

                if (updateLoan == null)
                    throw new ArgumentException();
                if (updateLoan.RentDate != null)
                    updateLoan.RentDate = loan.RentDate;
                if (updateLoan.ReturnDate != null)
                    updateLoan.ReturnDate = loan.ReturnDate;
                _bibliotecaContext.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the changes");
            }
        }

        public void DeleteLoan(int cityId)
        {
            try
            {
                Loan loanToDelete = _bibliotecaContext.Loans.Find(cityId);
                if (loanToDelete == null)
                    throw new ArgumentNullException();
                _bibliotecaContext.Remove(loanToDelete);
                _bibliotecaContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the action");
            }
        }

        public Loan GetLoanById(int id)
        {
            _logger.LogInformation($"Getting city By Id");
            return _bibliotecaContext.Loans.FirstOrDefault(b => b.Id == id);
        }

        public List<Loan> GetLoans()
        {
            _logger.LogInformation($"Getting all cities");
            return _bibliotecaContext.Loans.ToList();
        }


    }
}
