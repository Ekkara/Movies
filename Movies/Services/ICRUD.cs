using Movies.Models.Domain;

namespace Movies.Services
{
    public interface ICRUD<T>
    {
        Task<T> AddAsync(T taip);
        Task UpdateAsync(T taip);
        Task DeleteByIdAsync(int id);
    }
}
