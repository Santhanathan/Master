using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Long = table.Column<double>(type: "float", nullable: false),
                    populatiom = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WalkDificulty",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkDificulty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "walks",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    length = table.Column<double>(type: "float", nullable: false),
                    RegionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalkDifficultyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_walks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_walks_WalkDificulty_WalkDifficultyID",
                        column: x => x.WalkDifficultyID,
                        principalTable: "WalkDificulty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_walks_regions_RegionID",
                        column: x => x.RegionID,
                        principalTable: "regions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_walks_RegionID",
                table: "walks",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_walks_WalkDifficultyID",
                table: "walks",
                column: "WalkDifficultyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "walks");

            migrationBuilder.DropTable(
                name: "WalkDificulty");

            migrationBuilder.DropTable(
                name: "regions");
        }
    }
}
