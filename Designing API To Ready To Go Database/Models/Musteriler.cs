using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Designing_API_To_Ready_To_Go_Database.Models;

[Table("Musteriler")]
public partial class Musteriler
{
    [Key]
    [StringLength(255)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? Isim { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Soyisim { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("Kullanici Adi")]
    [StringLength(20)]
    [Unicode(false)]
    public string? KullaniciAdi { get; set; }

    [StringLength(267)]
    [Unicode(false)]
    public string? ParolaH { get; set; }

    [InverseProperty("Musteri")]
    public virtual ICollection<Siparisler> Siparisler { get; set; } = new List<Siparisler>();
}
