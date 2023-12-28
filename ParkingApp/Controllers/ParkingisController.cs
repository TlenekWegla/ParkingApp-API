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
    public class ParkingisController : ControllerBase
    {
        private readonly KontekstDanych _context;

        public ParkingisController(KontekstDanych context)
        {
            _context = context;
        }

        // GET: api/Parkingis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parkingi>>> GetParking()
        {
            return await _context.Parking.ToListAsync();
        }

        // GET: api/Parkingis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parkingi>> GetParkingi(int id)
        {
            var parkingi = await _context.Parking.FindAsync(id);

            if (parkingi == null)
            {
                return NotFound();
            }

            return parkingi;
        }

        // PUT: api/Parkingis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkingi(int id, Parkingi parkingi)
        {
            if (id != parkingi.id_parkingu)
            {
                return BadRequest();
            }

            _context.Entry(parkingi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingiExists(id))
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

        // POST: api/Parkingis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parkingi>> PostParkingi(Parkingi parkingi)
        {
            _context.Parking.Add(parkingi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParkingi", new { id = parkingi.id_parkingu }, parkingi);
        }

        // DELETE: api/Parkingis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParkingi(int id)
        {
            var parkingi = await _context.Parking.FindAsync(id);
            if (parkingi == null)
            {
                return NotFound();
            }

            _context.Parking.Remove(parkingi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParkingiExists(int id)
        {
            return _context.Parking.Any(e => e.id_parkingu == id);
        }
    }
}
