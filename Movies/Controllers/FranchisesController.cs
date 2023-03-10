using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Movies.Models.Domain;
using Movies.Models.DTO.Character;
using Movies.Models.DTO.Franchise;
using Movies.Services;
using System.Threading.Tasks.Dataflow;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFranchiseService _franchiseService;

        public FranchisesController(MovieDbContext context, IFranchiseService franchiseService, IMapper mapper) {
            _context = context;
            _mapper = mapper;
            _franchiseService = franchiseService;
        }

        /// <summary>
        /// Get franchises
        /// </summary>
        /// <returns>Franchises</returns>
        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises() {
            return await _context.Franchises.ToListAsync();
        }

        /// <summary>
        /// Get a specific franchise by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A given franchise</returns>
        // GET: api/Franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id) {
            var franchise = await _context.Franchises.FindAsync(id);

            if (franchise == null) {
                return NotFound();
            }

            return franchise;
        }

        /// <summary>
        /// Retrieve movies in a certain franchise
        /// </summary>
        /// <param name="franchiseId"></param>
        /// <returns>Movies from franchise</returns>
        [HttpGet("{franchiseId}/moviesInFranchies")]
        public async Task<ActionResult<List<Movie>>> GetMoviesInFranchise(int franchiseId) {
            if(!FranchiseExists(franchiseId)) {
                return NotFound();
            }

            var movies = await _context.Movies.ToListAsync();
            movies = movies.Where(movie => movie.FranchiseID == franchiseId).ToList();
            if (movies.Count <= 0) {
                return NotFound();
            }
            return movies;
        }

        /// <summary>
        /// Retrieve characters in a certain franchise
        /// </summary>
        /// <param name="franchiseId"></param>
        /// <returns>Characters from franchise</returns>
        [HttpGet("{franchiseId}/characterInFranchise")]
        public async Task<ActionResult<List<CharacterReadDTO>>> GetCharactersInFranchise(int franchiseId) {
            if (!FranchiseExists(franchiseId)) {
                return NotFound();
            }

            var movies = await _context.Movies.Include(x => x.Characters).ToListAsync();
            movies = movies.Where(x => x.FranchiseID == franchiseId).ToList();

            var result = movies.SelectMany(movie => movie.Characters)
                   .GroupBy(character => character.Id)
                   .Select(group => group.First()).ToList();

            if (movies.Count <= 0) {
                return NotFound();
            }            

            return Ok(_mapper.Map<List<CharacterReadDTO>>(result.ToList()));
        }

        /// <summary>
        /// Edit franchise data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchiseEdit"></param>
        /// <returns>New franchise information</returns>
        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseEditDTO franchiseEdit) {
            if (id != franchiseEdit.Id) {
                return BadRequest();
            }
            try {
                await _franchiseService.UpdateAsync(
                    _mapper.Map<Franchise>(franchiseEdit)
                );
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!FranchiseExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            return NoContent();
        }

        /// <summary>
        /// Create a new franchise
        /// </summary>
        /// <param name="franchiseDTO"></param>
        /// <returns>New franchise</returns>
        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(FranchiseCreateDTO franchiseDTO) {
            Franchise franchise = _mapper.Map<Franchise>(franchiseDTO);
            _context.Franchises.Add(franchise);
            await _franchiseService.AddAsync(franchise);
            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        /// <summary>
        /// Delete a given franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The nothingness left behind</returns>
        // DELETE: api/Franchises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id) {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null) {
                return NotFound();
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Update movies contained in a franchise
        /// </summary>
        /// <param name="id"></param>
        /// <param name="listOfMovies"></param>
        /// <returns>Updated movie info</returns>
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateMoviesInFranchise(int id, List<int> listOfMovies) {
            //check if character exist
            Franchise franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null) {
                return NotFound();
            }

            var movies = await _context.Movies.ToListAsync();
            movies = movies.Where(movie => listOfMovies.Contains(movie.Id)).ToList();
            for(int i = 0; i < movies.Count; i++) {
                movies[i].FranchiseID = franchise.Id;
            }
            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                throw;
            }
            return NoContent();
        }

        private bool FranchiseExists(int id) {
            return _context.Franchises.Any(e => e.Id == id);
        }
    }
}
