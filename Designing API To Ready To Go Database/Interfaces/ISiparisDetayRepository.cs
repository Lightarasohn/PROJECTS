using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.SiparisDetayDTOs;

namespace Designing_API_To_Ready_To_Go_Database.Interfaces
{
    public interface ISiparisDetayRepository
    {
        public Task<List<SiparisDetayDto>> GetSiparisDetaylarAsync();
        public Task<SiparisDetayDto?> GetSiparisDetayBySiparisIdAsync(int id);
        public Task<List<SiparisDetayDto>> GetSiparisDetaylarByUserIdAsync(string id);
    }
}