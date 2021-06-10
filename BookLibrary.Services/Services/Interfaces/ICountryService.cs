using BookLibrary.Services.Models;
using System.Collections.Generic;

namespace BookLibrary.Services.Services.Interfaces
{
    public interface ICountryService
    {
        public void CreateCountry(CountryModel countryToAdd);
        public void UpdateCountry(CountryModel country, int countryId);
        public void DeleteCountry(int countryId);
        public List<CountryModel> GetCountries();
        public CountryModel GetCountryById(int id);
    }
}
