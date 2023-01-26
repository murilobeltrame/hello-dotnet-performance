using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wineyard.Models;

namespace Wineyard.Api._7.Controllers
{
    [Route("grapes")]
    [ApiController]
    public class Grapes : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Grapes(ApplicationContext context) => _context = context;

        // GET: api/Grapes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grape>>> GetGrapes() =>
            await _context.Grapes.ToListAsync();

        // GET: api/Grapes/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Grape>> GetGrape(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return BadRequest();
            if (_context.Grapes == null) return NotFound();
            var grape = await _context.Grapes
                .FirstOrDefaultAsync(w => string.Equals(w.Name, name, StringComparison.InvariantCultureIgnoreCase));
            if (grape == null) return NotFound();
            return grape;
        }

        // PUT: api/Grapes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{name}")]
        public async Task<IActionResult> PutGrape(string name, Grape grape)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                !string.Equals(name, grape.Name, StringComparison.InvariantCultureIgnoreCase))
                return BadRequest();
            _context.Entry(grape).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrapeExists(name)) return NotFound();
                throw;
            }
            return NoContent();
        }

        // POST: api/Grapes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grape>> PostGrape(Grape grape)
        {
            if (_context.Grapes == null)
                return Problem("Entity set 'ApplicationContext.Grapes'  is null.");
            _context.Grapes.Add(grape);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGrape), new { name = grape.Name }, grape);
        }

        // DELETE: api/Grapes/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteGrape(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return BadRequest();
            if (_context.Grapes == null) return NotFound();
            var grape = await _context.Grapes
                .FirstOrDefaultAsync(w => string.Equals(name, w.Name, StringComparison.InvariantCultureIgnoreCase));
            if (grape == null) return NotFound();
            _context.Grapes.Remove(grape);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool GrapeExists(string name)
        {
            return (_context.Grapes?.Any(e => string.Equals(name, e.Name, StringComparison.InvariantCultureIgnoreCase))).GetValueOrDefault();
        }
    }
}
