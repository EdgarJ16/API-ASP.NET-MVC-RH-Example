using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.API.Data;
using FrontEnd.Webclient.Models;

namespace BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciasController : ControllerBase
    {
        private readonly BackEndAPIContext _context;

        public ExperienciasController(BackEndAPIContext context)
        {
            _context = context;
        }

        // GET: api/Experiencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experiencia>>> GetExperiencia()
        {
          if (_context.Experiencia == null)
          {
              return NotFound();
          }
            return await _context.Experiencia.ToListAsync();
        }

        // GET: api/Experiencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Experiencia>> GetExperiencia(string id)
        {
          if (_context.Experiencia == null)
          {
              return NotFound();
          }
            var experiencia = await _context.Experiencia.FindAsync(id);

            if (experiencia == null)
            {
                return NotFound();
            }

            return experiencia;
        }

        // PUT: api/Experiencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperiencia(string id, Experiencia experiencia)
        {
            if (id != experiencia.ID)
            {
                return BadRequest();
            }

            _context.Entry(experiencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienciaExists(id))
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

        // POST: api/Experiencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Experiencia>> PostExperiencia(Experiencia experiencia)
        {
          if (_context.Experiencia == null)
          {
              return Problem("Entity set 'BackEndAPIContext.Experiencia'  is null.");
          }
            _context.Experiencia.Add(experiencia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExperienciaExists(experiencia.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExperiencia", new { id = experiencia.ID }, experiencia);
        }

        // DELETE: api/Experiencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperiencia(string id)
        {
            if (_context.Experiencia == null)
            {
                return NotFound();
            }
            var experiencia = await _context.Experiencia.FindAsync(id);
            if (experiencia == null)
            {
                return NotFound();
            }

            _context.Experiencia.Remove(experiencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExperienciaExists(string id)
        {
            return (_context.Experiencia?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
