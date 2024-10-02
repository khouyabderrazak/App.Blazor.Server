using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Projet_App.Migrations
{
    /// <inheritdoc />
    public partial class addProjetequipeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjetEquipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipeId = table.Column<int>(type: "int", nullable: true),
                    ProjetId = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetEquipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjetEquipes_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjetEquipes_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjetEquipes_EquipeId",
                table: "ProjetEquipes",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetEquipes_ProjetId",
                table: "ProjetEquipes",
                column: "ProjetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjetEquipes");
        }
    }
}
