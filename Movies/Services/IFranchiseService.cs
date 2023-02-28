using Movies.Models.Domain;

namespace Movies.Services
{
    public interface IFranchiseService
    {
        Task<Franchise> AddAsync(Franchise franchise);
        Task UpdateAsync(Franchise franchise);
    }
}
