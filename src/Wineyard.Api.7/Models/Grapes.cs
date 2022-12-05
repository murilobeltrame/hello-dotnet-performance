using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wineyard.Models;

namespace Wineyard.Api._6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Grapes : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Grapes(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Grapes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grape>>> GetGrapes()
        {
          if (_context.Grapes == null)
          {
              return NotFound();
          }
            return await _context.Grapes.ToListAsync();
        }

        // GET: api/Grapes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grape>> GetGrape(Guid id)
        {
          if (_context.Grapes == null)
          {
              return NotFound();
          }
            var grape = await _context.Grapes.FindAsync(id);

            if (grape == null)
            {
                return NotFound();
            }

            return grape;
        }

        // PUT: api/Grapes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrape(Guid id, Grape grape)
        {
            if (id != grape.Id)
            {
                return BadRequest();
            }

            _context.Entry(grape).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrapeExists(id))
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

        // POST: api/Grapes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grape>> PostGrape(Grape grape)
        {
          if (_context.Grapes == null)
          {
              return Problem("Entity set 'ApplicationContext.Grapes'  is null.");
          }
            _context.Grapes.Add(grape);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrape", new { id = grape.Id }, grape);
        }

        // DELETE: api/Grapes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrape(Guid id)
        {
            if (_context.Grapes == null)
            {
                return NotFound();
            }
            var grape = await _context.Grapes.FindAsync(id);
            if (grape == null)
            {
                return NotFound();
            }

            _context.Grapes.Remove(grape);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrapeExists(Guid id)
        {
            return (_context.Grapes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
