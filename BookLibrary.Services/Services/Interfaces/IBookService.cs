using BookLibrary.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Services.Services.Interfaces
{
    public interface IBookService
    {
        public void CreateBook(BookModel bookToAdd);
        public void UpdateBook(BookModel book, int bookId);
        public void DeleteBook(int bookId);

        public List<BookModel> GetBooks();
        public BookModel GetBookById(int id);

    }
}
