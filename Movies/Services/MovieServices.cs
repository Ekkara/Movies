using Microsoft.EntityFrameworkCore;
using Movies.Models.Domain;

namespace Movies.Services
{
    public class MovieServices: IMovieService
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<MovieServices> _logger;
        public MovieServices(MovieDbContext context, ILogger<MovieServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task UpdateAsync(Movie entity)
        {
            // Log and throw pattern
            if (!await MovieExistsAsync(entity.Id))
            {
                _logger.LogError("Movie not found with Id: " + entity.Id);
                throw new Exception("Movie not found with Id: " + entity.Id);
            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        private async Task<bool> MovieExistsAsync(int id)
        {
            return await _context.Movies.AnyAsync(e => e.Id == id);
        }
        public async Task DeleteByIdAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            // Log and throw pattern
            if (movie == null)
            {
                _logger.LogError("Moovii not found with Id: " + id);
                throw new Exception();
            }
            // We set our entities to have nullable relationships
            // so it removes the FKs when delete it.
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
