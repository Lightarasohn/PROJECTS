using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Data;
using Designing_API_To_Ready_To_Go_Database.DTOs.SiparisDetayDTOs;
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
        
        public async Task<Siparisler> CreateSiparisAsync(SiparisCreateDto dto)
        {
            var siparis = dto.ToSiparis();
            
            await _context.Siparisler.AddAsync(siparis);
            await _context.SaveChangesAsync();
            
            return siparis;
        }

        public async Task<Siparisler?> DeleteSiparisAsync(Siparisler siparis)
        {
            var bulunanSiparis = await _context.Siparisler.FirstOrDefaultAsync(aranan => aranan == siparis); 
            
            if(bulunanSiparis == null)
                return null;

            _context.Siparisler.Remove(bulunanSiparis);
            await _context.SaveChangesAsync();
            
            return bulunanSiparis;
        }

        public async Task<Siparisler?> DeleteSiparisByIdAsync(int id)
        {
            var siparis = await _context.Siparisler.FirstOrDefaultAsync(siparis => siparis.SiparisId == id);

            if(siparis == null)
                return null;

            _context.Siparisler.Remove(siparis);
            await _context.SaveChangesAsync();

            return siparis;
        }

        public async Task<SiparisDto?> GetSiparisByIdAsync(int Id)
        {
            var bulunanSiparis = await _context.Siparisler.Include(siparis => siparis.Musteri)
                                        .FirstOrDefaultAsync(siparis => siparis.SiparisId == Id);
            if(bulunanSiparis == null) 
                return null;
            return bulunanSiparis.ToSiparisDto();
        }

        public async Task<List<SiparisDto>> GetSiparislerAsync()
        {
            var siparisler = await _context.Siparisler.Include(siparis => siparis.Musteri).ToListAsync();
            var siparislerDto = siparisler.Select(siparis => siparis.ToSiparisDto()).ToList();
            return siparislerDto;
        }

        public async Task<List<SiparisDtoMusterisiz>> GetSiparislerByUserIdAsync(string id)
        {
            var siparisler = await _context.Siparisler.Where(siparis => siparis.MusteriId == id).ToListAsync();
            var siparislerDto = siparisler.Select(siparis => siparis.ToSiparisDtoMusterisiz()).ToList();
            return siparislerDto;
        }
    }
}