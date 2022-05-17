using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryReact.Services;
using LibraryReact.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace LibraryReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;

        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }
        [HttpPost("AdminLogin")]
        public Response AdminLogin(Admins login)
        {
            return _loginServices.AdminLogin(login);
        }

        [HttpPost("StudentLogin")]
        public Response StudentLogin(Members login)
        {
           return _loginServices.StudentLogin(login);  
        }


    }
}
