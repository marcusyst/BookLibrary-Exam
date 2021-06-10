using AutoMapper;
using BookLibrary.DAL.Entities;
using BookLibrary.Services.Models;

namespace BookLibrary.Services.Profiles
{
    class LoanProfile: Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanModel>().ReverseMap();
        }
    }
}
