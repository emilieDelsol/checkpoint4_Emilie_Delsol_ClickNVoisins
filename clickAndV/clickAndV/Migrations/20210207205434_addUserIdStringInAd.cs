using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clickAndV.Migrations
{
    public partial class addUserIdStringInAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ads_AdId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Ads_AdId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ads",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ads");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ads",
                table: "Ads",
                column: "AdId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ads_AdId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Ads_AdId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ads",
                table: "Ads");

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
    }
}
