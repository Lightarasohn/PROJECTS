using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Data;
using Designing_API_To_Ready_To_Go_Database.DTOs.SiparislerDTOs;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Designing_API_To_Ready_To_Go_Database.Mappers;
using Designing_API_To_Ready_To_Go_Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Designing_API_To_Ready_To_Go_Database.Repositories{
    public class SiparisRepository : ISiparisRepository
    {
        private readonly MarketContext _context;
        public SiparisRepository(MarketContext context)
        {
            _context = context;
        }

        public async Task<SiparisDto?> GetSiparisById(int Id)
        {
            var bulunanSiparis = await _context.Siparisler.Include(siparis => siparis.Musteri)
                                        .FirstOrDefaultAsync(siparis => siparis.SiparisId == Id);
            if(bulunanSiparis == null) 
                return null;
            return bulunanSiparis.ToSiparisDto();
        }

        public async Task<List<Siparisler>> GetSiparisler()
        {
            var siparisler = await _context.Siparisler.Include(siparis => siparis.Musteri).ToListAsync();
            return siparisler;
        }
    }
}