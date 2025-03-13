using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.UrunlerDTOs;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.Mappers
{
    public static class UrunlerMappers
    {
        public static UrunlerDto ToUrunlerDto(this Urunler urun)
        {
            return new UrunlerDto
            {
                Isim = urun.Isim,
                DepoMiktari = urun.DepoMiktari,
                Fiyat = urun.Fiyat,
                Kategori = urun.Kategori
            };
        }
    }
}