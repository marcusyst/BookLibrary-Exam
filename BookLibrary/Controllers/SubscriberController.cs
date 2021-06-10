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
    public class SubscriberController : ControllerBase
    {
        private readonly ISubscriberService _subscriberService;

        public SubscriberController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        // GET: api/<SubscriberController>
        [HttpGet]
        public IEnumerable<SubscriberModel> Get()
        {
            IEnumerable<SubscriberModel> result = _subscriberService.GetSubscribers();
            return result;
        }

        // GET api/<SubscriberController>/5
        [HttpGet("{id}")]
        public SubscriberModel Get(int id)
        {
            SubscriberModel subscriberModel = _subscriberService.GetSubscriberById(id);
            return subscriberModel;
        }

        // POST api/<SubscriberController>
        [HttpPost]
        public void Post([FromBody] SubscriberModel value)
        {
            _subscriberService.CreateSubscriber(value);
        }

        // PUT api/<SubscriberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SubscriberModel value)
        {
            _subscriberService.UpdateSubscriber(value, id);
        }

        // DELETE api/<SubscriberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _subscriberService.DeleteSubscriber(id);
        }
    }
}
