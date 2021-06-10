using BookLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL.Repositories.Interfaces
{
    public interface ICityRepository
    {
        public void CreateCity(City blogToAdd);
        public void UpdateCity(City blog, int blogId);
        public void DeleteCity(int blogId);

        public List<City> GetCities();
        public City GetCityById(int id);

    }
}
