using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.DTOs.SiparislerDTOs
{
    public class SiparisDto
    {
        public int SiparisId { get; set; }
        public virtual Musteriler? Musteri { get; set; }
    }
}