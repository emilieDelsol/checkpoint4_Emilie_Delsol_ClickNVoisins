using Microsoft.EntityFrameworkCore.Migrations;

namespace clickAndV.Migrations
{
    public partial class addDbSetDepartement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Villages_VillageId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Villages_Departement_DepartementId",
                table: "Villages");

            migrationBuilder.AlterColumn<int>(
                name: "DepartementId",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VillageId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Villages_VillageId",
                table: "Categories",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "VillageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Villages_Departement_DepartementId",
                table: "Villages",
                column: "DepartementId",
                principalTable: "Departement",
                principalColumn: "DepartementId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Villages_VillageId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Villages_Departement_DepartementId",
                table: "Villages");

            migrationBuilder.AlterColumn<int>(
                name: "DepartementId",
                table: "Villages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VillageId",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Villages_VillageId",
                table: "Categories",
                column: "VillageId",
                principalTable: "Villages",
                principalColumn: "VillageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Villages_Departement_DepartementId",
                table: "Villages",
                column: "DepartementId",
                principalTable: "Departement",
                principalColumn: "DepartementId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
