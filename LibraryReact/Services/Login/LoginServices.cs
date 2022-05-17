using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryReact.Controllers;
using LibraryReact.Models;
using LibraryReact.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryReact.Repositories
{
    public class LoginServices : ILoginServices
    {
        private readonly ElibraryDbContext _context;

        public LoginServices(ElibraryDbContext context)
        {
            _context = context;
        }

        public Response AdminLogin(Admins login)
        {
            var log = _context.admins.Where(x => x.AdminID.Equals(login.AdminID) &&
                      x.AdminPassword.Equals(login.AdminPassword)).FirstOrDefault();

            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
            else
                return new Response { Status = "Admin", Message = "Login Successfully" };
        }

        public Response StudentLogin(Members login)
        {
            var log = _context.members.Where(x => x.MemberID.Equals(login.MemberID) &&
                         x.MemberPassword.Equals(login.MemberPassword)).FirstOrDefault();

            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
            else
                return new Response { Status = "Student", Message = "Login Successfully" };
        }
    }
}
