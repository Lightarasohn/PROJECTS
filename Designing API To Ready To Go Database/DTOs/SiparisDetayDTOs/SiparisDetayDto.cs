using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.DTOs.SiparisDetayDTOs
{
    public class SiparisDetayDto
    {
        public int? SiparisId { get; set; }

        public int? UrunId { get; set; }

        public int? Miktar { get; set; }

        public Urunler? Urun { get; set; }
    }
}