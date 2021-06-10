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
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<BookModel> Get()
        {
            IEnumerable<BookModel> result = _bookService.GetBooks();
            return result;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public BookModel Get(int id)
        {
            BookModel result = _bookService.GetBookById(id);
            return result;
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] BookModel value)
        {
            _bookService.CreateBook(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BookModel value)
        {
            _bookService.UpdateBook(value, id);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bookService.DeleteBook(id);
        }
    }
}
