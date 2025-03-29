using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Designing_API_To_Ready_To_Go_Database.DTOs.MusteriDTOs
{
    public class MusteriCreateDto
    {
        public string? Isim { get; set; }
        public string? Soyisim { get; set; }
        public string? Email { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? ParolaH { get; set; }
    }
}