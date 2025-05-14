using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CampusNewsAPI.Data;
using CampusNewsAPI.Models;

namespace CampuesNewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsPostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NewsPostsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/NewsPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsPost>>> GetNewsPosts()
        {
            return await _context.NewsPosts.ToListAsync();
        }

        // GET: api/NewsPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsPost>> GetNewsPost(int id)
        {
            var newsPost = await _context.NewsPosts.FindAsync(id);

            if (newsPost == null)
            {
                return NotFound();
            }

            return newsPost;
        }

        // PUT: api/NewsPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsPost(int id, NewsPost newsPost)
        {
            if (id != newsPost.Id)
            {
                return BadRequest();
            }

            _context.Entry(newsPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsPostExists(id))
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

        // POST: api/NewsPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NewsPost>> PostNewsPost(NewsPost newsPost)
        {
            _context.NewsPosts.Add(newsPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsPost", new { id = newsPost.Id }, newsPost);
        }

        // DELETE: api/NewsPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsPost(int id)
        {
            var newsPost = await _context.NewsPosts.FindAsync(id);
            if (newsPost == null)
            {
                return NotFound();
            }

            _context.NewsPosts.Remove(newsPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewsPostExists(int id)
        {
            return _context.NewsPosts.Any(e => e.Id == id);
        }
    }
}
