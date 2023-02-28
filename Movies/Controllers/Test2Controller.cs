using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies;
using Movies.Models.Domain;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test2Controller : ControllerBase
    {
        private readonly MovieDbContext _context;

        public Test2Controller(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/Test2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test2>>> GetTest2()
        {
            return await _context.Test2.ToListAsync();
        }

        // GET: api/Test2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Test2>> GetTest2(int id)
        {
            var test2 = await _context.Test2.FindAsync(id);

            if (test2 == null)
            {
                return NotFound();
            }

            return test2;
        }

        // PUT: api/Test2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest2(int id, Test2 test2)
        {
            if (id != test2.Id)
            {
                return BadRequest();
            }

            _context.Entry(test2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Test2Exists(id))
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

        // POST: api/Test2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Test2>> PostTest2(Test2 test2)
        {
            _context.Test2.Add(test2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTest2", new { id = test2.Id }, test2);
        }

        // DELETE: api/Test2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest2(int id)
        {
            var test2 = await _context.Test2.FindAsync(id);
            if (test2 == null)
            {
                return NotFound();
            }

            _context.Test2.Remove(test2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Test2Exists(int id)
        {
            return _context.Test2.Any(e => e.Id == id);
        }
    }
}
