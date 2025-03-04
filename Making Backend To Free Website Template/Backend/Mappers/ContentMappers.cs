using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Contact;
using Backend.Models;

namespace Backend.Mappers
{
    public static class ContentMappers
    {
        public static Contact ToContact(this ContactCreateDto dto)
        {
            return new Contact
            {
                Email = dto.Email,
                Company = dto.Company,
                FullName = dto.FullName,
                Message = dto.Message
            };
        }

        public static ContactCreatedDto ToCreated(this ContactCreateDto dto, bool EmailState)
        {
            return new ContactCreatedDto 
            {
                Email = dto.Email,
                Company = dto.Company,
                FullName = dto.FullName,
                Message = dto.Message,
                IsEmailAlreadyExist = EmailState
            };
        }
    }
}