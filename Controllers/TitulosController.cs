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
    public class TitulosController : ControllerBase
    {
        private readonly BackEndAPIContext _context;

        public TitulosController(BackEndAPIContext context)
        {
            _context = context;
        }

        // GET: api/Titulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Titulos>>> GetTitulos()
        {
          if (_context.Titulos == null)
          {
              return NotFound();
          }
            return await _context.Titulos.ToListAsync();
        }

        // GET: api/Titulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Titulos>> GetTitulos(string id)
        {
          if (_context.Titulos == null)
          {
              return NotFound();
          }
            var titulos = await _context.Titulos.FindAsync(id);

            if (titulos == null)
            {
                return NotFound();
            }

            return titulos;
        }

        // PUT: api/Titulos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitulos(string id, Titulos titulos)
        {
            if (id != titulos.ID)
            {
                return BadRequest();
            }

            _context.Entry(titulos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitulosExists(id))
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

        // POST: api/Titulos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Titulos>> PostTitulos(Titulos titulos)
        {
          if (_context.Titulos == null)
          {
              return Problem("Entity set 'BackEndAPIContext.Titulos'  is null.");
          }
            _context.Titulos.Add(titulos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TitulosExists(titulos.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTitulos", new { id = titulos.ID }, titulos);
        }

        // DELETE: api/Titulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitulos(string id)
        {
            if (_context.Titulos == null)
            {
                return NotFound();
            }
            var titulos = await _context.Titulos.FindAsync(id);
            if (titulos == null)
            {
                return NotFound();
            }

            _context.Titulos.Remove(titulos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TitulosExists(string id)
        {
            return (_context.Titulos?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
