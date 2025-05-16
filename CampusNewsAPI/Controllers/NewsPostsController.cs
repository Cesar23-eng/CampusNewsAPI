using CampusNewsAPI.Data;
using CampusNewsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusNewsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsPostsController : ControllerBase
{
    private readonly AppDbContext _context;

    public NewsPostsController(AppDbContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAll()
    {
        return await _context.NewsPosts.Include(p => p.Author).ToListAsync();
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> Get(int id)
    {
        var post = await _context.NewsPosts.Include(p => p.Author).FirstOrDefaultAsync(p => p.Id == id);
        return post == null ? NotFound() : post;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<Post>> Create(Post post)
    {
        post.PublishDate = DateTime.UtcNow;
        _context.NewsPosts.Add(post);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Post updated)
    {
        if (id != updated.Id) return BadRequest();
        _context.Entry(updated).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _context.NewsPosts.FindAsync(id);
        if (post == null) return NotFound();
        _context.NewsPosts.Remove(post);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}