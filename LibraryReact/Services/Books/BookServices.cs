
using LibraryReact.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryReact.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryReact.Services
{
    public class BookServices : IBookServices
    {
        private readonly ElibraryDbContext _context;

        public BookServices(ElibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Books>> Getbook()
        {
            return await _context.books.ToListAsync();

        }

        public async Task<Books> GetbookById(string bookobj)
        {
            return await _context.books.FirstOrDefaultAsync(a => a.BookID == bookobj);
        }


        public async Task<Books> Createbook(Books bookobj)
        {
            var result = await _context.books.AddAsync(bookobj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Books> Updatebook(Books bookobj)
        {
            var result = await _context.books
                .FirstOrDefaultAsync(a => a.BookID == bookobj.BookID);

            if (result != null)
            {
                result.BookName = bookobj.BookName;
                result.AuthorID = bookobj.AuthorID;
                result.PublisherID = bookobj.PublisherID;
                result.BooKLanguage = bookobj.BooKLanguage;
                result.BookCost = bookobj.BookCost;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;

        }

        public async Task<Books> Deletebook(string bookobj)
        {
            var result = await _context.books.FirstOrDefaultAsync(a => a.BookID == bookobj);
            if (result != null)
            {
                _context.books.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
    }
}
