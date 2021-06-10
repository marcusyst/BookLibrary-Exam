using AutoMapper;
using BookLibrary.DAL.Entities;
using BookLibrary.DAL.Repositories.Interfaces;
using BookLibrary.Services.Models;
using BookLibrary.Services.Services.Interfaces;
using System.Collections.Generic;

namespace BookLibrary.Services.Services.Implementations
{
    public class LoanService: ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public LoanService(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        public void CreateLoan(LoanModel loanToAdd)
        {
            Loan loan = _mapper.Map<Loan>(loanToAdd);
            _loanRepository.CreateLoan(loan);
        }

        public void UpdateLoan(LoanModel loanModel, int loanId)
        {
            Loan loan = _mapper.Map<Loan>(loanModel);
            _loanRepository.UpdateLoan(loan, loanId);
        }

        public void DeleteLoan(int loanId)
        {
            _loanRepository.DeleteLoan(loanId);
        }

        public LoanModel GetLoanById(int id)
        {
            Loan loan = _loanRepository.GetLoanById(id);
            LoanModel loanModel = _mapper.Map<LoanModel>(loan);
            return loanModel;
        }

        public List<LoanModel> GetLoans()
        {
            List<Loan> loans = _loanRepository.GetLoans();
            List<LoanModel> loanModels = _mapper.Map<List<LoanModel>>(loans);
            return loanModels;
        }
    }
}
