using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InformationServiceBackEnd.Models;

namespace InformationServiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExhibitionsController : ControllerBase
    {
        private readonly ExhibitionContext _context;

        public ExhibitionsController(ExhibitionContext context)
        {
            _context = context;
        }

        // GET: api/Exhibitions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exhibition>>> GetExhibition()
        {
            return await _context.Exhibition.ToListAsync();
        }

        // GET: api/Exhibitions/midex/5
        [HttpGet("midex/{id}")]
        public async Task<ActionResult<IEnumerable<Exhibition>>> GetByUserid(int id)
        {
            var exhibition = await _context.Exhibition
                                .Where(b => b.midex == id)
                                .ToListAsync();

            return exhibition;
        }

        // GET: api/Exhibitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exhibition>> GetExhibition(int id)
        {
            var exhibition = await _context.Exhibition.FindAsync(id);

            if (exhibition == null)
            {
                return NotFound();
            }

            return exhibition;
        }

        // PUT: api/Exhibitions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExhibition(int id, Exhibition exhibition)
        {
            if (id != exhibition.midex)
            {
                return BadRequest();
            }

            _context.Entry(exhibition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExhibitionExists(id))
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

        // POST: api/Exhibitions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Exhibition>> PostExhibition(Exhibition exhibition)
        {
            _context.Exhibition.Add(exhibition);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExhibitionExists(exhibition.midex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExhibition", new { id = exhibition.midex }, exhibition);
        }

        // DELETE: api/Exhibitions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Exhibition>> DeleteExhibition(int id)
        {
            var exhibition = await _context.Exhibition.FindAsync(id);
            if (exhibition == null)
            {
                return NotFound();
            }

            _context.Exhibition.Remove(exhibition);
            await _context.SaveChangesAsync();

            return exhibition;
        }

        private bool ExhibitionExists(int id)
        {
            return _context.Exhibition.Any(e => e.midex == id);
        }
    }
}
