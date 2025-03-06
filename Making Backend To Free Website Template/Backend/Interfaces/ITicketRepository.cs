using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Ticket;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface ITicketRepository
    {
        public Task<List<Ticket>> CreateTicketAsync(TicketCreateDto dto);
        public List<TicketCreateDto> GetTicketCreateDtoListFromDto(TicketCreateDto dto);
    }
}