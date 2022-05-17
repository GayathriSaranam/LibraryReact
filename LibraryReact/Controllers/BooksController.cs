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
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookServices;

        public BooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet("Books/")]
        public async Task<ActionResult<IEnumerable<Books>>> Getbook()
        {
            try
            {
                return (await _bookServices.Getbook()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Books/{id}")]
        public async Task<ActionResult<Books>> GetbookById(string id)
        {

            try
            {
                var result = await _bookServices.GetbookById(id);

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

        [HttpPost("Books/")]
        public async Task<ActionResult<Books>> Createbook(Books bookobj)
        {
            string message = "faild";
            try
            {
                if (bookobj == null)
                    return BadRequest();

                var createbook = await _bookServices.Createbook(bookobj);
                if (createbook != null)
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

        [HttpPut("Books/")]
        public async Task<ActionResult<Books>> Updatebook(Books bookobj)
        {
            string message = "";
            try
            {
                if (bookobj.BookID != bookobj.BookID)
                {
                    return BadRequest();
                }
                var employeeToUpdate = await _bookServices.Updatebook(bookobj);

                if (employeeToUpdate == null)
                {
                    message = "faild";
                }
                else
                {
                    await _bookServices.Updatebook(bookobj);
                    message = "success";
                }



            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpDelete("Books/{id}")]
        public async Task<ActionResult<Books>> Deletebook(string id)
        {
            string message = "";
            try
            {
                var bookdelete = await _bookServices.GetbookById(id);

                if (bookdelete == null)
                {
                    message = "faild";
                }
                else
                {
                    await _bookServices.Deletebook(id);
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
