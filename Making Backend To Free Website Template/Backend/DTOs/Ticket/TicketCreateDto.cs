using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.DTOs.Ticket
{
    public class TicketCreateDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string? FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string? PhoneNumber { get; set; } = string.Empty;
        [Required]
        public TicketType TicketType { get; set; }
        [Required]
        public int NumberOfTickets { get; set; }
        [MaxLength(255)]
        public string? AdditionalRequest { get; set; } = string.Empty;
    }
}