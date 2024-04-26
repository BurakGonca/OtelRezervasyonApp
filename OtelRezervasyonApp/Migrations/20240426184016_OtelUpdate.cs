using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtelRezervasyonApp.Migrations
{
    /// <inheritdoc />
    public partial class OtelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sehir",
                table: "Oteller");

            migrationBuilder.DropColumn(
                name: "Ulke",
                table: "Oteller");

            migrationBuilder.RenameColumn(
                name: "Turu",
                table: "Oteller",
                newName: "UlkeId");

            migrationBuilder.AddColumn<int>(
                name: "OtelTuruId",
                table: "Oteller",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SehirId",
                table: "Oteller",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Oteller_OtelTuruId",
                table: "Oteller",
                column: "OtelTuruId");

            migrationBuilder.CreateIndex(
                name: "IX_Oteller_SehirId",
                table: "Oteller",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Oteller_UlkeId",
                table: "Oteller",
                column: "UlkeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oteller_OtelTurleri_OtelTuruId",
                table: "Oteller",
                column: "OtelTuruId",
                principalTable: "OtelTurleri",
                principalColumn: "Id"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Oteller_Sehirler_SehirId",
                table: "Oteller",
                column: "SehirId",
                principalTable: "Sehirler",
                principalColumn: "Id"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Oteller_Ulkeler_UlkeId",
                table: "Oteller",
                column: "UlkeId",
                principalTable: "Ulkeler",
                principalColumn: "Id"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oteller_OtelTurleri_OtelTuruId",
                table: "Oteller");

            migrationBuilder.DropForeignKey(
                name: "FK_Oteller_Sehirler_SehirId",
                table: "Oteller");

            migrationBuilder.DropForeignKey(
                name: "FK_Oteller_Ulkeler_UlkeId",
                table: "Oteller");

            migrationBuilder.DropIndex(
                name: "IX_Oteller_OtelTuruId",
                table: "Oteller");

            migrationBuilder.DropIndex(
                name: "IX_Oteller_SehirId",
                table: "Oteller");

            migrationBuilder.DropIndex(
                name: "IX_Oteller_UlkeId",
                table: "Oteller");

            migrationBuilder.DropColumn(
                name: "OtelTuruId",
                table: "Oteller");

            migrationBuilder.DropColumn(
                name: "SehirId",
                table: "Oteller");

            migrationBuilder.RenameColumn(
                name: "UlkeId",
                table: "Oteller",
                newName: "Turu");

            migrationBuilder.AddColumn<string>(
                name: "Sehir",
                table: "Oteller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ulke",
                table: "Oteller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
