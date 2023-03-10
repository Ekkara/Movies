using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Models.Domain;
using Movies.Models.DTO.Character;
using Movies.Models.DTO.Movie;
using Movies.Services;
using System.ComponentModel;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;

        public MoviesController(IMapper mapper, IMovieService movieService, MovieDbContext context) {
            _context = context;
            _mapper = mapper;
            _movieService = movieService;
        }

        /// <summary>
        /// Get movie information
        /// </summary>
        /// <returns>Movies</returns>
        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies() {           

            return await _context.Movies.ToListAsync();
        }

        /// <summary>
        /// Get a certain movie by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A certain movie</returns>
        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id) {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null) {
                return NotFound();
            }
            
            Movie movieTest = await _context.Movies
               .Include(c => c.Characters)
               .Where(c => c.Id == id)
               .FirstAsync();

            return movie;
        }

        /// <summary>
        /// Edit movie information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieEdit"></param>
        /// <returns>Edited movie details</returns>
        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieEditDTO movieEdit) {
            if (id != movieEdit.Id) {
                return BadRequest();
            }

            // _context.Entry(movie).State = EntityState.Modified;

            try {
                await _movieService.UpdateAsync(
                       _mapper.Map<Movie>(movieEdit)
                   );
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!MovieExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Create a new movie
        /// </summary>
        /// <param name="movieDTO"></param>
        /// <returns>Newly created movie</returns>
        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO movieDTO) {
            Movie movie = _mapper.Map<Movie>(movieDTO);
            _context.Movies.Add(movie);
            await _movieService.AddAsync(movie);
            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        /// <summary>
        /// Delete a given movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The nothingness left behind</returns>
        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id) {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Get characters in a specific movie
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>Characters in a given movie</returns>
        [HttpGet("{movieId}/characterInMovie")]
        public async Task<ActionResult<List<CharacterReadDTO>>> GetCharactersInMovie(int movieId) {
            var movie = await _context.Movies.Include(x => x.Characters).FirstOrDefaultAsync(x => x.Id == movieId);
            if (movie == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<List<CharacterReadDTO>>(movie.Characters.ToList()));    
        }

        private bool MovieExists(int id) {
            return _context.Movies.Any(e => e.Id == id);
        }

        /// <summary>
        /// Update characters appearing in a movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="listOfCharactersId"></param>
        /// <returns>New character information</returns>
        [HttpPut("{id}/characters")]
        public async Task<IActionResult> UpdateCharactersInMovie(int id, List<int> listOfCharactersId) {
            //check if character exist
            if (!MovieExists(id)) {
                return NotFound();
            }

            Movie movie = await _context.Movies.FindAsync(id);
            var characters = await _context.Characters.ToListAsync();
            characters = characters.Where(c => listOfCharactersId.Contains(c.Id)).ToList();

            Console.WriteLine(characters.Count);

            movie.Characters = characters;

            Console.WriteLine(movie.Characters.Count);
            
            try {
                await _context.SaveChangesAsync();
                movie = await _context.Movies.FindAsync(id);
                Console.WriteLine(movie.Characters.Count);
            } catch (DbUpdateConcurrencyException) {
                throw;
            } 
            return NoContent();
        }
    }
}
