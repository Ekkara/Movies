﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movies;

#nullable disable

namespace Movies.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20230228142227_CharController")]
    partial class CharController
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("CharacterMovie");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            MovieId = 1
                        },
                        new
                        {
                            CharacterId = 1,
                            MovieId = 4
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 2
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 5
                        },
                        new
                        {
                            CharacterId = 3,
                            MovieId = 3
                        },
                        new
                        {
                            CharacterId = 4,
                            MovieId = 1
                        },
                        new
                        {
                            CharacterId = 4,
                            MovieId = 4
                        });
                });

            modelBuilder.Entity("Movies.Models.Domain.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "George",
                            Gender = "Monki",
                            MovieId = 1,
                            Name = "Fred",
                            Picture = ":)"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Shtark",
                            Gender = "Female",
                            MovieId = 2,
                            Name = "Sean Stark",
                            Picture = "x("
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Meme.gif",
                            Gender = "I have no damn clue",
                            MovieId = 3,
                            Name = "YarYar",
                            Picture = "====)"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "Fred",
                            Gender = "Monki",
                            MovieId = 1,
                            Name = "George",
                            Picture = ":)"
                        });
                });

            modelBuilder.Entity("Movies.Models.Domain.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Franchises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "They're still good despite scuffed author",
                            Name = "Harry... Potter..."
                        },
                        new
                        {
                            Id = 2,
                            Description = "Actually best moovis",
                            Name = "Sagan om ringen"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Oh. Oh dear...",
                            Name = "Star Wars"
                        });
                });

            modelBuilder.Entity("Movies.Models.Domain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FranchiseID")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseID");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "ChrisCol",
                            FranchiseID = 1,
                            Genre = "Fantasy",
                            Picture = "Pic",
                            ReleaseYear = 2001,
                            Title = "Harry Potter",
                            Trailer = "Ex-Smelly-Armpits"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Mikael Niazi",
                            FranchiseID = 2,
                            Genre = "Fantasy",
                            Picture = "Pic",
                            ReleaseYear = 2002,
                            Title = "Lord of the Rings",
                            Trailer = "ISENGARD"
                        },
                        new
                        {
                            Id = 3,
                            Director = "Xyz",
                            FranchiseID = 3,
                            Genre = "SciFi",
                            Picture = "Daddy",
                            ReleaseYear = 1974,
                            Title = "Star Wars",
                            Trailer = "Pic"
                        },
                        new
                        {
                            Id = 4,
                            Director = "ChrisCol",
                            FranchiseID = 1,
                            Genre = "Fantasy",
                            Picture = "Pic",
                            ReleaseYear = 2019,
                            Title = "Harry Potter 2",
                            Trailer = "Ex-Smelly-Armpits"
                        },
                        new
                        {
                            Id = 5,
                            Director = "Mikael Niazi",
                            FranchiseID = 2,
                            Genre = "Fantasy",
                            Picture = "presshush",
                            ReleaseYear = 2069,
                            Title = "Honungens Återkomst",
                            Trailer = "ISENGARD"
                        });
                });

            modelBuilder.Entity("Movies.Models.Domain.Test2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ASD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Test2");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ASD = "ada",
                            Name = "s"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("Movies.Models.Domain.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movies.Models.Domain.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Movies.Models.Domain.Franchise", b =>
                {
                    b.HasOne("Movies.Models.Domain.Franchise", null)
                        .WithMany("Franchises")
                        .HasForeignKey("FranchiseId");
                });

            modelBuilder.Entity("Movies.Models.Domain.Movie", b =>
                {
                    b.HasOne("Movies.Models.Domain.Franchise", "Franchise")
                        .WithMany()
                        .HasForeignKey("FranchiseID");

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("Movies.Models.Domain.Franchise", b =>
                {
                    b.Navigation("Franchises");
                });
#pragma warning restore 612, 618
        }
    }
}
