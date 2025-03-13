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
        public static SiparisDtoMusterisiz ToSiparisDtoMusterisiz(this Siparisler siparis)
        {
            return new SiparisDtoMusterisiz
            {
                SiparisId = siparis.SiparisId
            };
        }
        public static Siparisler ToSiparis(this SiparisCreateDto siparisCreate)
        {
            return new Siparisler
            {
                MusteriId = siparisCreate.MusteriId,
                Musteri = siparisCreate.Musteri
            };
        }
    }
}