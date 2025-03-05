using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.DTOs.Ticket;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.Models;

namespace Backend.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly FestavaDataDBContext _context;
        public TicketRepository(FestavaDataDBContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> CreateTicketAsync(TicketCreateDto dto)
        {
            var ticketDtoList = GetTicketCreateDtoListFromDto(dto);

            var ticketList = ticketDtoList.Select(ticketDto => ticketDto.ToTicket()).ToList();
            await _context.Tickets.AddRangeAsync(ticketList);
            await _context.SaveChangesAsync();
            return ticketList;
        }

        public List<TicketCreateDto> GetTicketCreateDtoListFromDto(TicketCreateDto dto)
        {
            return Enumerable.Repeat(dto, dto.NumberOfTickets).ToList();
        }
    }
}