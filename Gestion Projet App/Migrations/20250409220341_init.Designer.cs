﻿// <auto-generated />
using System;
using Gestion_Projet_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gestion_Projet_App.Migrations
{
    [DbContext(typeof(Gestion_Projet_AppContext))]
    [Migration("20250409220341_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gestion_Projet_App.Models.Depense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Montant")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProjetId")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.ToTable("Depenses");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Entity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Entity.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Entity.ProjetEquipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EquipeId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjetId")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.HasIndex("ProjetId");

                    b.ToTable("ProjetEquipes");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Equipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChefId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChefId");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.EquipeCollaborateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CollaborateurId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EquipeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CollaborateurId");

                    b.HasIndex("EquipeId");

                    b.ToTable("EquipeCollaborateurs");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Projet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Statut")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientID");

                    b.HasIndex("ManagerID");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Tache", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjetId")
                        .HasColumnType("int");

                    b.Property<int?>("Statut")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.ToTable("Taches");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.TacheCollaborateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CollaborateurId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TacheId")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CollaborateurId");

                    b.HasIndex("TacheId");

                    b.ToTable("TacheCollaborateurs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Depense", b =>
                {
                    b.HasOne("Gestion_Projet_App.Models.Projet", "Projet")
                        .WithMany("Depenses")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projet");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Entity.ProjetEquipe", b =>
                {
                    b.HasOne("Gestion_Projet_App.Models.Equipe", "Equipe")
                        .WithMany("ProjetEquipes")
                        .HasForeignKey("EquipeId");

                    b.HasOne("Gestion_Projet_App.Models.Projet", "Projet")
                        .WithMany("ProjetEquipes")
                        .HasForeignKey("ProjetId");

                    b.Navigation("Equipe");

                    b.Navigation("Projet");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Equipe", b =>
                {
                    b.HasOne("Gestion_Projet_App.Models.Entity.ApplicationUser", "Chef")
                        .WithMany()
                        .HasForeignKey("ChefId");

                    b.Navigation("Chef");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.EquipeCollaborateur", b =>
                {
                    b.HasOne("Gestion_Projet_App.Models.Entity.ApplicationUser", "Collaborateur")
                        .WithMany("EquipeCollaborateurs")
                        .HasForeignKey("CollaborateurId");

                    b.HasOne("Gestion_Projet_App.Models.Equipe", "Equipe")
                        .WithMany("EquipeCollaborateurs")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collaborateur");

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Projet", b =>
                {
                    b.HasOne("Gestion_Projet_App.Models.Entity.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientID");

                    b.HasOne("Gestion_Projet_App.Models.Entity.ApplicationUser", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerID");

                    b.Navigation("Client");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Tache", b =>
                {
                    b.HasOne("Gestion_Projet_App.Models.Projet", "Projet")
                        .WithMany("Taches")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Projet");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.TacheCollaborateur", b =>
                {
                    b.HasOne("Gestion_Projet_App.Models.Entity.ApplicationUser", "Collaborateur")
                        .WithMany()
                        .HasForeignKey("CollaborateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestion_Projet_App.Models.Tache", "Tache")
                        .WithMany("TacheCollaborateurs")
                        .HasForeignKey("TacheId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collaborateur");

                    b.Navigation("Tache");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Gestion_Projet_App.Models.Entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Gestion_Projet_App.Models.Entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Gestion_Projet_App.Models.Entity.ApplicationUser", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestion_Projet_App.Models.Entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Gestion_Projet_App.Models.Entity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Entity.ApplicationUser", b =>
                {
                    b.Navigation("EquipeCollaborateurs");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Entity.Client", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Equipe", b =>
                {
                    b.Navigation("EquipeCollaborateurs");

                    b.Navigation("ProjetEquipes");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Projet", b =>
                {
                    b.Navigation("Depenses");

                    b.Navigation("ProjetEquipes");

                    b.Navigation("Taches");
                });

            modelBuilder.Entity("Gestion_Projet_App.Models.Tache", b =>
                {
                    b.Navigation("TacheCollaborateurs");
                });
#pragma warning restore 612, 618
        }
    }
}
