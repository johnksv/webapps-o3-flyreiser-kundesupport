using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KundeServiceOblig3.Migrations
{
    public partial class FjernerKundebehandler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Svar_Kundebehandlere_BesvartAvKundebehandlerBrukernavn",
                table: "Svar");

            migrationBuilder.DropTable(
                name: "Kundebehandlere");

            migrationBuilder.DropIndex(
                name: "IX_Svar_BesvartAvKundebehandlerBrukernavn",
                table: "Svar");

            migrationBuilder.DropColumn(
                name: "BesvartAvKundebehandlerBrukernavn",
                table: "Svar");

            migrationBuilder.AddColumn<string>(
                name: "BesvartAv",
                table: "Svar",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BesvartAv",
                table: "Svar");

            migrationBuilder.AddColumn<string>(
                name: "BesvartAvKundebehandlerBrukernavn",
                table: "Svar",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kundebehandlere",
                columns: table => new
                {
                    Brukernavn = table.Column<string>(nullable: false),
                    Passord = table.Column<byte[]>(nullable: true),
                    Salt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kundebehandlere", x => x.Brukernavn);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Svar_BesvartAvKundebehandlerBrukernavn",
                table: "Svar",
                column: "BesvartAvKundebehandlerBrukernavn");

            migrationBuilder.AddForeignKey(
                name: "FK_Svar_Kundebehandlere_BesvartAvKundebehandlerBrukernavn",
                table: "Svar",
                column: "BesvartAvKundebehandlerBrukernavn",
                principalTable: "Kundebehandlere",
                principalColumn: "Brukernavn",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
