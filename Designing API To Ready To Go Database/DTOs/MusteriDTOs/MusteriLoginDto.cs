using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Designing_API_To_Ready_To_Go_Database.Models;

namespace Designing_API_To_Ready_To_Go_Database.DTOs.MusteriDTOs{

    public class MusteriLoginDto{
        public string? KullaniciAdi { get; set; }
        public string? Parola { get; set; }
    }
}