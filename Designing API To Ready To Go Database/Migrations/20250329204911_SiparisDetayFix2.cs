using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Designing_API_To_Ready_To_Go_Database.Migrations
{
    /// <inheritdoc />
    public partial class SiparisDetayFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SiparisDetay",
                table: "SiparisDetay");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_SiparisId",
                table: "SiparisDetay",
                column: "SiparisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SiparisDetay_SiparisId",
                table: "SiparisDetay");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiparisDetay",
                table: "SiparisDetay",
                columns: new[] { "SiparisId", "UrunId" });
        }
    }
}
