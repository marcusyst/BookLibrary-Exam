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
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/<CitiesController>
        [HttpGet]
        public IEnumerable<CityModel> Get()
        {
            IEnumerable<CityModel> result = _cityService.GetCities();
            return result;
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        public CityModel Get(int id)
        {
            CityModel loanModel = _cityService.GetCityById(id);
            return loanModel;
        }

        // POST api/<CitiesController>
        [HttpPost]
        public void Post([FromBody] CityModel value)
        {
            _cityService.CreateCity(value);
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CityModel value)
        {
            _cityService.UpdateCity(value, id);
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cityService.DeleteCity(id);
        }
    }
}
