using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.SiparisDetayDTOs;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.Mappers
{
    public static class SiparisDetayMappers
    {
        public static SiparisDetayDto ToSiparisDetayDto(this SiparisDetay siparis)
        {
            return new SiparisDetayDto
            {
                SiparisId = siparis.SiparisId,
                UrunId = siparis.UrunId,
                Urun = siparis.Urun,
                Miktar = siparis.Miktar
            };
        }
        public static SiparisDetay ToSiparisDetay(this SiparisDetayCreateDto dto)
        {
            return new SiparisDetay
            {
                SiparisId = dto.SiparisId,
                UrunId = dto.UrunId,
                Miktar = dto.Miktar,
            };
        }
        public static SiparisDetayCreatedDto ToSiparisDetayCreatedDto(this SiparisDetayCreateDto dto, bool Siparis, bool Urun)
        {
            return new SiparisDetayCreatedDto
            {
                UrunId = dto.UrunId,
                SiparisId = dto.SiparisId,
                IsSiparisFound = Siparis,
                IsUrunFound = Urun,
                Miktar = dto.Miktar,
            };
        }
        public static SiparisDetay ToSiparisDetay(this SiparisDetayCreatedDto dto)
        {
            return new SiparisDetay
            {
                UrunId = dto.UrunId,
                SiparisId = dto.SiparisId,
                Miktar = dto.Miktar,
                Urun = dto.Urun,
                Siparis = dto.Siparis
            };
        }

    }
}