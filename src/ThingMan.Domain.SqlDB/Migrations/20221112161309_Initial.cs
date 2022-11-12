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
                name: "ThingDefs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingDefs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropDef",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PropType = table.Column<string>(type: "TEXT", nullable: false),
                    ThingDefId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropDef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropDef_ThingDefs_ThingDefId",
                        column: x => x.ThingDefId,
                        principalTable: "ThingDefs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropDef_ThingDefId",
                table: "PropDef",
                column: "ThingDefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropDef");

            migrationBuilder.DropTable(
                name: "ThingDefs");
        }
    }
}
