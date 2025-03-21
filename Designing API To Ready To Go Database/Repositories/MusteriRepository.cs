using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Data;
using Designing_API_To_Ready_To_Go_Database.DTOs.MusteriDTOs;
using Designing_API_To_Ready_To_Go_Database.Interfaces;
using Designing_API_To_Ready_To_Go_Database.Mappers;
using Designing_API_To_Ready_To_Go_Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Designing_API_To_Ready_To_Go_Database.Repositories
{   
    public class MusteriRepository : IMusteriRepository
    {
        private readonly MarketContext _context;
        public MusteriRepository(MarketContext context)
        {
            _context = context;
        }

        public Task<Musteriler> CreateMusteriAsync(MusteriCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Musteriler?> DeleteMusteriByIdAsync(string id)
        {
            var musteri = await _context.Musteriler.FirstOrDefaultAsync(Musteri => Musteri.Id == id);
            if(musteri == null)
                return null;

            _context.Musteriler.Remove(musteri);
            await _context.SaveChangesAsync();

            return musteri;
        }

        public async Task<List<MusteriDto>> GetAllMusterilerAsync()
        {
            var musteriler = await _context.Musteriler.Include(musteri => musteri.Siparisler).ToListAsync();
            var musterilerdto = musteriler.Select(musteri => musteri.ToMusteriDto()).ToList();
            return musterilerdto;
        }

        public async Task<MusteriDto?> GetMusteriByEmailAsync(string email)
        {
            var musteri = await _context.Musteriler.FirstOrDefaultAsync(Musteri => Musteri.Email == email);

            if(musteri == null)
                return null;

            return musteri.ToMusteriDto();
        }

        public async Task<MusteriDto?> GetMusteriByIdAsync(string id)
        {
            var musteri = await _context.Musteriler.FirstOrDefaultAsync(Musteri => Musteri.Id == id);

            if(musteri == null)
                return null;

            return musteri.ToMusteriDto();
        }
    }
}