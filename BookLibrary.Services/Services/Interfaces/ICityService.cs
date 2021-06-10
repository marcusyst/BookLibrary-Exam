using BookLibrary.Services.Models;
using System.Collections.Generic;

namespace BookLibrary.Services.Services.Interfaces
{
    public interface ICityService
    {
        public void CreateCity(CityModel cityToAdd);
        public void UpdateCity(CityModel city, int cityId);
        public void DeleteCity(int cityId);

        public List<CityModel> GetCities();
        public CityModel GetCityById(int id);
    }
}
