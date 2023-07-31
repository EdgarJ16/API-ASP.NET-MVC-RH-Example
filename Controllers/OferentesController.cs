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
    public class OferentesController : ControllerBase
    {
        private readonly BackEndAPIContext _context;

        public OferentesController(BackEndAPIContext context)
        {
            _context = context;
        }

        // GET: api/Oferentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oferentes>>> GetOferentes()
        {
          if (_context.Oferentes == null)
          {
              return NotFound();
          }
            return await _context.Oferentes.ToListAsync();
        }

        // GET: api/Oferentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oferentes>> GetOferentes(string id)
        {
          if (_context.Oferentes == null)
          {
              return NotFound();
          }
            var oferentes = await _context.Oferentes.FindAsync(id);

            if (oferentes == null)
            {
                return NotFound();
            }

            return oferentes;
        }

        // PUT: api/Oferentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOferentes(string id, Oferentes oferentes)
        {
            if (id != oferentes.ID)
            {
                return BadRequest();
            }

            _context.Entry(oferentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OferentesExists(id))
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

        // POST: api/Oferentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Oferentes>> PostOferentes(Oferentes oferentes)
        {
          if (_context.Oferentes == null)
          {
              return Problem("Entity set 'BackEndAPIContext.Oferentes'  is null.");
          }
            _context.Oferentes.Add(oferentes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OferentesExists(oferentes.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOferentes", new { id = oferentes.ID }, oferentes);
        }

        // DELETE: api/Oferentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOferentes(string id)
        {
            if (_context.Oferentes == null)
            {
                return NotFound();
            }
            var oferentes = await _context.Oferentes.FindAsync(id);
            if (oferentes == null)
            {
                return NotFound();
            }

            _context.Oferentes.Remove(oferentes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OferentesExists(string id)
        {
            return (_context.Oferentes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
