using Books.API.Filters.MappingFilters;
using Books.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        [HttpGet]
        [BooksResultFilter]
        public async Task<IActionResult> GetBooks()
            => Ok(await _bookRepository.GetBooksAsync());

        [HttpGet]
        [Route("{id}")]
        [BookResultFilter]
        public async Task<IActionResult> GetBooks(Guid id)
            => (await _bookRepository.GetBookAsync(id)) switch
            {
                null => NotFound(),
                { } b => Ok(b)
            };
    }
}
