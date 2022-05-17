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
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherServices _publisherServices;

        public PublishersController(IPublisherServices publisherServices)
        {
            _publisherServices = publisherServices;
        }

        [HttpGet("Publishers/")]
        public async Task<ActionResult<IEnumerable<Publishers>>> Getpublisher()
        {
            try
            {
                return (await _publisherServices.Getpublisher()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Publishers/{id}")]
        public async Task<ActionResult<Publishers>> GetpublisherById(string id)
        {

            try
            {
                var result = await _publisherServices.GetpublisherById(id);

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

        [HttpPost("Publishers/")]
        public async Task<ActionResult<Publishers>> Createpublisher(Publishers publisherobj)
        {
            string message = "faild";
            try
            {
                if (publisherobj == null)
                    return BadRequest();

                var createpublisher = await _publisherServices.Createpublisher(publisherobj);
                if (createpublisher != null)
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

        [HttpPut("Publishers/")]
        public async Task<ActionResult<Publishers>> Updatepublisher(Publishers publisherobj)
        {
            string message = "";
            try
            {
                if (publisherobj.PublisherID != publisherobj.PublisherID)
                {
                    return BadRequest();
                }
                var employeeToUpdate = await _publisherServices.Updatepublisher(publisherobj);

                if (employeeToUpdate == null)
                {
                    message = "faild";
                }
                else
                {
                    await _publisherServices.Updatepublisher(publisherobj);
                    message = "success";
                }



            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpDelete("Publishers/{id}")]
        public async Task<ActionResult<Publishers>> Deletepublisher(string id)
        {
            string message = "";
            try
            {
                var publisherdelete = await _publisherServices.GetpublisherById(id);

                if (publisherdelete == null)
                {
                    message = "faild";
                }
                else
                {
                    await _publisherServices.Deletepublisher(id);
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
