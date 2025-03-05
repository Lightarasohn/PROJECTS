using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Ticket;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller
{
    [Route("ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepo;
        public TicketController(ITicketRepository ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketCreateDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.Values);            

            var tickets = await _ticketRepo.CreateTicketAsync(dto);

            if(tickets == null)
                return StatusCode(500, "Bir şeyler ters gitti");

            return Ok(tickets);
        }
    }
}