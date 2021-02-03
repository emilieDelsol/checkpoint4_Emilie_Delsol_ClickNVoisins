using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorrectionCheckpoint3.Data.Migrations
{
    public partial class addvillageAndDept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillageId",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    DepartementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartementName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.DepartementId);
                });

            migrationBuilder.CreateTable(
                name: "Village",
                columns: table => new
                {
                    VillageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillageName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DepartementId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Village", x => x.VillageId);
                    table.ForeignKey(
                        name: "FK_Village_Departement_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departement",
                        principalColumn: "DepartementId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_VillageId",
                table: "Category",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_Village_DepartementId",
                table: "Village",
                column: "DepartementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Village_VillageId",
                table: "Category",
                column: "VillageId",
                principalTable: "Village",
                principalColumn: "VillageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Village_VillageId",
                table: "Category");

            migrationBuilder.DropTable(
                name: "Village");

            migrationBuilder.DropTable(
                name: "Departement");

            migrationBuilder.DropIndex(
                name: "IX_Category_VillageId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "VillageId",
                table: "Category");
        }
    }
}
