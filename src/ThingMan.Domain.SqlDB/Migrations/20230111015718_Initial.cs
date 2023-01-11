using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThingMan.Domain.SqlDB.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropDef",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropDef", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThingDefs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    PropDef1Id = table.Column<string>(type: "TEXT", nullable: true),
                    PropDef2Id = table.Column<string>(type: "TEXT", nullable: true),
                    PropDef3Id = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingDefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThingDefs_PropDef_PropDef1Id",
                        column: x => x.PropDef1Id,
                        principalTable: "PropDef",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThingDefs_PropDef_PropDef2Id",
                        column: x => x.PropDef2Id,
                        principalTable: "PropDef",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThingDefs_PropDef_PropDef3Id",
                        column: x => x.PropDef3Id,
                        principalTable: "PropDef",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThingDefs_PropDef1Id",
                table: "ThingDefs",
                column: "PropDef1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThingDefs_PropDef2Id",
                table: "ThingDefs",
                column: "PropDef2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThingDefs_PropDef3Id",
                table: "ThingDefs",
                column: "PropDef3Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThingDefs");

            migrationBuilder.DropTable(
                name: "PropDef");
        }
    }
}
