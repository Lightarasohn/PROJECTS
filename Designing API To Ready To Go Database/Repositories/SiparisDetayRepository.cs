using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Data;
using Designing_API_To_Ready_To_Go_Database.DTOs.SiparisDetayDTOs;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Designing_API_To_Ready_To_Go_Database.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Designing_API_To_Ready_To_Go_Database.Repositories
{
    public class SiparisDetayRepository : ISiparisDetayRepository
    {
        private readonly MarketContext _context;
        public SiparisDetayRepository(MarketContext context)
        {
            _context = context;
        }
        
        public async Task<SiparisDetayDto?> GetSiparisDetayBySiparisIdAsync(int id)
        {
            var siparisDetay = await _context.SiparisDetay.Include(siparisDetay =>
                siparisDetay.Siparis).Include(siparisDetay => siparisDetay.Urun).
                FirstOrDefaultAsync(siparisDetay => siparisDetay.SiparisId == id);
            
            if(siparisDetay == null)
                return null;

            return siparisDetay.ToSiparisDetayDto();
        }

        public async Task<List<SiparisDetayDto>> GetSiparisDetaylarAsync()
        {
            var siparisDetaylari = await _context.SiparisDetay.Include(siparisDetay =>
                siparisDetay.Siparis).Include(siparisDetay => siparisDetay.Urun).ToListAsync();
            var siparisDetaylariDto = siparisDetaylari.Select(siparisDetay => 
            siparisDetay.ToSiparisDetayDto()).ToList();
            return siparisDetaylariDto;
        }   
    }
}