using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KundeServiceOblig3.Migrations
{
    public partial class OppdaterFeltISvarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Svar_Kundebehandlere_BesvartAvBrukernavn",
                table: "Svar");

            migrationBuilder.DropIndex(
                name: "IX_Svar_BesvartAvBrukernavn",
                table: "Svar");

            migrationBuilder.DropColumn(
                name: "BesvartAvBrukernavn",
                table: "Svar");

            migrationBuilder.AddColumn<string>(
                name: "BesvartAvKundebehandlerBrukernavn",
                table: "Svar",
                type: "nvarchar(450)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Svar_Kundebehandlere_BesvartAvKundebehandlerBrukernavn",
                table: "Svar");

            migrationBuilder.DropIndex(
                name: "IX_Svar_BesvartAvKundebehandlerBrukernavn",
                table: "Svar");

            migrationBuilder.DropColumn(
                name: "BesvartAvKundebehandlerBrukernavn",
                table: "Svar");

            migrationBuilder.AddColumn<string>(
                name: "BesvartAvBrukernavn",
                table: "Svar",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Svar_BesvartAvBrukernavn",
                table: "Svar",
                column: "BesvartAvBrukernavn");

            migrationBuilder.AddForeignKey(
                name: "FK_Svar_Kundebehandlere_BesvartAvBrukernavn",
                table: "Svar",
                column: "BesvartAvBrukernavn",
                principalTable: "Kundebehandlere",
                principalColumn: "Brukernavn",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
