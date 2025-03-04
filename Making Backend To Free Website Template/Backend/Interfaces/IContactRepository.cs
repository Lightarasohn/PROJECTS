using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Contact;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IContactRepository
    {
        public Task<ContactCreatedDto> CreateContactAsync(ContactCreateDto dto);
        public Task<Contact?> GetContactByIdAsync(int id);
        public Task<Contact?> GetContactByEmailAsync(string email);
    }
}