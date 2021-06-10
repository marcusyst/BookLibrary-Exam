using BookLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DAL.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public void CreateBook(Book blogToAdd);
        public void UpdateBook(Book blog, int blogId);
        public void DeleteBook(int blogId);

        public List<Book> GetBooks();
        public Book GetBookById(int id);

    }
}
