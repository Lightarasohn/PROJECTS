using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller
{
    [Route("ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public TicketController()
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketCreateDto dto)
        {
            return Ok();
        }
    }
}