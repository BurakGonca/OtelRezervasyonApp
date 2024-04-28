using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OtelRezervasyonApp.Migrations
{
    /// <inheritdoc />
    public partial class refreshdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OdaTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdaTurAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdaTurleri", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Sezonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SezonAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sezonlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ulkeler",
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
                    table.PrimaryKey("PK_Ulkeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sehirler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UlkeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sehirler_Ulkeler_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ulkeler",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.CreateTable(
                name: "Oteller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtelTuruId = table.Column<int>(type: "int", nullable: false),
                    Yildizi = table.Column<int>(type: "int", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UlkeId = table.Column<int>(type: "int", nullable: false),
                    SehirId = table.Column<int>(type: "int", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oteller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oteller_OtelTurleri_OtelTuruId",
                        column: x => x.OtelTuruId,
                        principalTable: "OtelTurleri",
                        principalColumn: "Id"
                        );
                    table.ForeignKey(
                        name: "FK_Oteller_Sehirler_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehirler",
                        principalColumn: "Id"
                        );
                    table.ForeignKey(
                        name: "FK_Oteller_Ulkeler_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ulkeler",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.CreateTable(
                name: "OtelKapasiteleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtelId = table.Column<int>(type: "int", nullable: false),
                    OtelToplamKapasite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtelKapasiteleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtelKapasiteleri_Oteller_OtelId",
                        column: x => x.OtelId,
                        principalTable: "Oteller",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.CreateTable(
                name: "OtelOdalari",
                columns: table => new
                {
                    OdaId = table.Column<int>(type: "int", nullable: false),
                    OtelId = table.Column<int>(type: "int", nullable: false),
                    OdaNumarasi = table.Column<short>(type: "smallint", nullable: false),
                    BulunduguKat = table.Column<byte>(type: "tinyint", nullable: false),
                    OdaOlcusuM2 = table.Column<short>(type: "smallint", nullable: true),
                    OdaKapasitesi = table.Column<byte>(type: "tinyint", nullable: false),
                    OdaTuruId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtelOdalari", x => new { x.OdaId, x.OtelId });
                    table.ForeignKey(
                        name: "FK_OtelOdalari_OdaTurleri_OdaTuruId",
                        column: x => x.OdaTuruId,
                        principalTable: "OdaTurleri",
                        principalColumn: "Id"
                       );
                    table.ForeignKey(
                        name: "FK_OtelOdalari_Oteller_OtelId",
                        column: x => x.OtelId,
                        principalTable: "Oteller",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.CreateTable(
                name: "OtelSezonKapasiteleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtelId = table.Column<int>(type: "int", nullable: false),
                    SezonId = table.Column<int>(type: "int", nullable: false),
                    OtelSezonKapasite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtelSezonKapasiteleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtelSezonKapasiteleri_Oteller_OtelId",
                        column: x => x.OtelId,
                        principalTable: "Oteller",
                        principalColumn: "Id"
                        );
                    table.ForeignKey(
                        name: "FK_OtelSezonKapasiteleri_Sezonlar_SezonId",
                        column: x => x.SezonId,
                        principalTable: "Sezonlar",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.InsertData(
                table: "OdaTurleri",
                columns: new[] { "Id", "Aciklama", "OdaTurAdi" },
                values: new object[,]
                {
                    { 1, "Tek Kişilik Oda", "Single Oda" },
                    { 2, "Çift Kişilik Oda", "Double Oda" },
                    { 3, "Üç Kişilik Oda", "Triple Oda" },
                    { 4, "Lüks Oda", "Suit Oda" },
                    { 5, "İki Katlı Oda", "Dublex Oda" },
                    { 6, "Aileler İçin Oda", "Aile Odası" },
                    { 7, "Ultra Lüks Oda", "Kral Dairesi" }
                });

            migrationBuilder.InsertData(
                table: "Sezonlar",
                columns: new[] { "Id", "BaslangicTarihi", "BitisTarihi", "SezonAdi" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yaz" },
                    { 2, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kış" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtelKapasiteleri_OtelId",
                table: "OtelKapasiteleri",
                column: "OtelId");

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

            migrationBuilder.CreateIndex(
                name: "IX_OtelOdalari_OdaTuruId",
                table: "OtelOdalari",
                column: "OdaTuruId");

            migrationBuilder.CreateIndex(
                name: "IX_OtelOdalari_OtelId",
                table: "OtelOdalari",
                column: "OtelId");

            migrationBuilder.CreateIndex(
                name: "IX_OtelSezonKapasiteleri_OtelId",
                table: "OtelSezonKapasiteleri",
                column: "OtelId");

            migrationBuilder.CreateIndex(
                name: "IX_OtelSezonKapasiteleri_SezonId",
                table: "OtelSezonKapasiteleri",
                column: "SezonId");

            migrationBuilder.CreateIndex(
                name: "IX_Sehirler_UlkeId",
                table: "Sehirler",
                column: "UlkeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtelKapasiteleri");

            migrationBuilder.DropTable(
                name: "OtelOdalari");

            migrationBuilder.DropTable(
                name: "OtelSezonKapasiteleri");

            migrationBuilder.DropTable(
                name: "OdaTurleri");

            migrationBuilder.DropTable(
                name: "Oteller");

            migrationBuilder.DropTable(
                name: "Sezonlar");

            migrationBuilder.DropTable(
                name: "OtelTurleri");

            migrationBuilder.DropTable(
                name: "Sehirler");

            migrationBuilder.DropTable(
                name: "Ulkeler");
        }
    }
}
