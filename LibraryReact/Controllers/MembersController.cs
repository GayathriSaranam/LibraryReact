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
    public class MembersController : ControllerBase
    {
        private readonly IMemberServices _memberServices;

        public MembersController(IMemberServices memberServices)
        {
            _memberServices = memberServices;
        }

        [HttpGet("Members/")]
        public async Task<ActionResult<IEnumerable<Members>>> Getmember()
        {
            try
            {
                return (await _memberServices.Getmember()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Members/{id}")]
        public async Task<ActionResult<Members>> GetmemberById(string id)
        {

            try
            {
                var result = await _memberServices.GetmemberById(id);

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

        [HttpPost("Members/")]
        public async Task<ActionResult<Members>> Createmember(Members memberobj)
        {
            string message = "faild";
            try
            {
                if (memberobj == null)
                    return BadRequest();

                var createmember = await _memberServices.Createmember(memberobj);
                if (createmember != null)
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

        [HttpPut("Members/")]
        public async Task<ActionResult<Members>> Updatemember(Members memberobj)
        {
            string message = "";
            try
            {
                if (memberobj.MemberID != memberobj.MemberID)
                {
                    return BadRequest();
                }
                var employeeToUpdate = await _memberServices.Updatemember(memberobj);

                if (employeeToUpdate == null)
                {
                    message = "faild";
                }
                else
                {
                    await _memberServices.Updatemember(memberobj);
                    message = "success";
                }



            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpDelete("Members/{id}")]
        public async Task<ActionResult<Members>> Deletemember(string id)
        {
            string message = "";
            try
            {
                var memberdelete = await _memberServices.GetmemberById(id);

                if (memberdelete == null)
                {
                    message = "faild";
                }
                else
                {
                    await _memberServices.Deletemember(id);
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
