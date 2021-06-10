using AutoMapper;
using BookLibrary.DAL.Entities;
using BookLibrary.DAL.Repositories.Interfaces;
using BookLibrary.Services.Models;
using BookLibrary.Services.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BookLibrary.Services.Services.Implementations
{
    public class CountryService: ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public void CreateCountry(CountryModel countryToAdd)
        {
            Country country = _mapper.Map<Country>(countryToAdd);
            _countryRepository.CreateCountry(country);
        }

        public void UpdateCountry(CountryModel countryModel, int countryId)
        {
            Country country = _mapper.Map<Country>(countryModel);
            _countryRepository.UpdateCountry(country, countryId);
        }

        public void DeleteCountry(int countryId)
        {
            _countryRepository.DeleteCountry(countryId);
        }

        public CountryModel GetCountryById(int id)
        {
            Country country = _countryRepository.GetCountryById(id);
            CountryModel countryModel = _mapper.Map<CountryModel>(country);
            return countryModel;
        }

        public List<CountryModel> GetCountries()
        {
            List<Country> coutries = _countryRepository.GetCountries();
            List<CountryModel> countryModels = _mapper.Map<List<CountryModel>>(coutries);

            return countryModels;
        }

        
    }
}
