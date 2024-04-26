using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtelRezervasyonApp.Migrations
{
    /// <inheritdoc />
    public partial class otelTuruUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtelKapasiteleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kapasite = table.Column<int>(type: "int", nullable: false),
                    OtelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtelKapasiteleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtelKapasiteleri_Oteller_OtelId",
                        column: x => x.OtelId,
                        principalTable: "Oteller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtelOdalari",
                columns: table => new
                {
                    OtelId = table.Column<int>(type: "int", nullable: false),
                    OdaId = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtelOdalari", x => new { x.OdaId, x.OtelId });
                });

            migrationBuilder.CreateTable(
                name: "OtelTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtelTurleri", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtelKapasiteleri_OtelId",
                table: "OtelKapasiteleri",
                column: "OtelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtelKapasiteleri");

            migrationBuilder.DropTable(
                name: "OtelOdalari");

            migrationBuilder.DropTable(
                name: "OtelTurleri");
        }
    }
}
