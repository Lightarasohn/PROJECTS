using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Designing_API_To_Ready_To_Go_Database.Models;

[Table("Urunler")]
public partial class Urunler
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Isim { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Kategori { get; set; }

    public int? Fiyat { get; set; }

    [Column("Depo Miktari")]
    public int? DepoMiktari { get; set; }
}
