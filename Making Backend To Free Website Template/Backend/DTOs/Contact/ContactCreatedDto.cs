using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs.Contact
{
    public class ContactCreatedDto
    {
        public string? FullName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Company { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
        public bool IsEmailAlreadyExist { get; set; } = false;
    }
}