using BookStore.Backend.Models;
using BookStore.Backend.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Backend.Services
{
    public interface IBookService
    {
        Task<Book> AddBook(AddBookDto dto);
        Task<Book> UpdateBook(UpdateBookDto dto);
        Task<bool> DeleteBook(int id);

        Task<IReadOnlyList<Book>> GetAllBooks();
        Task<Book?> GetBookById(int id);
        Task<IReadOnlyList<Book>> SearchBooks(string query);
    }
}
