using BookStore.Backend.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Backend.DataAccess
{
    public interface IBookRepository
    {
        Task<IReadOnlyList<Book>> GetAllBooks();
        Task<Book?> GetBookById(int id);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
        Task<IReadOnlyList<Book>> SearchBooks(string query);
    }
}
