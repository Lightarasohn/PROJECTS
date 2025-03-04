using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Contact;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller
{
    [Route("Contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactCreateDto contact)
        {
            return Ok();
        }
    }
}