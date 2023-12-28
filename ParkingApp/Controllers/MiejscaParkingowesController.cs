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
    public class MiejscaParkingowesController : ControllerBase
    {
        private readonly KontekstDanych _context;

        public MiejscaParkingowesController(KontekstDanych context)
        {
            _context = context;
        }

        // GET: api/MiejscaParkingowes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiejscaParkingowe>>> GetMiejsceParkingowe()
        {
            return await _context.MiejsceParkingowe.ToListAsync();
        }

        // GET: api/MiejscaParkingowes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiejscaParkingowe>> GetMiejscaParkingowe(int id)
        {
            var miejscaParkingowe = await _context.MiejsceParkingowe.FindAsync(id);

            if (miejscaParkingowe == null)
            {
                return NotFound();
            }

            return miejscaParkingowe;
        }

        // PUT: api/MiejscaParkingowes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiejscaParkingowe(int id, MiejscaParkingowe miejscaParkingowe)
        {
            if (id != miejscaParkingowe.id_miejsca)
            {
                return BadRequest();
            }

            _context.Entry(miejscaParkingowe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiejscaParkingoweExists(id))
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

        // POST: api/MiejscaParkingowes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MiejscaParkingowe>> PostMiejscaParkingowe(MiejscaParkingowe miejscaParkingowe)
        {
            _context.MiejsceParkingowe.Add(miejscaParkingowe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiejscaParkingowe", new { id = miejscaParkingowe.id_miejsca }, miejscaParkingowe);
        }

        // DELETE: api/MiejscaParkingowes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiejscaParkingowe(int id)
        {
            var miejscaParkingowe = await _context.MiejsceParkingowe.FindAsync(id);
            if (miejscaParkingowe == null)
            {
                return NotFound();
            }

            _context.MiejsceParkingowe.Remove(miejscaParkingowe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiejscaParkingoweExists(int id)
        {
            return _context.MiejsceParkingowe.Any(e => e.id_miejsca == id);
        }
    }
}
