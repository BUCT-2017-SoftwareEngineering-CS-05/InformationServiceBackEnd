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
    public class NewsController : ControllerBase
    {
        private readonly NewsContext _context;
        private readonly maintableContext _maintableContext;
        public NewsController(NewsContext context,maintableContext maintableContext)
        {
            _context = context;
            _maintableContext = maintableContext;
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            return await _context.News.ToListAsync();
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
            var news = await _context.News.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        // GET: api/News/Museum/
  /*      [HttpGet("Museum/{mname}")]
        public async Task<ActionResult<IEnumerable<News>>> GetByUserid(string mname)
        {
            var news = await _context.News
                                .Where(b => b.Museum == mname)
                                .ToListAsync();
        
            return news;
        }*/

        [HttpGet("One/{name}", Name = "GetByUseridInfor")]
        public async Task<ActionResult<IEnumerable<News>>> GetByUseridInfor(string name)
        {
            
            List<News> it2 = (from s1 in _context.News
                             select s1).ToList();
            List<News> it3 = (from s1 in _context.News
                              where s1.Id == -1
                              select s1).ToList();
            foreach (News tx in it2)
            {
                if (tx.Museum == name)
                    it3.Add(tx);
            }
            return it3;

        }

        // PUT: api/News/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews(int id, News news)
        {
            if (id != news.Id)
            {
                return BadRequest();
            }

            _context.Entry(news).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
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

        // POST: api/News
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<News>> PostNews(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNews", new { id = news.Id }, news);
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> DeleteNews(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return news;
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
