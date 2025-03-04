using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Contact;
using Backend.Interfaces;

namespace Backend.Repository
{
    public class ContactRepository : IContactRepository
    {
        public Task<ContactCreateDto> CreateContact(ContactCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}