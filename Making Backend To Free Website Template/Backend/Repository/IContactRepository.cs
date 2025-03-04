using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Contact;


namespace Backend.Repository
{
    public interface IContactRepository
    {
        public Task<ContactCreateDto> CreateContact(ContactCreateDto dto);
    }
}