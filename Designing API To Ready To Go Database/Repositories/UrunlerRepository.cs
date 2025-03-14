using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Data;
using Designing_API_To_Ready_To_Go_Database.DTOs.UrunlerDTOs;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Designing_API_To_Ready_To_Go_Database.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Designing_API_To_Ready_To_Go_Database.Repositories
{
    public class UrunlerRepository : IUrunlerRepository
    {
        private readonly MarketContext _context;
        public UrunlerRepository(MarketContext context)
        {
            _context = context;
        }
        public async Task<List<UrunlerDto>> GetAllUrunlerAsync()
        {
            var urunler = await _context.Urunler.ToListAsync();

            var urunlerDto = urunler.Select(urun => urun.ToUrunlerDto()).ToList();
            return urunlerDto; 
        }

        public async Task<UrunlerDto?> GetUrunByIdAsync(int id)
        {
            var bulunanUrun = await _context.Urunler.FirstOrDefaultAsync(urun => urun.Id == id);

            if(bulunanUrun == null)
                return null;

            return bulunanUrun.ToUrunlerDto();            
        }
    }
}