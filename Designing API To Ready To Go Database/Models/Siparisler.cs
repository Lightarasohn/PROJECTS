using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Designing_API_To_Ready_To_Go_Database.Models;

[Table("Siparisler")]
public partial class Siparisler
{
    [Key]
    public int SiparisId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? MusteriId { get; set; }

    [ForeignKey("MusteriId")]
    [InverseProperty("Siparislers")]
    public virtual Musteriler? Musteri { get; set; }
}
