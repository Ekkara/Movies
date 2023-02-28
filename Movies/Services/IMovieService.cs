using Movies.Models.Domain;

namespace Movies.Services
{
    public interface IMovieService
    {
        Task<Movie> AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
    }
}
