using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace Backend.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? FullName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public TicketType TicketType { get; set; }
    }

    public enum TicketType
    {
        EarlyBird = 1,
        Standart = 2
    }
}