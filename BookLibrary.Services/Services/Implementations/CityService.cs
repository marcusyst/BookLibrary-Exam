using AutoMapper;
using BookLibrary.DAL.Entities;
using BookLibrary.DAL.Repositories.Interfaces;
using BookLibrary.Services.Models;
using BookLibrary.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Services.Services.Implementations
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public void CreateCity(CityModel cityToAdd)
        {
            City city = _mapper.Map<City>(cityToAdd);
            _cityRepository.CreateCity(city);
        }

        public void UpdateCity(CityModel cityModel, int cityId)
        {
            City city = _mapper.Map<City>(cityModel);
            _cityRepository.UpdateCity(city, cityId);
        }

        public void DeleteCity(int cityId)
        {
            _cityRepository.DeleteCity(cityId);
        }

        public CityModel GetCityById(int id)
        {
            City city = _cityRepository.GetCityById(id);
            CityModel bookModel = _mapper.Map<CityModel>(city);
            return bookModel;
        }

        public List<CityModel> GetCities()
        {
            List<City> cities = _cityRepository.GetCities();
            List<CityModel> cityModels = _mapper.Map<List<CityModel>>(cities);
            return cityModels;
        }

        
    }
}
