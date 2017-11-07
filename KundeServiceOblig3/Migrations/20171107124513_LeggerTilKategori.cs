using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KundeServiceOblig3.Migrations
{
    public partial class LeggerTilKategori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SporsmalOgSvar_Sporsmal_SporsmalID",
                table: "SporsmalOgSvar");

            migrationBuilder.AlterColumn<int>(
                name: "SporsmalID",
                table: "SporsmalOgSvar",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KategoriID",
                table: "SporsmalOgSvar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kategorier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorier", x => x.ID);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_SporsmalOgSvar_Sporsmal_SporsmalID",
                table: "SporsmalOgSvar",
                column: "SporsmalID",
                principalTable: "Sporsmal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SporsmalOgSvar_Kategorier_KategoriID",
                table: "SporsmalOgSvar");

            migrationBuilder.DropForeignKey(
                name: "FK_SporsmalOgSvar_Sporsmal_SporsmalID",
                table: "SporsmalOgSvar");

            migrationBuilder.DropTable(
                name: "Kategorier");

            migrationBuilder.DropIndex(
                name: "IX_SporsmalOgSvar_KategoriID",
                table: "SporsmalOgSvar");

            migrationBuilder.DropColumn(
                name: "KategoriID",
                table: "SporsmalOgSvar");

            migrationBuilder.AlterColumn<int>(
                name: "SporsmalID",
                table: "SporsmalOgSvar",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SporsmalOgSvar_Sporsmal_SporsmalID",
                table: "SporsmalOgSvar",
                column: "SporsmalID",
                principalTable: "Sporsmal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
