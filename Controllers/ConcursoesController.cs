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
    public class ConcursoesController : ControllerBase
    {
        private readonly BackEndAPIContext _context;

        public ConcursoesController(BackEndAPIContext context)
        {
            _context = context;
        }

        // GET: api/Concursoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concurso>>> GetConcurso()
        {
          if (_context.Concurso == null)
          {
              return NotFound();
          }
            return await _context.Concurso.ToListAsync();
        }

        // GET: api/Concursoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concurso>> GetConcurso(int id)
        {
          if (_context.Concurso == null)
          {
              return NotFound();
          }
            var concurso = await _context.Concurso.FindAsync(id);

            if (concurso == null)
            {
                return NotFound();
            }

            return concurso;
        }

        // PUT: api/Concursoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcurso(int id, Concurso concurso)
        {
            if (id != concurso.ID)
            {
                return BadRequest();
            }

            _context.Entry(concurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcursoExists(id))
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

        // POST: api/Concursoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Concurso>> PostConcurso(Concurso concurso)
        {
          if (_context.Concurso == null)
          {
              return Problem("Entity set 'BackEndAPIContext.Concurso'  is null.");
          }
            _context.Concurso.Add(concurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConcurso", new { id = concurso.ID }, concurso);
        }

        // DELETE: api/Concursoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcurso(int id)
        {
            if (_context.Concurso == null)
            {
                return NotFound();
            }
            var concurso = await _context.Concurso.FindAsync(id);
            if (concurso == null)
            {
                return NotFound();
            }

            _context.Concurso.Remove(concurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConcursoExists(int id)
        {
            return (_context.Concurso?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
