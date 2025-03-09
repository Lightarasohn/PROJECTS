using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.SiparislerDTOs;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.Mappers
{
    public static class SiparisMappers
    {
        public static SiparisDto ToSiparisDto(this Siparisler siparis)
        {
            return new SiparisDto
            {
                SiparisId = siparis.SiparisId,
                Musteri = siparis.Musteri
            };
        }
    }
}