using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wineyard.Models;

namespace Wineyard.Api._7.Controllers
{
    [Route("wines")]
    [ApiController]
    public class Wines : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Wines(ApplicationContext context) => _context = context;

        // GET: api/Wines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wine>>> GetWines() =>
            await _context.Wines.ToListAsync();

        // GET: api/Wines/5
        [HttpGet("{wineryName}/{label}")]
        public async Task<ActionResult<Wine>> GetWine(string wineryName, string label)
        {
            if (string.IsNullOrWhiteSpace(wineryName) ||
                string.IsNullOrWhiteSpace(label)) return BadRequest();
            if (_context.Wines == null) return NotFound();
            var wine = await _context.Wines
                .FirstOrDefaultAsync(w =>
                    string.Equals(wineryName, w.WineryName, StringComparison.InvariantCultureIgnoreCase) &&
                    string.Equals(label, w.Label, StringComparison.InvariantCultureIgnoreCase));
            if (wine == null) return NotFound();
            return wine;
        }

        // PUT: api/Wines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{wineryName}/{label}")]
        public async Task<IActionResult> PutWine(string wineryName, string label, Wine wine)
        {
            if (string.IsNullOrWhiteSpace(wineryName) ||
                string.IsNullOrWhiteSpace(label) ||
                !string.Equals(wineryName, wine.WineryName, StringComparison.InvariantCultureIgnoreCase) ||
                !string.Equals(label, wine.Label, StringComparison.InvariantCultureIgnoreCase))
                return BadRequest();
            _context.Entry(wine).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineExists(wineryName, label)) return NotFound();
                throw;
            }
            return NoContent();
        }

        // POST: api/Wines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wine>> PostWine(Wine wine)
        {
            if (_context.Wines == null)
                return Problem("Entity set 'ApplicationContext.Wines'  is null.");
            _context.Wines.Add(wine);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWine), new { wineryName = wine.WineryName, label = wine.Label }, wine);
        }

        // DELETE: api/Wines/5
        [HttpDelete("{wineryName}/{label}")]
        public async Task<IActionResult> DeleteWine(string wineryName, string label)
        {
            if (string.IsNullOrWhiteSpace(wineryName) ||
                string.IsNullOrWhiteSpace(label))
                return BadRequest();
            if (_context.Wines == null) return NotFound();
            var wine = await _context.Wines
                .FirstOrDefaultAsync(w =>
                    string.Equals(wineryName, w.WineryName, StringComparison.InvariantCultureIgnoreCase) &&
                    string.Equals(label, w.Label, StringComparison.InvariantCultureIgnoreCase));
            if (wine == null) return NotFound();
            _context.Wines.Remove(wine);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool WineExists(string wineryName, string label)
        {
            return (_context.Wines?.Any(e =>
                string.Equals(wineryName, e.WineryName, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(label, e.Label, StringComparison.InvariantCultureIgnoreCase))).GetValueOrDefault();
        }
    }
}
