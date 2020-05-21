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

        // GET: api/Comments/analysis1/{id}
        [HttpGet("analysis1/{id}")]
        public async Task<ActionResult<IEnumerable<analysis>>> Getanalysisone(int id)
        {
            List<Comment> itt1 = (from s2 in _context.Comment
                                  where s2.midex == id
                                  select s2).ToList();
            int y1=0, y2=0, y3=0, y4=0, y5=0;
            foreach(Comment t in itt1)
            {
                if (t.serscore == 1)
                    y1++;
                if (t.serscore == 2)
                    y2++;
                if (t.serscore == 3)
                    y3++;
                if (t.serscore == 4)
                    y4++;
                if (t.serscore == 5)
                    y5++;
            }
            List<analysis> resu = new List<analysis>
            {
                new analysis(){X=1,Y=y1},
                new analysis(){X=2,Y=y2},
                new analysis(){X=3,Y=y3},
                new analysis(){X=4,Y=y4},
                new analysis(){X=5,Y=y5},
            };
            return resu;
        }
        // GET: api/Comments/analysis1/{id}
        [HttpGet("analysis2/{id}")]
        public async Task<ActionResult<IEnumerable<analysis>>> Getanalysistwo(int id)
        {
            List<Comment> itt1 = (from s2 in _context.Comment
                                  where s2.midex == id
                                  select s2).ToList();
            int y1 = 0, y2 = 0, y3 = 0, y4 = 0, y5 = 0;
            foreach (Comment t in itt1)
            {
                if (t.envscore == 1)
                    y1++;
                if (t.envscore == 2)
                    y2++;
                if (t.envscore == 3)
                    y3++;
                if (t.envscore == 4)
                    y4++;
                if (t.envscore == 5)
                    y5++;
            }
            List<analysis> resu = new List<analysis>
            {
                new analysis(){X=1,Y=y1},
                new analysis(){X=2,Y=y2},
                new analysis(){X=3,Y=y3},
                new analysis(){X=4,Y=y4},
                new analysis(){X=5,Y=y5},
            };
            return resu;
        }
        // GET: api/Comments/analysis1/{id}
        [HttpGet("analysis3/{id}")]
        public async Task<ActionResult<IEnumerable<analysis>>> Getanalysisthree(int id)
        {
            List<Comment> itt1 = (from s2 in _context.Comment
                                  where s2.midex == id
                                  select s2).ToList();
            int y1 = 0, y2 = 0, y3 = 0, y4 = 0, y5 = 0;
            foreach (Comment t in itt1)
            {
                if (t.exhscore == 1)
                    y1++;
                if (t.exhscore == 2)
                    y2++;
                if (t.exhscore == 3)
                    y3++;
                if (t.exhscore == 4)
                    y4++;
                if (t.exhscore == 5)
                    y5++;
            }
            List<analysis> resu = new List<analysis>
            {
                new analysis(){X=1,Y=y1},
                new analysis(){X=2,Y=y2},
                new analysis(){X=3,Y=y3},
                new analysis(){X=4,Y=y4},
                new analysis(){X=5,Y=y5},
            };
            return resu;
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
        [HttpPut("{midex}/{userid}")]
        public async Task<IActionResult> PutComment(int midex,string userid, Comment comment)
        {
            if (midex != comment.midex)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            await _context.SaveChangesAsync();

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
