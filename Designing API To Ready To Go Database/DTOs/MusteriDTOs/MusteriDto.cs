using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.DTOs.MusteriDTOs
{
    public class MusteriDto
    {
        public string? Isim { get; set; }
        public string? Soyisim { get; set; }
        public string? Email { get; set; }
        public string? KullaniciAdi { get; set; }
        public virtual ICollection<Siparisler> Siparisler { get; set; } = new List<Siparisler>();
    }
}