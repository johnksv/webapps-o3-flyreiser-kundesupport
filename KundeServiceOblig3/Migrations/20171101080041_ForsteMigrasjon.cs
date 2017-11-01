using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KundeServiceOblig3.Migrations
{
    public partial class ForsteMigrasjon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kundebehandlere",
                columns: table => new
                {
                    Brukernavn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Passord = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kundebehandlere", x => x.Brukernavn);
                });

            migrationBuilder.CreateTable(
                name: "Svar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Besvart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BesvartAvBrukernavn = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Svar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Svar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Svar_Kundebehandlere_BesvartAvBrukernavn",
                        column: x => x.BesvartAvBrukernavn,
                        principalTable: "Kundebehandlere",
                        principalColumn: "Brukernavn",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sporsmal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Publisert = table.Column<bool>(type: "bit", nullable: false),
                    Sporsmal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stilt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SvarID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sporsmal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sporsmal_Svar_SvarID",
                        column: x => x.SvarID,
                        principalTable: "Svar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkjemaSporsmal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Epost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etternavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fornavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SporsmalID = table.Column<int>(type: "int", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkjemaSporsmal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SkjemaSporsmal_Sporsmal_SporsmalID",
                        column: x => x.SporsmalID,
                        principalTable: "Sporsmal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkjemaSporsmal_SporsmalID",
                table: "SkjemaSporsmal",
                column: "SporsmalID");

            migrationBuilder.CreateIndex(
                name: "IX_Sporsmal_SvarID",
                table: "Sporsmal",
                column: "SvarID");

            migrationBuilder.CreateIndex(
                name: "IX_Svar_BesvartAvBrukernavn",
                table: "Svar",
                column: "BesvartAvBrukernavn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkjemaSporsmal");

            migrationBuilder.DropTable(
                name: "Sporsmal");

            migrationBuilder.DropTable(
                name: "Svar");

            migrationBuilder.DropTable(
                name: "Kundebehandlere");
        }
    }
}
