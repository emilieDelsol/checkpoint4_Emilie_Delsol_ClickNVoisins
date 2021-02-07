using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clickAndV.Migrations
{
    public partial class addUserIdGuidInAd3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AspNetUsers_UserId1",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ads_AdId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Ads_AdId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ads",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_UserId1",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Ads");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Ads",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Ads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ads",
                table: "Ads",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_UserId",
                table: "Ads",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AspNetUsers_UserId",
                table: "Ads",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ads_AdId",
                table: "Comments",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Ads_AdId",
                table: "Image",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AspNetUsers_UserId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ads_AdId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Ads_AdId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ads",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_UserId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ads");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Ads",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ads",
                table: "Ads",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_UserId1",
                table: "Ads",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AspNetUsers_UserId1",
                table: "Ads",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ads_AdId",
                table: "Comments",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "AdId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Ads_AdId",
                table: "Image",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "AdId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
