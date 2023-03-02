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
        public DbSet<Test2> Test2 { get; set; }

        public MovieDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test2>().HasData(new Test2 { Id= 1 , Name = "s", ASD = "ada"});

            //Seed data
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 1, Title = "Harry Potter", Genre = "Fantasy", ReleaseYear = 2001, Director = "ChrisCol", Picture = "Pic", Trailer = "Ex-Smelly-Armpits", FranchiseID = 1 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 2, Title = "Lord of the Rings", Genre = "Fantasy", ReleaseYear = 2002, Director = "Mikael Niazi", Picture = "Pic", Trailer = "ISENGARD", FranchiseID = 2 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 3, Title = "Star Wars", Genre = "SciFi", ReleaseYear = 1974, Director = "Xyz", Picture = "Daddy", Trailer = "Pic", FranchiseID = 3 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 4, Title = "Harry Potter 2", Genre = "Fantasy", ReleaseYear = 2019, Director = "ChrisCol", Picture = "Pic", Trailer = "Ex-Smelly-Armpits", FranchiseID = 1 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 5, Title = "Honungens Återkomst", Genre = "Fantasy", ReleaseYear = 2069, Director = "Mikael Niazi", Picture = "presshush", Trailer = "ISENGARD", FranchiseID = 2 });

            modelBuilder.Entity<Character>().HasData(new Character { Id = 1, Name = "Fred", Gender = "Monki", Alias = "George", Picture = ":)" });
            modelBuilder.Entity<Character>().HasData(new Character { Id = 2, Name = "Sean Stark", Gender = "Female", Alias = "Shtark", Picture = "x(" });
            modelBuilder.Entity<Character>().HasData(new Character { Id = 3, Name = "YarYar", Gender = "I have no damn clue", Alias = "Meme.gif", Picture = "====)" });
            modelBuilder.Entity<Character>().HasData(new Character { Id = 4, Name = "George", Gender = "Monki", Alias = "Fred", Picture = ":)" });

            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 1, Name = "Harry... Potter...", Description = "They're still good despite scuffed author" });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 2, Name = "Sagan om ringen", Description = "Actually best moovis" });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 3, Name = "Star Wars", Description = "Oh. Oh dear..." });


            /*modelBuilder.Entity<Character>()
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
                    });*/

        }
    }
}
