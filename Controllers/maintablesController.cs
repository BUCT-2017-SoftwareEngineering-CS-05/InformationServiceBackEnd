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
    public class maintablesController : ControllerBase
    {
        private readonly maintableContext _context;
        private readonly CommentContext _contexttt;
        private readonly CollectionContext _collectioncon;
        private readonly ExhibitionContext _exhibitioncon;
        public maintablesController(maintableContext context, CommentContext commentContext,CollectionContext collectionContext,ExhibitionContext exhibitionContext)
        {
            _context = context;
            _contexttt = commentContext;
            _collectioncon = collectionContext;
            _exhibitioncon = exhibitionContext;
        }

        // GET: api/maintables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<maintable>>> Getmaintables()
        {
            return await _context.maintable.ToListAsync();
        }

        [HttpGet("One/{id}", Name = "Getmain")]
        public async Task<ActionResult<IEnumerable<maintable>>> Getmain(int id)
        {

            switch (id)
            {
                case 1:
                    List<maintable> it1 = (from s1 in _contexttt.Comment
                                                    group s1 by new { key1 = s1.midex }
                                                    into a
                                                    select new
                                                    {
                                                        id = a.Key.key1,
                                                        score = a.Sum(x => x.exhscore)
                                                    }
                                                    into te
                                                    orderby te.score descending
                                                    select new maintable
                                                    {
                                                        midex = te.id,
                                                    }).ToList();
                    List<maintable> itt1 = (from s2 in _context.maintable
                                            group s2 by new { key1 = s2.mname, key2 = s2.midex }
                                into z
                                                     select new maintable
                                                     {
                                                         midex = z.Key.key2,
                                                         mname = z.Key.key1
                                                     }
                                ).ToList();
                    foreach (maintable tx in it1)
                    {
                        tx.mname = itt1.Find(delegate (maintable sss) { return sss.midex == tx.midex; }).mname;
                    }
                    return it1;

                case 2:
                    List<maintable> it2 = (from s1 in _contexttt.Comment
                                                    group s1 by new { key1 = s1.midex }
                                                    into a
                                                    select new
                                                    {
                                                        id = a.Key.key1,
                                                        score = a.Sum(x => x.serscore)
                                                    }
                                                    into te
                                                    orderby te.score descending
                                                    select new maintable
                                                    {
                                                        midex = te.id,
                                                    }).ToList();
                    List<maintable> itt2 = (from s2 in _context.maintable
                                            group s2 by new { key1 = s2.mname, key2 = s2.midex }
                                into z
                                                     select new maintable
                                                     {
                                                         midex = z.Key.key2,
                                                         mname = z.Key.key1
                                                     }
                                ).ToList();
                    foreach (maintable tx in it2)
                    {
                        tx.mname = itt2.Find(delegate (maintable sss) { return sss.midex == tx.midex; }).mname;
                    }
                    ;
                    return it2;
                case 3:
                    List<maintable> it3 = (from s1 in _contexttt.Comment
                                                    group s1 by new { key1 = s1.midex }
                                                    into a
                                                    select new
                                                    {
                                                        id = a.Key.key1,
                                                        score = a.Sum(x => x.envscore)
                                                    }
                                                    into te
                                                    orderby te.score descending
                                                    select new maintable
                                                    {
                                                        midex = te.id,
                                                    }).ToList();
                    List<maintable> itt3 = (from s2 in _context.maintable
                                                     group s2 by new { key1 = s2.mname, key2 = s2.midex }
                                into z
                                                     select new maintable
                                                     {
                                                         midex = z.Key.key2,
                                                         mname = z.Key.key1
                                                     }
                                ).ToList();
                    foreach (maintable tx in it3)
                    {
                        tx.mname = itt3.Find(delegate (maintable sss) { return sss.midex == tx.midex; }).mname;
                    }
                    return it3;
                case 4:
                    List<maintable> it4 = (from s1 in _collectioncon.Collection
                                           group s1 by new { key1 = s1.midex }
                                                    into a
                                           select new
                                           {
                                               id = a.Key.key1,
                                               score = a.Count()
                                           }
                                                    into te
                                           orderby te.score descending
                                           select new maintable
                                           {
                                               midex = te.id,
                                           }).ToList();
                    List<maintable> itt4 = (from s2 in _context.maintable
                                            group s2 by new { key1 = s2.mname, key2 = s2.midex }
                                into z
                                            select new maintable
                                            {
                                                midex = z.Key.key2,
                                                mname = z.Key.key1
                                            }
                                ).ToList();
                    foreach (maintable tx in it4)
                    {
                        tx.mname = itt4.Find(delegate (maintable sss) { return sss.midex == tx.midex; }).mname;
                    }
                    return it4;
                case 5:
                    List<maintable> it5 = (from s1 in _exhibitioncon.Exhibition
                                           group s1 by new { key1 = s1.midex }
                                                    into a
                                           select new
                                           {
                                               id = a.Key.key1,
                                               score = a.Count()
                                           }
                                                    into te
                                           orderby te.score descending
                                           select new maintable
                                           {
                                               midex = te.id,
                                           }).ToList();
                    List<maintable> itt5 = (from s2 in _context.maintable
                                            group s2 by new { key1 = s2.mname, key2 = s2.midex }
                                into z
                                            select new maintable
                                            {
                                                midex = z.Key.key2,
                                                mname = z.Key.key1
                                            }
                                ).ToList();
                    foreach (maintable tx in it5)
                    {
                        tx.mname = itt5.Find(delegate (maintable sss) { return sss.midex == tx.midex; }).mname;
                    }
                    return it5;
                default:
                    List<maintable> it = (from s1 in _contexttt.Comment
                                                   group s1 by new { key1 = s1.midex }
                                                    into a
                                                   select new
                                                   {
                                                       id = a.Key.key1,
                                                       score = a.Sum(x => x.exhscore)
                                                   }
                                                    into te
                                                   orderby te.score descending
                                                   select new maintable
                                                   {
                                                       midex = te.id,
                                                   }).ToList();
                    List<maintable> itt = (from s2 in _context.maintable
                                                    group s2 by new { key1 = s2.mname, key2 = s2.midex }
                                into z
                                                    select new maintable
                                                    {
                                                        midex = z.Key.key2,
                                                        mname = z.Key.key1
                                                    }
                                ).ToList();
                    foreach (maintable tx in it)
                    {
                        tx.mname = itt.Find(delegate (maintable sss) { return sss.midex == tx.midex; }).mname;
                    }
                    return it;
            }

        }

        // GET: api/maintables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<maintable>> Getmaintable(int id)
        {
            var maintable = await _context.maintable.FindAsync(id);

            if (maintable == null)
            {
                return NotFound();
            }

            return maintable;
        }

        // PUT: api/maintables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmaintable(int id, maintable maintable)
        {
            if (id != maintable.midex)
            {
                return BadRequest();
            }

            _context.Entry(maintable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!maintableExists(id))
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

        // POST: api/maintables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<maintable>> Postmaintable(maintable maintable)
        {
            _context.maintable.Add(maintable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmaintable", new { id = maintable.midex }, maintable);
        }

        // DELETE: api/maintables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<maintable>> Deletemaintable(int id)
        {
            var maintable = await _context.maintable.FindAsync(id);
            if (maintable == null)
            {
                return NotFound();
            }

            _context.maintable.Remove(maintable);
            await _context.SaveChangesAsync();

            return maintable;
        }

        private bool maintableExists(int id)
        {
            return _context.maintable.Any(e => e.midex == id);
        }
    }
}
