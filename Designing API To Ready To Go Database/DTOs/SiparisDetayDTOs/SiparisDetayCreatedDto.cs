using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.DTOs.SiparisDetayDTOs
{
    public class SiparisDetayCreatedDto
    {
        public int SiparisId { get; set; }
        public int UrunId { get; set; }
        public int? Miktar { get; set; }
        public virtual Urunler Urun { get; set; } = null!;
        public virtual Siparisler Siparis { get; set; } = null!;
        public bool IsSiparisFound { get; set; } = false;
        public bool IsUrunFound { get; set; } = false;
    }
}