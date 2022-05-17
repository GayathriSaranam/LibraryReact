using LibraryReact.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryReact.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly ElibraryDbContext _context;

        public AuthorServices(ElibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Authors>> Getauthor()
        {
            return await _context.authors.ToListAsync();

        }

        public async Task<Authors> GetauthorById(string authorobj)
        {
            return await _context.authors.FirstOrDefaultAsync(a => a.AuthorID == authorobj);
        }


        public async Task<Authors> CreateAuthor(Authors authorobj)
        {
            var result = await _context.authors.AddAsync(authorobj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Authors> UpdateAuthor(Authors authorobj)
        {
            var result = await _context.authors
                .FirstOrDefaultAsync(a => a.AuthorID == authorobj.AuthorID);

            if (result != null)
            {
                result.AuthorName = authorobj.AuthorName;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;

        }

        public async Task<Authors> DeleteAuthor(string authorobj)
        {
            var result = await _context.authors.FirstOrDefaultAsync(a => a.AuthorID == authorobj);
            if (result != null)
            {
                _context.authors.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
    }
}
