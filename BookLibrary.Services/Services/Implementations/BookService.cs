using AutoMapper;
using BookLibrary.DAL.Entities;
using BookLibrary.DAL.Repositories.Interfaces;
using BookLibrary.Services.Models;
using BookLibrary.Services.Services.Interfaces;
using System.Collections.Generic;

namespace BookLibrary.Services.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public void CreateBook(BookModel bookToAdd)
        {
            Book book = _mapper.Map<Book>(bookToAdd);
            _bookRepository.CreateBook(book);
        }

        public void UpdateBook(BookModel bookModel, int bookId)
        {
            Book book = _mapper.Map<Book>(bookModel);
            _bookRepository.UpdateBook(book, bookId);
        }

        public void DeleteBook(int bookId)
        {
            _bookRepository.DeleteBook(bookId);
        }

        public BookModel GetBookById(int id)
        {
            Book book = _bookRepository.GetBookById(id);
            BookModel bookModel = _mapper.Map<BookModel>(book);
            return bookModel;
        }

        public List<BookModel> GetBooks()
        {
            List<Book> books = _bookRepository.GetBooks();
            List<BookModel> bookModels = _mapper.Map<List<BookModel>>(books);
            return bookModels;
        }

        
    }
}
