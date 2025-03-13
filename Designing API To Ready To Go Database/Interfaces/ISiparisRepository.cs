using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.SiparisDetayDTOs;
using Designing_API_To_Ready_To_Go_Database.DTOs.SiparislerDTOs;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.Interfaces
{
    public interface ISiparisRepository
    {
        public Task<List<SiparisDto>> GetSiparislerAsync();
        public Task<SiparisDto?> GetSiparisByIdAsync(int Id);
        public Task<List<SiparisDtoMusterisiz>> GetSiparislerByUserIdAsync(string id);
        public Task<Siparisler> CreateSiparisAsync(SiparisCreateDto dto);
        public Task<Siparisler?> DeleteSiparisByIdAsync(int id);
        public Task<Siparisler?> DeleteSiparisAsync(Siparisler siparis);
    }
}