﻿// <auto-generated />
using System;
using BandAPI.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BandAPI.Migrations
{
    [DbContext(typeof(BandAlbumContext))]
    partial class BandAlbumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BandAPI.Entities.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = new Guid("13936f36-4830-4e71-a83c-212a494b62be"),
                            BandId = new Guid("77e0a4a9-0038-4114-8740-cc031f38e222"),
                            Description = "Description 1",
                            Title = "New 1"
                        },
                        new
                        {
                            Id = new Guid("ca014910-8d1c-4904-b3a0-6870cca54522"),
                            BandId = new Guid("efc3f365-1797-4b9e-be9b-aefd7a3f533f"),
                            Description = "Description 1",
                            Title = "New 1"
                        },
                        new
                        {
                            Id = new Guid("12278022-8c57-4b82-81a1-abe59a5fef92"),
                            BandId = new Guid("77e0a4a9-0038-4114-8740-cc031f38e222"),
                            Description = "Description 1",
                            Title = "New 1"
                        });
                });

            modelBuilder.Entity("BandAPI.Entities.Band", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Founded")
                        .HasColumnType("datetime2");

                    b.Property<string>("MainGenre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Bands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("77e0a4a9-0038-4114-8740-cc031f38e222"),
                            Founded = new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Disco",
                            Name = "A"
                        },
                        new
                        {
                            Id = new Guid("db2baa95-d123-4f5c-9402-79b414c6392d"),
                            Founded = new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Disco",
                            Name = "New"
                        },
                        new
                        {
                            Id = new Guid("efc3f365-1797-4b9e-be9b-aefd7a3f533f"),
                            Founded = new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Rock",
                            Name = "B"
                        },
                        new
                        {
                            Id = new Guid("487142e9-5f83-4e65-9ebc-975bb42018a5"),
                            Founded = new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Pop",
                            Name = "C"
                        },
                        new
                        {
                            Id = new Guid("adcac28c-703c-4eca-9ef7-9a0c29478c5f"),
                            Founded = new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Disco",
                            Name = "D"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
