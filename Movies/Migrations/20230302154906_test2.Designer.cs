// <auto-generated />
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
    [Migration("20230302154906_test2")]
    partial class test2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.HasIndex("MovieId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "George",
                            Gender = "Monki",
                            Name = "Fred",
                            Picture = ":)"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Shtark",
                            Gender = "Female",
                            Name = "Sean Stark",
                            Picture = "x("
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Meme.gif",
                            Gender = "I have no damn clue",
                            Name = "YarYar",
                            Picture = "====)"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "Fred",
                            Gender = "Monki",
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

            modelBuilder.Entity("Movies.Models.Domain.Character", b =>
                {
                    b.HasOne("Movies.Models.Domain.Movie", null)
                        .WithMany("Characters")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("Movies.Models.Domain.Movie", b =>
                {
                    b.HasOne("Movies.Models.Domain.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseID");

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("Movies.Models.Domain.Franchise", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Movies.Models.Domain.Movie", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
