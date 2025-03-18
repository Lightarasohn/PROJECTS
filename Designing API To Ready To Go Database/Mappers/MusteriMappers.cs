using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.DTOs.MusteriDTOs;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.Mappers
{
    public static class MusteriMappers
    {
        public static MusteriDto ToMusteriDto(this Musteriler musteri)
        {
            return new MusteriDto
            {
                Isim = musteri.Isim,
                Soyisim = musteri.Soyisim,
                KullaniciAdi = musteri.KullaniciAdi,
                Email = musteri.Email,
                Siparisler = musteri.Siparisler,
            };
        }
    }
}