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
    public class IssueBooksController : ControllerBase
    {
        private readonly IIssueBookServices _ibookServices;

        public IssueBooksController(IIssueBookServices ibookServices)
        {
            _ibookServices = ibookServices;
        }

        [HttpGet("IssueBooks/")]
        public async Task<ActionResult<IEnumerable<IssueBooks>>> Getibook()
        {
            try
            {
                return (await _ibookServices.Getibook()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("IssueBooks/{id}")]
        public async Task<ActionResult<IssueBooks>> GetibookById(int id)
        {

            try
            {
                var result = await _ibookServices.GetibookById(id);

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

        [HttpPost("IssueBooks/")]
        public async Task<ActionResult<IssueBooks>> Createibook(IssueBooks ibookobj)
        {
            string message = "faild";
            try
            {
                if (ibookobj == null)
                    return BadRequest();

                var createibook = await _ibookServices.Createibook(ibookobj);
                if (createibook != null)
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

        [HttpPut("IssueBooks/")]
        public async Task<ActionResult<IssueBooks>> Updateibook(IssueBooks ibookobj)
        {
            string message = "";
            try
            {
                if (ibookobj.IssueBookId != ibookobj.IssueBookId)
                {
                    return BadRequest();
                }
                var employeeToUpdate = await _ibookServices.Updateibook(ibookobj);

                if (employeeToUpdate == null)
                {
                    message = "faild";
                }
                else
                {
                    await _ibookServices.Updateibook(ibookobj);
                    message = "success";
                }



            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpDelete("IssueBooks/{id}")]
        public async Task<ActionResult<IssueBooks>> Deleteibook(int id)
        {
            string message = "";
            try
            {
                var ibookdelete = await _ibookServices.GetibookById(id);

                if (ibookdelete == null)
                {
                    message = "faild";
                }
                else
                {
                    await _ibookServices.Deleteibook(id);
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
