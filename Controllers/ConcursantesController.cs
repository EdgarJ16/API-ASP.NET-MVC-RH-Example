using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.API.Data;
using BackEnd.API.Models;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcursantesController : ControllerBase
    {
        private readonly BackEndAPIContext _context;

        public ConcursantesController(BackEndAPIContext context)
        {
            _context = context;
        }

        // GET: api/Concursantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concursante>>> GetConcursante()
        {
          if (_context.Concursante == null)
          {
              return NotFound();
          }
            return await _context.Concursante.ToListAsync();
        }

        // GET: api/Concursantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concursante>> GetConcursante(int id)
        {
          if (_context.Concursante == null)
          {
              return NotFound();
          }
            var concursante = await _context.Concursante.FindAsync(id);

            if (concursante == null)
            {
                return NotFound();
            }

            return concursante;
        }

        // PUT: api/Concursantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcursante(int id, Concursante concursante)
        {
            if (id != concursante.ID)
            {
                return BadRequest();
            }

            _context.Entry(concursante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcursanteExists(id))
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

        // POST: api/Concursantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Concursante>> PostConcursante(Concursante concursante)
        {
          if (_context.Concursante == null)
          {
              return Problem("Entity set 'BackEndAPIContext.Concursante'  is null.");
          }
            _context.Concursante.Add(concursante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConcursante", new { id = concursante.ID }, concursante);
        }

        // DELETE: api/Concursantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcursante(int id)
        {
            if (_context.Concursante == null)
            {
                return NotFound();
            }
            var concursante = await _context.Concursante.FindAsync(id);
            if (concursante == null)
            {
                return NotFound();
            }

            _context.Concursante.Remove(concursante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConcursanteExists(int id)
        {
            return (_context.Concursante?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
