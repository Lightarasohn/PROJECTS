using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Contact;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller
{
    [Route("contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactRepository _contactRepo;
        public ContactController(IContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactCreateDto contact)
        {
            if(!ModelState.IsValid)
                return BadRequest("Body must be in the way it is");
            
            var createdContact = await _contactRepo.CreateContactAsync(contact);
            
            if(createdContact.IsEmailAlreadyExist)
                return BadRequest("Email already has been contacted us");

            return Ok(createdContact);
        }
    }
}