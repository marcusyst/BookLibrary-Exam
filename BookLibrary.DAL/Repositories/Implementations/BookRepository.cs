using BookLibrary.DAL.Entities;
using BookLibrary.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.DAL.Repositories.Implementations
{
    public class BookRepository: IBookRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(BibliotecaContext bibliotecaContext, ILogger<BookRepository> logger)
        {
            _bibliotecaContext = bibliotecaContext;
            _logger = logger;
        }

        public void CreateBook(Book bookToAdd)
        {
            try
            {
                if (bookToAdd != null)
                {
                    _bibliotecaContext.Add(bookToAdd);
                    _bibliotecaContext.SaveChanges();
                }
                else throw new ArgumentNullException();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the action");
            }
        }
        public void UpdateBook(Book book, int bookId)
        {
            try
            {
                Book updateBook = _bibliotecaContext.Books.Find(bookId);

                if (updateBook == null)
                    throw new ArgumentException();
                if (updateBook.Title != null)
                    updateBook.Title = book.Title;
                if (updateBook.Author != null)
                    updateBook.Author = book.Author;
                if (updateBook.Date != null)
                    updateBook.Date = book.Date;
                if (updateBook.StockLevel != null)
                    updateBook.StockLevel = book.StockLevel;
                _bibliotecaContext.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the changes");
            }
        }

        public void DeleteBook(int bookId)
        {
            try
            {
                var bookToDelete = _bibliotecaContext.Books.Find(bookId);
                if (bookToDelete == null)
                    throw new ArgumentNullException();
                _bibliotecaContext.Remove(bookToDelete);
                _bibliotecaContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n Impossible to perform the action");
            }
        }

        public Book GetBookById(int id)
        {
            _logger.LogInformation($"Getting book By Id");
            return _bibliotecaContext.Books.FirstOrDefault(b => b.Id == id);
        }

        public List<Book> GetBooks()
        {
            _logger.LogInformation($"Getting all Books");
            return _bibliotecaContext.Books.ToList();
        }

       
    }
}
