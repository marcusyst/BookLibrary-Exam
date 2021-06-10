using AutoMapper;
using BookLibrary.DAL.Entities;
using BookLibrary.Services.Models;

namespace BookLibrary.Services.Profiles
{
    class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();
       

        }
    }
}
