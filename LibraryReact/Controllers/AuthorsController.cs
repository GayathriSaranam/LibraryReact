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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorServices _authorServices;

        public AuthorsController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }

        [HttpGet("Authors/")]
        public async Task<ActionResult<IEnumerable<Authors>>> Getauthor()
        {
            try
            {
                return (await _authorServices.Getauthor()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Authors/{id}")]
        public async Task<ActionResult<Authors>> GetauthorById(string id)
        {

            try
            {
                var result = await _authorServices.GetauthorById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Authors/")]
        public async Task<ActionResult<Authors>> CreateAuthor(Authors authorobj)
        {
            string message = "faild";
            try
            {
                if (authorobj == null)
                    return BadRequest();

                var createAuthor = await _authorServices.CreateAuthor(authorobj);
                if (createAuthor != null)
                {
                    message = "success";
                }
                else
                {
                    message = "faild";
                }
            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpPut("Authors/")]
        public async Task<ActionResult<Authors>> UpdateAuthor(Authors authorobj)
        {
            string message = "";
            try
            {
                if (authorobj.AuthorID != authorobj.AuthorID)
                {
                    return BadRequest();
                }
                var employeeToUpdate = await _authorServices.UpdateAuthor(authorobj);

                if (employeeToUpdate == null)
                {
                    message = "faild";
                }
                else
                {
                    await _authorServices.UpdateAuthor(authorobj);
                    message = "success";
                }



            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpDelete("Authors/{id}")]
        public async Task<ActionResult<Authors>> DeleteAuthor(string id)
        {
            string message = "";
            try
            {
                var Authordelete = await _authorServices.GetauthorById(id);

                if (Authordelete == null)
                {
                    message = "faild";
                }
                else
                {
                    await _authorServices.DeleteAuthor(id);
                    message = "success";
                }

            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

    }
}
