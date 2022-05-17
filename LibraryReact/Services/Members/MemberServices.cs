using LibraryReact.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryReact.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryReact.Services
{
    public class MemberServices : IMemberServices
    {
        private readonly ElibraryDbContext _context;

        public MemberServices(ElibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Members>> Getmember()
        {
            return await _context.members.ToListAsync();

        }

        public async Task<Members> GetmemberById(string memberobj)
        {
            return await _context.members.FirstOrDefaultAsync(a => a.MemberID == memberobj);
        }


        public async Task<Members> Createmember(Members memberobj)
        {
            var result = await _context.members.AddAsync(memberobj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Members> Updatemember(Members memberobj)
        {
            var result = await _context.members
                .FirstOrDefaultAsync(a => a.MemberID == memberobj.MemberID);

            if (result != null)
            {
                result.MemberFullName = memberobj.MemberFullName;
                result.MemberDOB = memberobj.MemberDOB;
                result.MemberContactNo = memberobj.MemberContactNo;
                result.MemberEmail = memberobj.MemberEmail;
                result.MemberFullAddress = memberobj.MemberFullAddress;
                result.MemberPassword = memberobj.MemberPassword;


                await _context.SaveChangesAsync();

                return result;
            }

            return null;

        }

        public async Task<Members> Deletemember(string memberobj)
        {
            var result = await _context.members.FirstOrDefaultAsync(a => a.MemberID == memberobj);
            if (result != null)
            {
                _context.members.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
    }
}
