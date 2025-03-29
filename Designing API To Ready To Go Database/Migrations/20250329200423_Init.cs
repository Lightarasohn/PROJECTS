using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Designing_API_To_Ready_To_Go_Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Isim = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Soyisim = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    KullaniciAdi = table.Column<string>(name: "Kullanici Adi", type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ParolaH = table.Column<string>(type: "varchar(267)", unicode: false, maxLength: 267, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Musteril__3214EC079FFD8624", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Kategori = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Fiyat = table.Column<int>(type: "int", nullable: true),
                    DepoMiktari = table.Column<int>(name: "Depo Miktari", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Urunler__3214EC077A254878", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    SiparisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Siparisl__C3F03BFDE7BA8F4E", x => x.SiparisId);
                    table.ForeignKey(
                        name: "FK__Siparisle__Muste__5070F446",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SiparisDetay",
                columns: table => new
                {
                    SiparisId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__SiparisDe__Sipar__59FA5E80",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "SiparisId");
                    table.ForeignKey(
                        name: "FK__SiparisDe__UrunI__5BE2A6F2",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_SiparisId",
                table: "SiparisDetay",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_UrunId",
                table: "SiparisDetay",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_MusteriId",
                table: "Siparisler",
                column: "MusteriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiparisDetay");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Musteriler");
        }
    }
}
