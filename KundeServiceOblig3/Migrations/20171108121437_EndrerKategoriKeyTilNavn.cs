using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KundeServiceOblig3.Migrations
{
    public partial class EndrerKategoriKeyTilNavn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SporsmalOgSvar_Kategorier_KategoriID",
                table: "SporsmalOgSvar");

            migrationBuilder.DropIndex(
                name: "IX_SporsmalOgSvar_KategoriID",
                table: "SporsmalOgSvar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategorier",
                table: "Kategorier");

            migrationBuilder.DropColumn(
                name: "KategoriID",
                table: "SporsmalOgSvar");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Kategorier");

            migrationBuilder.AddColumn<string>(
                name: "KategoriNavn",
                table: "SporsmalOgSvar",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Navn",
                table: "Kategorier",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategorier",
                table: "Kategorier",
                column: "Navn");

            migrationBuilder.CreateIndex(
                name: "IX_SporsmalOgSvar_KategoriNavn",
                table: "SporsmalOgSvar",
                column: "KategoriNavn");

            migrationBuilder.AddForeignKey(
                name: "FK_SporsmalOgSvar_Kategorier_KategoriNavn",
                table: "SporsmalOgSvar",
                column: "KategoriNavn",
                principalTable: "Kategorier",
                principalColumn: "Navn",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SporsmalOgSvar_Kategorier_KategoriNavn",
                table: "SporsmalOgSvar");

            migrationBuilder.DropIndex(
                name: "IX_SporsmalOgSvar_KategoriNavn",
                table: "SporsmalOgSvar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategorier",
                table: "Kategorier");

            migrationBuilder.DropColumn(
                name: "KategoriNavn",
                table: "SporsmalOgSvar");

            migrationBuilder.AddColumn<int>(
                name: "KategoriID",
                table: "SporsmalOgSvar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Navn",
                table: "Kategorier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Kategorier",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategorier",
                table: "Kategorier",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_SporsmalOgSvar_KategoriID",
                table: "SporsmalOgSvar",
                column: "KategoriID");

            migrationBuilder.AddForeignKey(
                name: "FK_SporsmalOgSvar_Kategorier_KategoriID",
                table: "SporsmalOgSvar",
                column: "KategoriID",
                principalTable: "Kategorier",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
