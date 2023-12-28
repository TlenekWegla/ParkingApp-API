using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Kontekst_Danych;
using ParkingApp.Models;

namespace ParkingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezerwacjesController : ControllerBase
    {
        private readonly KontekstDanych _context;

        public RezerwacjesController(KontekstDanych context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Rezerwacja.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacje = await _context.Rezerwacja
                .FirstOrDefaultAsync(m => m.id_rezerwacji == id);
            if (rezerwacje == null)
            {
                return NotFound();
            }

            return Ok(rezerwacje);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Rezerwacje rezerwacje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezerwacje);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Details), new { id = rezerwacje.id_rezerwacji }, rezerwacje);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Rezerwacje rezerwacje)
        {
            if (id != rezerwacje.id_rezerwacji)
            {
                return BadRequest();
            }

            _context.Entry(rezerwacje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezerwacjeExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rezerwacje = await _context.Rezerwacja.FindAsync(id);
            if (rezerwacje == null)
            {
                return NotFound();
            }

            _context.Rezerwacja.Remove(rezerwacje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RezerwacjeExists(int id)
        {
            return _context.Rezerwacja.Any(e => e.id_rezerwacji == id);
        }
    }
}