using BookLibrary.DAL.Entities;
using BookLibrary.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.DAL.Repositories.Implementations
{
    public class CountryRepository: ICountryRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;
        private readonly ILogger<CountryRepository> _logger;

        public CountryRepository(BibliotecaContext bibliotecaContext, ILogger<CountryRepository> logger)
        {
            _bibliotecaContext = bibliotecaContext;
            _logger = logger;
        }

        public void CreateCountry(Country countryToAdd)
        {
            try
            {
                if (countryToAdd != null)
                {
                    _bibliotecaContext.Add(countryToAdd);
                    _bibliotecaContext.SaveChanges();
                }
                else throw new ArgumentNullException();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the action");
            }
        }
        public void UpdateCountry(Country country, int countryId)
        {
            try
            {
                Country updateCountry = _bibliotecaContext.Countries.Find(countryId);

                if (updateCountry == null)
                    throw new ArgumentException();
                if (updateCountry.Name != null)
                    updateCountry.Name = country.Name;
                if (updateCountry.TotalPopulation != null)
                    updateCountry.TotalPopulation = country.TotalPopulation;
                _bibliotecaContext.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the changes");
            }
        }

        public void DeleteCountry(int countryId)
        {
            try
            {
                Country countryToDelete = _bibliotecaContext.Countries.Find(countryId);
                if (countryToDelete == null)
                    throw new ArgumentNullException();
                _bibliotecaContext.Remove(countryToDelete);
                _bibliotecaContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the action");
            }
        }

        public Country GetCountryById(int id)
        {
            _logger.LogInformation($"Getting country By Id");
            return _bibliotecaContext.Countries.FirstOrDefault(b => b.Id == id);
        }

        public List<Country> GetCountries()
        {
            _logger.LogInformation($"Getting all countries");
            return _bibliotecaContext.Countries.ToList();
        }
    }
}
