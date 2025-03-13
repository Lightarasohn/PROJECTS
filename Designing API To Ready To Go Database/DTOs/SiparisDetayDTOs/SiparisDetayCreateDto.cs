using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Designing_API_To_Ready_To_Go_Database.DTOs.SiparisDetayDTOs
{
    public class SiparisDetayCreateDto
    {
        public int? SiparisId { get; set; }

        public int? UrunId { get; set; }

        public int? Miktar { get; set; }
    }
}