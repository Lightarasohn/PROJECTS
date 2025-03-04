using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.DTOs.Contact;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly FestavaDataDBContext _context;
        public ContactRepository(FestavaDataDBContext context)
        {
            _context = context;
        }
        public async Task<ContactCreatedDto> CreateContactAsync(ContactCreateDto dto)
        {
            var contact = await GetContactByEmailAsync(dto.Email!);
            
            if(contact != null)
                return dto.ToCreated(true);
            
            await _context.Contacts.AddAsync(dto.ToContact());
            await _context.SaveChangesAsync();
            
            return dto.ToCreated(false);
        }

        public async Task<Contact?> GetContactByEmailAsync(string email)
        {
            return await _context.Contacts.FirstOrDefaultAsync(contact => contact.Email == email);
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(contact => contact.id == id);
        }
    }
}