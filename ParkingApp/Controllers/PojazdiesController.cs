using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Kontekst_Danych;
using ParkingApp.Models;

namespace ParkingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PojazdiesController : ControllerBase
    {
        private readonly KontekstDanych _context;

        public PojazdiesController(KontekstDanych context)
        {
            _context = context;
        }

        // GET: api/Pojazdies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pojazdy>>> GetPojazd()
        {
            return await _context.Pojazd.ToListAsync();
        }

        // GET: api/Pojazdies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pojazdy>> GetPojazdy(int id)
        {
            var pojazdy = await _context.Pojazd.FindAsync(id);

            if (pojazdy == null)
            {
                return NotFound();
            }

            return pojazdy;
        }

        // PUT: api/Pojazdies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPojazdy(int id, Pojazdy pojazdy)
        {
            if (id != pojazdy.id_pojazdu)
            {
                return BadRequest();
            }

            _context.Entry(pojazdy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PojazdyExists(id))
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

        // POST: api/Pojazdies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pojazdy>> PostPojazdy(Pojazdy pojazdy)
        {
            _context.Pojazd.Add(pojazdy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPojazdy", new { id = pojazdy.id_pojazdu }, pojazdy);
        }

        // DELETE: api/Pojazdies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePojazdy(int id)
        {
            var pojazdy = await _context.Pojazd.FindAsync(id);
            if (pojazdy == null)
            {
                return NotFound();
            }

            _context.Pojazd.Remove(pojazdy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PojazdyExists(int id)
        {
            return _context.Pojazd.Any(e => e.id_pojazdu == id);
        }
    }
}
