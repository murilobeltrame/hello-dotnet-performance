﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Wineyard.Models;

#nullable disable

namespace Wineyard.Tools.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230126014952_fix-relationships")]
    partial class fixrelationships
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GrapeWine", b =>
                {
                    b.Property<string>("GrapesName")
                        .HasColumnType("character varying(50)");

                    b.Property<string>("WinesWineryName")
                        .HasColumnType("character varying(50)");

                    b.Property<string>("WinesLabel")
                        .HasColumnType("character varying(50)");

                    b.HasKey("GrapesName", "WinesWineryName", "WinesLabel");

                    b.HasIndex("WinesWineryName", "WinesLabel");

                    b.ToTable("GrapeWine");
                });

            modelBuilder.Entity("Wineyard.Models.Grape", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Name");

                    b.ToTable("Grapes");
                });

            modelBuilder.Entity("Wineyard.Models.Wine", b =>
                {
                    b.Property<string>("WineryName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Label")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<int>("Vintage")
                        .HasColumnType("integer");

                    b.HasKey("WineryName", "Label");

                    b.ToTable("Wines");
                });

            modelBuilder.Entity("GrapeWine", b =>
                {
                    b.HasOne("Wineyard.Models.Grape", null)
                        .WithMany()
                        .HasForeignKey("GrapesName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wineyard.Models.Wine", null)
                        .WithMany()
                        .HasForeignKey("WinesWineryName", "WinesLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
