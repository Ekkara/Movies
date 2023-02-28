using Microsoft.EntityFrameworkCore;
using Movies.Models.Domain;

namespace Movies.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<FranchiseService> _logger;
        public FranchiseService(MovieDbContext context, ILogger<FranchiseService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Franchise> AddAsync(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();
            return franchise;
        }
        public async Task UpdateAsync(Franchise entity)
        {
            // Log and throw pattern
            if (!await FranchiseExistsAsync(entity.Id))
            {
                _logger.LogError("Franchise not found with Id: " + entity.Id);
                throw new Exception("Franchise not found with Id: " + entity.Id);
            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        private async Task<bool> FranchiseExistsAsync(int id)
        {
            return await _context.Franchises.AnyAsync(e => e.Id == id);
        }
        public async Task DeleteByIdAsync(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            // Log and throw pattern
            if (franchise == null)
            {
                _logger.LogError("Franchise not found with Id: " + id);
                throw new Exception();
            }
            // We set our entities to have nullable relationships
            // so it removes the FKs when delete it.
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }
    }
}
