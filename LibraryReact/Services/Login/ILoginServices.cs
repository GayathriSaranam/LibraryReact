using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LibraryReact.Controllers;
using LibraryReact.Models;
using LibraryReact.Repositories;

namespace LibraryReact.Services
{
    public interface ILoginServices
    {
        public Response AdminLogin(Admins login);
        public Response StudentLogin(Members login);



    }
}