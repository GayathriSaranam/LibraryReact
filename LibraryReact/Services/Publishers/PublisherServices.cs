using LibraryReact.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryReact.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryReact.Services
{
    public class PublisherServices : IPublisherServices
    {
        private readonly ElibraryDbContext _context;

        public PublisherServices(ElibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publishers>> Getpublisher()
        {
            return await _context.publishers.ToListAsync();

        }

        public async Task<Publishers> GetpublisherById(string publisherobj)
        {
            return await _context.publishers.FirstOrDefaultAsync(a => a.PublisherID == publisherobj);
        }


        public async Task<Publishers> Createpublisher(Publishers publisherobj)
        {
            var result = await _context.publishers.AddAsync(publisherobj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Publishers> Updatepublisher(Publishers publisherobj)
        {
            var result = await _context.publishers
                .FirstOrDefaultAsync(a => a.PublisherID == publisherobj.PublisherID);

            if (result != null)
            {
                result.PublisherName = publisherobj.PublisherName;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;

        }

        public async Task<Publishers> Deletepublisher(string publisherobj)
        {
            var result = await _context.publishers.FirstOrDefaultAsync(a => a.PublisherID == publisherobj);
            if (result != null)
            {
                _context.publishers.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
    }
}

