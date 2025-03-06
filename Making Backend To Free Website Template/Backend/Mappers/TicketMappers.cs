using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Ticket;
using Backend.Models;

namespace Backend.Mappers
{
    public static class TicketMappers
    {
        public static Ticket ToTicket(this TicketCreateDto dto)
        {
            return new Ticket
            {
                FullName = dto.FullName,
                Email = dto.Email,
                AdditionalRequest = dto.AdditionalRequest,
                TicketType = dto.TicketType,
                PhoneNumber = dto.PhoneNumber
            };
        }
    }
}