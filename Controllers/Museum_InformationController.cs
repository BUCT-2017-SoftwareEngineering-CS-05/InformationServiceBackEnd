using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InformationServiceBackEnd.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;

namespace InformationServiceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Museum_InformationController : ControllerBase
    {
        private readonly Museum_InformationContext _context;
        private readonly CommentContext _contexttt;
        public Museum_InformationController(Museum_InformationContext context, CommentContext commentContext)
        {
            _context = context;
            _contexttt = commentContext;
        }

        //public Museum_InformationController(CommentContext contextt)
        //{
         //   _contexttt = contextt;
        //}
        // GET: api/Museum_Information
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Museum_Information>>> GetMuseum_Information()
        {
            return await _context.Museum_Information.ToListAsync();
        }
       
        [HttpGet("One/{id}",Name= "GetMuseum")]
        public async Task<ActionResult<IEnumerable<Museum_Information>>> GetMuseum(int id)
        {

            switch (id)
            {
                case 1:
                    List<Museum_Information> it1 = (from s1 in _contexttt.Comment
                                                    group s1 by new { key1 = s1.midex }
                                                    into a
                                                    select new
                                                    {
                                                       id = a.Key.key1,
                                                       score = a.Sum(x => x.exhscore)
                                                    }
                                                    into te
                                                    orderby te.score descending                      
                                                    select new Museum_Information
                                                    {
                                                        midex = te.id,
                                                    }).ToList();
                    List<Museum_Information> itt1 = (from s2 in _context.Museum_Information
                                group s2 by new { key1 = s2.mname, key2 = s2.midex }
                                into z
                                select new Museum_Information
                                {
                                    midex = z.Key.key2,
                                    mname = z.Key.key1
                                }
                                ).ToList();
                    foreach(Museum_Information tx in it1)
                    {
                        tx.mname = itt1.Find(delegate (Museum_Information sss) { return sss.midex == tx.midex; }).mname;
                    }
                    return it1;
                    
                case 2:
                    List<Museum_Information> it2 = (from s1 in _contexttt.Comment
                                                    group s1 by new { key1 = s1.midex }
                                                    into a
                                                    select new
                                                    {
                                                        id = a.Key.key1,
                                                        score = a.Sum(x => x.exhscore)
                                                    }
                                                    into te
                                                    orderby te.score descending
                                                    select new Museum_Information
                                                    {
                                                        midex = te.id,
                                                    }).ToList();
                    List<Museum_Information> itt2 = (from s2 in _context.Museum_Information
                                                     group s2 by new { key1 = s2.mname, key2 = s2.midex }
                                into z
                                                     select new Museum_Information
                                                     {
                                                         midex = z.Key.key2,
                                                         mname = z.Key.key1
                                                     }
                                ).ToList();
                    foreach (Museum_Information tx in it2)
                    {
                        tx.mname = itt2.Find(delegate (Museum_Information sss) { return sss.midex == tx.midex; }).mname;
                    }
                    ;
                    return it2;
                case 3:
                    List<Museum_Information> it3 = (from s1 in _contexttt.Comment
                                                    group s1 by new { key1 = s1.midex }
                                                    into a
                                                    select new
                                                    {
                                                        id = a.Key.key1,
                                                        score = a.Sum(x => x.exhscore)
                                                    }
                                                    into te
                                                    orderby te.score descending
                                                    select new Museum_Information
                                                    {
                                                        midex = te.id,
                                                    }).ToList();
                    List<Museum_Information> itt3 = (from s2 in _context.Museum_Information
                                                     group s2 by new { key1 = s2.mname, key2 = s2.midex }
                                into z
                                                     select new Museum_Information
                                                     {
                                                         midex = z.Key.key2,
                                                         mname = z.Key.key1
                                                     }
                                ).ToList();
                    foreach (Museum_Information tx in it3)
                    {
                        tx.mname = itt3.Find(delegate (Museum_Information sss) { return sss.midex == tx.midex; }).mname;
                    }
                    return it3;
                default:
                    List<Museum_Information> it = (from s1 in _contexttt.Comment
                                                    group s1 by new { key1 = s1.midex }
                                                    into a
                                                    select new
                                                    {
                                                        id = a.Key.key1,
                                                        score = a.Sum(x => x.exhscore)
                                                    }
                                                    into te
                                                    orderby te.score descending
                                                    select new Museum_Information
                                                    {
                                                        midex = te.id,
                                                    }).ToList();
                    List<Museum_Information> itt = (from s2 in _context.Museum_Information
                                                     group s2 by new { key1 = s2.mname, key2 = s2.midex }
                                into z
                                                     select new Museum_Information
                                                     {
                                                         midex = z.Key.key2,
                                                         mname = z.Key.key1
                                                     }
                                ).ToList();
                    foreach (Museum_Information tx in it)
                    {
                        tx.mname = itt.Find(delegate (Museum_Information sss) { return sss.midex == tx.midex; }).mname;
                    }
                    return it;
            }

        }
        

        // GET: api/Museum_Information/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Museum_Information>> GetMuseum_Information(int id)
        {
            var museum_Information = await _context.Museum_Information.FindAsync(id);

            if (museum_Information == null)
            {
                return NotFound();
            }

            return museum_Information;
        }

        // PUT: api/Museum_Information/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuseum_Information(int id, Museum_Information museum_Information)
        {
            if (id != museum_Information.midex)
            {
                return BadRequest();
            }

            _context.Entry(museum_Information).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Museum_InformationExists(id))
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

        // POST: api/Museum_Information
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Museum_Information>> PostMuseum_Information(Museum_Information museum_Information)
        {
            _context.Museum_Information.Add(museum_Information);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMuseum_Information", new { id = museum_Information.midex }, museum_Information);
        }

        // DELETE: api/Museum_Information/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Museum_Information>> DeleteMuseum_Information(int id)
        {
            var museum_Information = await _context.Museum_Information.FindAsync(id);
            if (museum_Information == null)
            {
                return NotFound();
            }

            _context.Museum_Information.Remove(museum_Information);
            await _context.SaveChangesAsync();

            return museum_Information;
        }

        private bool Museum_InformationExists(int id)
        {
            return _context.Museum_Information.Any(e => e.midex == id);
        }
    }
}
