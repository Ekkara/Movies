using Microsoft.EntityFrameworkCore;
using Movies.Models.Domain;

namespace Movies.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<CharacterService> _logger;
        public CharacterService(MovieDbContext context, ILogger<CharacterService> logger) {
            _context = context;
            _logger = logger;
        }

        //making sure we add character asynchronously 
        public async Task<Character> AddAsync(Character character) {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        //update a character asynchronously
        public async Task UpdateAsync(Character entity) {
            // Log and throw pattern
            if (!await CharacterExistsAsync(entity.Id)) {
                _logger.LogError("Character not found with Id: " + entity.Id);
                throw new Exception("Character not found with Id: " + entity.Id);
            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //check if a character exist asynchronously
        private async Task<bool> CharacterExistsAsync(int id) {
            return await _context.Characters.AnyAsync(e => e.Id == id);
        }

        //delete character asynchronously
        public async Task DeleteByIdAsync(int id) {
            var character = await _context.Characters.FindAsync(id);
            // Log and throw pattern
            if (character == null) {
                _logger.LogError("Character not found with Id: " + id);
                throw new Exception();
            }
            // We set our entities to have nullable relationships
            // so it removes the FKs when delete it.
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }
    }
}
