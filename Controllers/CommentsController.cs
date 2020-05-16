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
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComment()
        {
            return await _context.Comment.ToListAsync();
        }

        // GET: api/Comments/userid/{userid}
        [HttpGet("userid/{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetByUserid(string id)
        {
            var comment = await _context.Comment
                                .Where(b => b.userid == id)
                                .ToListAsync();

            return comment;
        }
        // GET: api/Comments/midex/{midex}
        [HttpGet("midex/{id:int}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetByMidex(int id)
        {
            var comment = await _context.Comment
                                .Where(b => b.midex == id)
                                .ToListAsync();

            return comment;
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.midex)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            _context.Comment.Add(comment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommentExists(comment.midex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComment", new { id = comment.midex }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.midex == id);
        }
    }
}
