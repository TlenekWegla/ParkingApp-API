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
    public class PostojesController : ControllerBase
    {
        private readonly KontekstDanych _context;

        public PostojesController(KontekstDanych context)
        {
            _context = context;
        }

        // GET: api/Postojes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Postoje>>> GetPostoj()
        {
            return await _context.Postoj.ToListAsync();
        }

        // GET: api/Postojes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Postoje>> GetPostoje(int id)
        {
            var postoje = await _context.Postoj.FindAsync(id);

            if (postoje == null)
            {
                return NotFound();
            }

            return postoje;
        }

        // PUT: api/Postojes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostoje(int id, Postoje postoje)
        {
            if (id != postoje.id_postoju)
            {
                return BadRequest();
            }

            _context.Entry(postoje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostojeExists(id))
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

        // POST: api/Postojes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Postoje>> PostPostoje(Postoje postoje)
        {
            _context.Postoj.Add(postoje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostoje", new { id = postoje.id_postoju }, postoje);
        }

        // DELETE: api/Postojes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostoje(int id)
        {
            var postoje = await _context.Postoj.FindAsync(id);
            if (postoje == null)
            {
                return NotFound();
            }

            _context.Postoj.Remove(postoje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostojeExists(int id)
        {
            return _context.Postoj.Any(e => e.id_postoju == id);
        }
    }
}
