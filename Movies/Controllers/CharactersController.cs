using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Models.Domain;
using Movies.Models.DTO.Character;
using Movies.Services;
using System.Net.Mime;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICharacterService _characterService;

        public CharactersController(MovieDbContext context, ICharacterService characterService, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _characterService = characterService;
        }

        /// <summary>
        /// Gets all character resources
        /// </summary>
        /// <returns>List of characters</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        /// <summary>
        /// Get character with a specific ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A given character</returns>
        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Edit character information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterEdit"></param>
        /// <returns>New character data</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterEditDTO characterEdit)
        {
            if (id != characterEdit.Id)
            {
                return BadRequest();
            }

            try
            {
                await _characterService.UpdateAsync(
                    _mapper.Map<Character>(characterEdit)
                );
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        /// <summary>
        /// Create a new character
        /// </summary>
        /// <param name="characterDTO"></param>
        /// <returns>Created character</returns>
        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterCreateDTO characterDTO)
        {
            Character character = _mapper.Map<Character>(characterDTO);
            _context.Characters.Add(character);
            await _characterService.AddAsync(character);
            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        }

        /// <summary>
        /// Delete a certain character
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Nothingness left behind</returns>
        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
