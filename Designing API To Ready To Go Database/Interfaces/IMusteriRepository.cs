using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.MusteriDTOs;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.Interfaces
{
    public interface IMusteriRepository
    {
        public Task<List<MusteriDto>> GetAllMusterilerAsync();
        public Task<MusteriDto> GetMusteriByIdAsync(string id);
        public Task<MusteriDto> GetMusteriByEmailAsync(string email);
        public Task<Musteriler> DeleteMusteriByIdAsync(string id);
    }
}