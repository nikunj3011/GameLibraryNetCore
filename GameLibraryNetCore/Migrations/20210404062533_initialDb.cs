using Microsoft.EntityFrameworkCore.Migrations;

namespace GameLibraryNetCore.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameSystem",
                columns: table => new
                {
                    GameSystemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSystem", x => x.GameSystemID);
                });

            migrationBuilder.CreateTable(
                name: "GameLibrary",
                columns: table => new
                {
                    GameLibraryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    GameSystemID = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    DiscType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameLibrary", x => x.GameLibraryID);
                    table.ForeignKey(
                        name: "FK_GameLibrary_GameSystem_GameSystemID",
                        column: x => x.GameSystemID,
                        principalTable: "GameSystem",
                        principalColumn: "GameSystemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameLibrary_GameSystemID",
                table: "GameLibrary",
                column: "GameSystemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameLibrary");

            migrationBuilder.DropTable(
                name: "GameSystem");
        }
    }
}
