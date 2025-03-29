using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Designing_API_To_Ready_To_Go_Database.DTOs.UrunlerDTOs
{
    public class UrunlerDto
    {
        public int Id { get; set; }
        public string? Isim { get; set; }
        public string? Kategori { get; set; }
        public int? Fiyat { get; set; }
        public int? DepoMiktari { get; set; }
    }
}