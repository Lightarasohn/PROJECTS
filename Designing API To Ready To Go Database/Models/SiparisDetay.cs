using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Designing_API_To_Ready_To_Go_Database.Models;

[Keyless]
[Table("SiparisDetay")]
public partial class SiparisDetay
{
    public int? SiparisId { get; set; }

    public int? UrunId { get; set; }

    public int? Miktar { get; set; }

    [ForeignKey("SiparisId")]
    public virtual Siparisler? Siparis { get; set; }

    [ForeignKey("UrunId")]
    public virtual Urunler? Urun { get; set; }
}
