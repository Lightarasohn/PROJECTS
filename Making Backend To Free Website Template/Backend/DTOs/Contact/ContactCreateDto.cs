using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs.Contact
{
    public class ContactCreateDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string? FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
        [MaxLength(64)]
        public string? Company { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string? Message { get; set; } = string.Empty;
    }
}