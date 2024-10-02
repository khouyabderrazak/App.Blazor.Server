using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Projet_App.Migrations
{
    /// <inheritdoc />
    public partial class upadte3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taches_Projets_ProjetId",
                table: "Taches");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Projets_ProjetId",
                table: "Taches",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taches_Projets_ProjetId",
                table: "Taches");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Projets_ProjetId",
                table: "Taches",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id");
        }
    }
}
