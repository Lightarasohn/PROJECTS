using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Data;
using Designing_API_To_Ready_To_Go_Database.DTOs.SiparisDetayDTOs;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Designing_API_To_Ready_To_Go_Database.Mappers;
using Designing_API_To_Ready_To_Go_Database.Models;
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

        public async Task<SiparisDetayCreatedDto> CreateSiparisDetayAsync(SiparisDetayCreateDto dto)
        {
            var siparisDetayCreated = dto.ToSiparisDetayCreatedDto(false,false);
            var siparis = await _context.Siparisler.FirstOrDefaultAsync(siparisD => 
                                   siparisD.SiparisId == dto.SiparisId);
            if(siparis == null)
                return siparisDetayCreated;

            siparisDetayCreated.Siparis = siparis;
            siparisDetayCreated.IsSiparisFound = true;

            var urun = await _context.Urunler.FirstOrDefaultAsync(urun => urun.Id == dto.UrunId);
            
            if(urun == null)
                return siparisDetayCreated;

            siparisDetayCreated.Urun = urun;
            siparisDetayCreated.IsUrunFound = true;

            await _context.SiparisDetay.AddAsync(siparisDetayCreated.ToSiparisDetay());
            await _context.SaveChangesAsync();

            return siparisDetayCreated;
        }

        public async Task<SiparisDetay?> DeleteSiparisDetayByIdAsync(int id)
        {
            var siparisDetay = await _context.SiparisDetay.FirstOrDefaultAsync(siparisD => 
                               siparisD.SiparisId == id);

            if(siparisDetay == null)
                return null;

            _context.SiparisDetay.Remove(siparisDetay);
            await _context.SaveChangesAsync();

            return siparisDetay;
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

        public async Task<List<SiparisDetayDto>> GetSiparisDetaylarByUserIdAsync(string id)
        {
            var siparisDetaylar = await _context.SiparisDetay.Where(siparisDetay =>
                                       siparisDetay.Siparis!.MusteriId == id).ToListAsync();
            var siparisDetaylarDto = siparisDetaylar.Select(siparisDetay => 
                                     siparisDetay.ToSiparisDetayDto()).ToList();
            
            return siparisDetaylarDto;
        }
    }
}