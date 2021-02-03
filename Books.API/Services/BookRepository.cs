using Books.API.Contexts;
using Books.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.API.Services
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private BooksContext _context;

        public BookRepository(BooksContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
            => await _context
                .Books
                .Include(b=>b.Author)
                .ToListAsync();

        public Task<Book> GetBookAsync(Guid id)
            => _context
                .Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context is not null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
