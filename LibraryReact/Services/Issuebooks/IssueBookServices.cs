using LibraryReact.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryReact.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryReact.Services
{
    public class IssueBookServices : IIssueBookServices
    {
        private readonly ElibraryDbContext _context;

        public IssueBookServices(ElibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IssueBooks>> Getibook()
        {
            return await _context.issueBooks.ToListAsync();

        }

        public async Task<IssueBooks> GetibookById(int ibookobj)
        {
            return await _context.issueBooks.FirstOrDefaultAsync(a => a.IssueBookId == ibookobj);
        }


        public async Task<IssueBooks> Createibook(IssueBooks ibookobj)
        {
            var log = _context.issueBooks.Where(x => x.MemberID.Equals(ibookobj.MemberID) &&
                      x.BookID.Equals(ibookobj.BookID)).FirstOrDefault();

            if (log == null)
            {
                var result = await _context.issueBooks.AddAsync(ibookobj);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            else
            {
                return null;
            }

        }

        public async Task<IssueBooks> Updateibook(IssueBooks ibookobj)
        {
            var result = await _context.issueBooks
                .FirstOrDefaultAsync(a => a.IssueBookId == ibookobj.IssueBookId);

            if (result != null)
            {
                result.MemberID = ibookobj.MemberID;
                result.MemberFullName = ibookobj.MemberFullName;
                result.BookID = ibookobj.BookID;
                result.BookName = ibookobj.BookName;
                result.BookIssueDate = ibookobj.BookIssueDate;
                result.BookDueDate = ibookobj.BookDueDate;


                await _context.SaveChangesAsync();

                return result;
            }

            return null;

        }

        public async Task<IssueBooks> Deleteibook(int ibookobj)
        {
            var result = await _context.issueBooks.FirstOrDefaultAsync(a => a.IssueBookId == ibookobj);
            if (result != null)
            {
                _context.issueBooks.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
    }
}
