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
    public class EducationsController : ControllerBase
    {
        private readonly EducationContext _context;

        public EducationsController(EducationContext context)
        {
            _context = context;
        }

        // GET: api/Educations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> GetEducation()
        {
            return await _context.Education.ToListAsync();
        }

        // GET: api/Educations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> GetEducation(int id)
        {
            var education = await _context.Education.FindAsync(id);

            if (education == null)
            {
                return NotFound();
            }

            return education;
        }

        // GET: api/Educations/midex/5
        [HttpGet("midex/{id}")]
        public async Task<ActionResult<IEnumerable<Education>>> GetByUserid(int id)
        {
            var education = await _context.Education
                                .Where(b => b.midex == id)
                                .ToListAsync();

            return education;
        }

        // PUT: api/Educations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducation(int id, Education education)
        {
            if (id != education.midex)
            {
                return BadRequest();
            }

            _context.Entry(education).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(id))
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

        // POST: api/Educations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Education>> PostEducation(Education education)
        {
            _context.Education.Add(education);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EducationExists(education.midex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEducation", new { id = education.midex }, education);
        }

        // DELETE: api/Educations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Education>> DeleteEducation(int id)
        {
            var education = await _context.Education.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }

            _context.Education.Remove(education);
            await _context.SaveChangesAsync();

            return education;
        }

        private bool EducationExists(int id)
        {
            return _context.Education.Any(e => e.midex == id);
        }
    }
}
