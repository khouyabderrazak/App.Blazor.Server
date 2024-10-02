using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Projet_App.Migrations
{
    /// <inheritdoc />
    public partial class Someupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipeCollaborateurs_Collaborateurs_CollaborateurId",
                table: "EquipeCollaborateurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Collaborateurs_ChefId",
                table: "Equipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Projets_Collaborateurs_ManagerID",
                table: "Projets");

            migrationBuilder.DropForeignKey(
                name: "FK_TacheCollaborateurs_Collaborateurs_CollaborateurId",
                table: "TacheCollaborateurs");

            migrationBuilder.DropTable(
                name: "Collaborateurs");

            migrationBuilder.AlterColumn<string>(
                name: "CollaborateurId",
                table: "TacheCollaborateurs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerID",
                table: "Projets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChefId",
                table: "Equipes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CollaborateurId",
                table: "EquipeCollaborateurs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeCollaborateurs_AspNetUsers_CollaborateurId",
                table: "EquipeCollaborateurs",
                column: "CollaborateurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_AspNetUsers_ChefId",
                table: "Equipes",
                column: "ChefId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projets_AspNetUsers_ManagerID",
                table: "Projets",
                column: "ManagerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TacheCollaborateurs_AspNetUsers_CollaborateurId",
                table: "TacheCollaborateurs",
                column: "CollaborateurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipeCollaborateurs_AspNetUsers_CollaborateurId",
                table: "EquipeCollaborateurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_AspNetUsers_ChefId",
                table: "Equipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Projets_AspNetUsers_ManagerID",
                table: "Projets");

            migrationBuilder.DropForeignKey(
                name: "FK_TacheCollaborateurs_AspNetUsers_CollaborateurId",
                table: "TacheCollaborateurs");

            migrationBuilder.AlterColumn<int>(
                name: "CollaborateurId",
                table: "TacheCollaborateurs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerID",
                table: "Projets",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChefId",
                table: "Equipes",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CollaborateurId",
                table: "EquipeCollaborateurs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Collaborateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomComplet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborateurs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeCollaborateurs_Collaborateurs_CollaborateurId",
                table: "EquipeCollaborateurs",
                column: "CollaborateurId",
                principalTable: "Collaborateurs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Collaborateurs_ChefId",
                table: "Equipes",
                column: "ChefId",
                principalTable: "Collaborateurs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projets_Collaborateurs_ManagerID",
                table: "Projets",
                column: "ManagerID",
                principalTable: "Collaborateurs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TacheCollaborateurs_Collaborateurs_CollaborateurId",
                table: "TacheCollaborateurs",
                column: "CollaborateurId",
                principalTable: "Collaborateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
