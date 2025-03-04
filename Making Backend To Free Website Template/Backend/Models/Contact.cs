using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Contact
    {
        public int id { get; set; }
        public string? FullName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Company { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
    }
}