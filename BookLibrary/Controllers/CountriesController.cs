using BookLibrary.Services.Models;
using BookLibrary.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // GET: api/<CountriesController>
        [HttpGet]
        public IEnumerable<CountryModel> Get()
        {
            IEnumerable<CountryModel> result = _countryService.GetCountries();
            return result;
        }

        // GET api/<CountriesController>/5
        [HttpGet("{id}")]
        public CountryModel Get(int id)
        {
            CountryModel countryModel = _countryService.GetCountryById(id);
            return countryModel;
        }

        // POST api/<CountriesController>
        [HttpPost]
        public void Post([FromBody] CountryModel value)
        {
            _countryService.CreateCountry(value);
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CountryModel value)
        {
            _countryService.UpdateCountry(value, id);
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _countryService.DeleteCountry(id);
        }
    }
}
