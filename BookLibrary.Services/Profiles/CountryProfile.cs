using AutoMapper;
using BookLibrary.DAL.Entities;
using BookLibrary.Services.Models;

namespace BookLibrary.Services.Profiles
{
    class CountryProfile: Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryModel>().ReverseMap();
        }
    }
}
