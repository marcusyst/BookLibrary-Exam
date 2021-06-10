using BookLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        public void CreateCountry(Country blogToAdd);
        public void UpdateCountry(Country blog, int blogId);
        public void DeleteCountry(int blogId);

        public List<Country> GetCountries();
        public Country GetCountryById(int id);

    }
}
