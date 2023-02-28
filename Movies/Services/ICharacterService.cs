using Movies.Models.Domain;

namespace Movies.Services
{
    public interface ICharacterService
    {
        Task<Character> AddAsync(Character character);
        Task UpdateAsync(Character character);
    }
}
