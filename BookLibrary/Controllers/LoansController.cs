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
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        // GET: api/<LoansController>
        [HttpGet]
        public IEnumerable<LoanModel> Get()
        {
            IEnumerable<LoanModel> result = _loanService.GetLoans();
            return result;
        }

        // GET api/<LoansController>/5
        [HttpGet("{id}")]
        public LoanModel Get(int id)
        {
            LoanModel loanModel = _loanService.GetLoanById(id);
            return loanModel;
        }

        // POST api/<LoansController>
        [HttpPost]
        public void Post([FromBody] LoanModel value)
        {
            _loanService.CreateLoan(value);
        }

        // PUT api/<LoansController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LoanModel value)
        {
            _loanService.UpdateLoan(value, id);
        }

        // DELETE api/<LoansController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _loanService.DeleteLoan(id);
        }
    }
}
