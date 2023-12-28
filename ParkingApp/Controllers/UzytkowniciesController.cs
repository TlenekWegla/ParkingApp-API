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
        public class UzytkowniciesController : ControllerBase
        {
            private readonly KontekstDanych _context;

            public UzytkowniciesController(KontekstDanych context)
            {
                _context = context;
            }

            // GET: api/Uzytkownicies
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Uzytkownicy>>> GetUzytkownicy()
            {
                return await _context.Uzytkownicy.ToListAsync();
            }

            // GET: api/Uzytkownicies/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Uzytkownicy>> GetUzytkownicy(int id)
            {
                var uzytkownicy = await _context.Uzytkownicy.FindAsync(id);

                if (uzytkownicy == null)
                {
                    return NotFound();
                }

                return uzytkownicy;
            }

            // PUT: api/Uzytkownicies/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutUzytkownicy(int id, Uzytkownicy uzytkownicy)
            {
                if (id != uzytkownicy.id_uzytkownika)
                {
                    return BadRequest();
                }

                _context.Entry(uzytkownicy).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzytkownicyExists(id))
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

            // POST: api/Uzytkownicies
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<Uzytkownicy>> PostUzytkownicy(Uzytkownicy uzytkownicy)
            {
                _context.Uzytkownicy.Add(uzytkownicy);
                await _context.SaveChangesAsync();

              //  return CreatedAtAction("GetUzytkownicy", new { id = uzytkownicy.id_uzytkownika }, uzytkownicy);
                return CreatedAtAction(nameof(Uzytkownicy), new { id = uzytkownicy.id_uzytkownika }, uzytkownicy);   
            }

            // DELETE: api/Uzytkownicies/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUzytkownicy(int id)
            {
                var uzytkownicy = await _context.Uzytkownicy.FindAsync(id);
                if (uzytkownicy == null)
                {
                    return NotFound();
                }

                _context.Uzytkownicy.Remove(uzytkownicy);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool UzytkownicyExists(int id)
            {
                return _context.Uzytkownicy.Any(e => e.id_uzytkownika == id);
            }
        }
    }
