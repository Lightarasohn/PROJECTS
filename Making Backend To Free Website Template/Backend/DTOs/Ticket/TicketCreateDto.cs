using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.DTOs.Ticket
{
    public class TicketCreateDto
    {
        public string? FullName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public TicketType TicketType { get; set; }
        public int NumberOfTickets { get; set; }
        public string? AdditionalRequest { get; set; } = string.Empty;
    }
}