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
                name: "Sporsmal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sporsmal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stilt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sporsmal", x => x.ID);
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
                name: "SporsmalOgSvar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Publisert = table.Column<bool>(type: "bit", nullable: false),
                    SporsmalID = table.Column<int>(type: "int", nullable: false),
                    SvarID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SporsmalOgSvar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SporsmalOgSvar_Sporsmal_SporsmalID",
                        column: x => x.SporsmalID,
                        principalTable: "Sporsmal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SporsmalOgSvar_Svar_SvarID",
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
                    SporsmalOgSvarID = table.Column<int>(type: "int", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkjemaSporsmal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SkjemaSporsmal_SporsmalOgSvar_SporsmalOgSvarID",
                        column: x => x.SporsmalOgSvarID,
                        principalTable: "SporsmalOgSvar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkjemaSporsmal_SporsmalOgSvarID",
                table: "SkjemaSporsmal",
                column: "SporsmalOgSvarID");

            migrationBuilder.CreateIndex(
                name: "IX_SporsmalOgSvar_SporsmalID",
                table: "SporsmalOgSvar",
                column: "SporsmalID");

            migrationBuilder.CreateIndex(
                name: "IX_SporsmalOgSvar_SvarID",
                table: "SporsmalOgSvar",
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
                name: "SporsmalOgSvar");

            migrationBuilder.DropTable(
                name: "Sporsmal");

            migrationBuilder.DropTable(
                name: "Svar");

            migrationBuilder.DropTable(
                name: "Kundebehandlere");
        }
    }
}
