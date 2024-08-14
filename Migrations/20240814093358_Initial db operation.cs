using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APINEW.Migrations
{
    /// <inheritdoc />
    public partial class Initialdboperation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    kitapid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kitapAd = table.Column<string>(type: "text", nullable: false),
                    yazar = table.Column<string>(type: "text", nullable: false),
                    tur = table.Column<string>(type: "text", nullable: false),
                    sayfa = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.kitapid);
                });

            migrationBuilder.CreateTable(
                name: "SoldTours",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Userid = table.Column<int>(type: "integer", nullable: false),
                    Tourid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldTours", x => x.id);
                    table.ForeignKey(
                        name: "FK_SoldTours_Tours_Tourid",
                        column: x => x.Tourid,
                        principalTable: "Tours",
                        principalColumn: "kitapid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoldTours_Tourid",
                table: "SoldTours",
                column: "Tourid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoldTours");

            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
