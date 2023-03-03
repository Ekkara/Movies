using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Movies.Models.Domain;
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

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises() {
            return await _context.Franchises.ToListAsync();
        }

        // GET: api/Franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id) {
            var franchise = await _context.Franchises.FindAsync(id);

            if (franchise == null) {
                return NotFound();
            }

            return franchise;
        }

        [HttpGet("{franchiseId}/moviesInFranchies")]
        public async Task<ActionResult<List<Movie>>> GetMoviesInFranchise(int franchiseId) {
            var movies = await _context.Movies.ToListAsync();
            Console.WriteLine("sdasdadasdafkangjakfngöoasfnfgjagnajsganjgnäagnjadg");
            Console.WriteLine(movies.Count);
            Console.WriteLine(movies[0].FranchiseID);
            movies = movies.Where(movie => movie.FranchiseID == franchiseId).ToList();
            Console.WriteLine(movies.Count);
            return movies;
        }

        [HttpGet("{franchiseId}/characterInFranchise")]
        public async Task<ActionResult<List<Character>>> GetCharactersInFranchise(int franchiseId) {
            if (!FranchiseExists(franchiseId)) {
                return NotFound();
            }
            var movies = await _context.Movies.ToListAsync();
            movies = movies.Where(movie => movie.FranchiseID == franchiseId).ToList();
            var characters = await _context.Characters.ToListAsync();
            
            characters = characters.Where(character => 
                movies.Any(movie => movie.Characters.Contains(character))).ToList();
            
            return characters;
        }

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

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(FranchiseCreateDTO franchiseDTO) {
            Franchise franchise = _mapper.Map<Franchise>(franchiseDTO);
            _context.Franchises.Add(franchise);
            await _franchiseService.AddAsync(franchise);
            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

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
