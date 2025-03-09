using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.SiparislerDTOs;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.Interfaces
{
    public interface ISiparisRepository
    {
        public Task<List<Siparisler>> GetSiparisler();
        public Task<SiparisDto?> GetSiparisById(int Id);
    }
}