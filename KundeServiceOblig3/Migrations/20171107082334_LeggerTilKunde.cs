using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KundeServiceOblig3.Migrations
{
    public partial class LeggerTilKunde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SporsmalOgSvar_Sporsmal_SporsmalID",
                table: "SporsmalOgSvar");

            migrationBuilder.DropTable(
                name: "SkjemaSporsmal");

            migrationBuilder.AlterColumn<int>(
                name: "SporsmalID",
                table: "SporsmalOgSvar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "KundeID",
                table: "SporsmalOgSvar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kunder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Epost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etternavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fornavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunder", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SporsmalOgSvar_KundeID",
                table: "SporsmalOgSvar",
                column: "KundeID");

            migrationBuilder.AddForeignKey(
                name: "FK_SporsmalOgSvar_Kunder_KundeID",
                table: "SporsmalOgSvar",
                column: "KundeID",
                principalTable: "Kunder",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SporsmalOgSvar_Sporsmal_SporsmalID",
                table: "SporsmalOgSvar",
                column: "SporsmalID",
                principalTable: "Sporsmal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SporsmalOgSvar_Kunder_KundeID",
                table: "SporsmalOgSvar");

            migrationBuilder.DropForeignKey(
                name: "FK_SporsmalOgSvar_Sporsmal_SporsmalID",
                table: "SporsmalOgSvar");

            migrationBuilder.DropTable(
                name: "Kunder");

            migrationBuilder.DropIndex(
                name: "IX_SporsmalOgSvar_KundeID",
                table: "SporsmalOgSvar");

            migrationBuilder.DropColumn(
                name: "KundeID",
                table: "SporsmalOgSvar");

            migrationBuilder.AlterColumn<int>(
                name: "SporsmalID",
                table: "SporsmalOgSvar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SkjemaSporsmal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Epost = table.Column<string>(nullable: true),
                    Etternavn = table.Column<string>(nullable: true),
                    Fornavn = table.Column<string>(nullable: true),
                    SporsmalOgSvarID = table.Column<int>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_SporsmalOgSvar_Sporsmal_SporsmalID",
                table: "SporsmalOgSvar",
                column: "SporsmalID",
                principalTable: "Sporsmal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
