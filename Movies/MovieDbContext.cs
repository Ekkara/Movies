using Microsoft.EntityFrameworkCore;
using Movies.Models.Domain;
using System.Diagnostics.CodeAnalysis;

namespace Movies
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Franchise> Franchises { get;set; }

        public MovieDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed data
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 1, Title = "Parry Hotter", Genre = "Fantasy", ReleaseYear = 2001, Director = "ChrisCol", Picture = "hueHUEUHE", Trailer = "Ex-Smelly-Armpits", franchiseID = 1});
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 2, Title = "Sword of the Wings", Genre = "Fantasy", ReleaseYear = 2002, Director = "Mikael Niazi", Picture = "presshush", Trailer = "ISENGARD", franchiseID = 2});
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 3, Title = "War Stars", Genre = "SciFi", ReleaseYear = 1974, Director = "Xyz", Picture = "Daddy", Trailer = "...", franchiseID = 3 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 4, Title = "Parry Hotter 2", Genre = "Fantasy", ReleaseYear = 2019, Director = "ChrisCol", Picture = "HUEHeEUHE", Trailer = "Ex-Smelly-Armpits" , franchiseID = 1 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 5, Title = "Honungens Återkomst", Genre = "Fantasy", ReleaseYear = 2069, Director = "Mikael Niazi", Picture = "presshush", Trailer = "ISENGARD" , franchiseID = 2 });

            modelBuilder.Entity<Character>().HasData(new Character { Id = 1, Name = "Fred", Gender = "Monki", Alias = "George", Picture = ":)", MovieId = 1 });
            modelBuilder.Entity<Character>().HasData(new Character { Id = 2, Name = "Sean Stark", Gender = "Female", Alias = "Shtark", Picture = "x(", MovieId = 2 });
            modelBuilder.Entity<Character>().HasData(new Character { Id = 3, Name = "YarYar", Gender = "I have no damn clue", Alias = "Meme.gif", Picture = "====)", MovieId = 3 });
            modelBuilder.Entity<Character>().HasData(new Character { Id = 4, Name = "George", Gender = "Monki", Alias = "Fred", Picture = ":)", MovieId = 1 });

            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 1, Name = "Harry... Potter...", Description = "They're still good despite scuffed author" });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 2, Name = "Sagan om ringen", Description = "Actually best moovis" });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 3, Name = "Star Wars", Description = "Oh. Oh dear..." });

            modelBuilder.Entity<Character>()
                .HasMany(p => p.Movies)
                .WithMany(m => m.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterMovie",
                    r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    je =>
                    {
                        je.HasKey("CharacterId", "MovieId");
                        je.HasData(
                            new { CharacterId = 1, MovieId = 1 },
                            new { CharacterId = 1, MovieId = 4 },
                            new { CharacterId = 2, MovieId = 2 },
                            new { CharacterId = 2, MovieId = 5 },
                            new { CharacterId = 3, MovieId = 3 },
                            new { CharacterId = 4, MovieId = 1 },
                            new { CharacterId = 4, MovieId = 4 }
                            );
                    });

        }
    }
}
