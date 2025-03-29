using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.UrunlerDTOs;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.Interfaces
{
    public interface IUrunlerRepository
    {
        public Task<List<UrunlerDto>> GetAllUrunlerAsync();
        public Task<UrunlerDto?> GetUrunByIdAsync(int id);
        public Task<Urunler> CreateUrunAsync(UrunlerCreateDto dto);
        public Task<Urunler?> DeleteUrunAsync(int id);
    }
}