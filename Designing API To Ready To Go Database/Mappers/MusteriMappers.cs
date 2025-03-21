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
        public static CreatedMusteriDto ToCreatedMusteriDto(this Musteriler musteri, string token,
        bool emailExist, bool userNameExist)
        {
            return new CreatedMusteriDto
            {
                Isim = musteri.Isim,
                Soyisim = musteri.Soyisim,
                KullaniciAdi = musteri.KullaniciAdi,
                Email = musteri.Email,
                Token = token,
                IsEmailExist = emailExist,
                IsUsernameExist = userNameExist
            };
        }
        public static MusteriTokenDto ToMusteriTokenDto(this CreatedMusteriDto dto)
        {
            return new MusteriTokenDto
            {
                Isim = dto.Isim,
                Soyisim = dto.Soyisim,
                KullaniciAdi = dto.KullaniciAdi,
                Email = dto.Email,
                Token = dto.Token
            };
        }
    }
}