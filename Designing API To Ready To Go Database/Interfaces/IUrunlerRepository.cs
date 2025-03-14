using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.UrunlerDTOs;

namespace Designing_API_To_Ready_To_Go_Database.Interfaces
{
    public interface IUrunlerRepository
    {
        public Task<List<UrunlerDto>> GetAllUrunlerAsync();
        public Task<UrunlerDto?> GetUrunByIdAsync(int id);
    }
}