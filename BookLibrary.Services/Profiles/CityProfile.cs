using AutoMapper;
using BookLibrary.DAL.Entities;
using BookLibrary.Services.Models;

namespace BookLibrary.Services.Profiles
{
    class CityProfile: Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityModel>().ReverseMap();
        }
    }
}
