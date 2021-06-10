using BookLibrary.DAL.Entities;
using BookLibrary.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.DAL.Repositories.Implementations
{
    public class CityRepository: ICityRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;
        private readonly ILogger<CityRepository> _logger;

        public CityRepository(BibliotecaContext bibliotecaContext, ILogger<CityRepository> logger)
        {
            _bibliotecaContext = bibliotecaContext;
            _logger = logger;
        }

        public void CreateCity(City cityToAdd)
        {
            try
            {
                if (cityToAdd != null)
                {
                    _bibliotecaContext.Add(cityToAdd);
                    _bibliotecaContext.SaveChanges();
                }
                else throw new ArgumentNullException();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the action");
            }
        }
        public void UpdateCity(City city, int cityId)
        {
            try
            {
                City updateCity = _bibliotecaContext.Cities.Find(cityId);

                if (updateCity == null)
                    throw new ArgumentException();
                if (updateCity.Name != null)
                    updateCity.Name = city.Name;
                _bibliotecaContext.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the changes");
            }
        }

        public void DeleteCity(int cityId)
        {
            try
            {
                var cityToDelete = _bibliotecaContext.Cities.Find(cityId);
                if (cityToDelete == null)
                    throw new ArgumentNullException();
                _bibliotecaContext.Remove(cityToDelete);
                _bibliotecaContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the action");
            }
        }

        public City GetCityById(int id)
        {
            _logger.LogInformation($"Getting city By Id");
            return _bibliotecaContext.Cities.FirstOrDefault(b => b.Id == id);
        }

        public List<City> GetCities()
        {
            _logger.LogInformation($"Getting all cities");
            return _bibliotecaContext.Cities.ToList();
        }
    }
}
