using Microsoft.AspNetCore.Mvc;
using BookStore.Backend.Models;
using BookStore.Backend.Models.Entities;
using BookStore.Backend.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Book>>> GetAll()
        {
            var books = await _service.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await _service.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Add([FromBody] AddBookDto dto)
        {
            var book = await _service.AddBook(dto);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Update(int id, [FromBody] UpdateBookDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var book = await _service.UpdateBook(dto);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _service.DeleteBook(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<Book>>> Search(string query)
        {
            var books = await _service.SearchBooks(query);
            return Ok(books);
        }
    }
}
