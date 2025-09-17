using BookStore.Backend.DataAccess;
using BookStore.Backend.Models;
using BookStore.Backend.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Backend.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<Book> AddBook(AddBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                PublishDate = dto.PublishDate,
                Email = dto.Email
            };

            return await _repo.AddBook(book);
        }

        public async Task<Book> UpdateBook(UpdateBookDto dto)
        {
            var book = new Book
            {
                Id = dto.Id,
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                PublishDate = dto.PublishDate,
                Email = dto.Email
            };

            return await _repo.UpdateBook(book);
        }

        public async Task<bool> DeleteBook(int id)
        {
            return await _repo.DeleteBook(id);
        }

        public async Task<IReadOnlyList<Book>> GetAllBooks()
        {
            var books = await _repo.GetAllBooks();
            return books; 
        }

        public async Task<Book?> GetBookById(int id)
        {
            return await _repo.GetBookById(id);
        }

        public async Task<IReadOnlyList<Book>> SearchBooks(string query)
        {
            var books = await _repo.SearchBooks(query);
            return books; 
        }
    }
}
