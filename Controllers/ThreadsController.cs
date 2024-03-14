using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleRedditApi.Models;
using Thread = SimpleRedditApi.Models.Thread;

[Route("api/[controller]")]
[ApiController]
public class ThreadsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ThreadsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Threads/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Thread>> GetThread(int id)
    {
        var thread = await _context.Threads
            .Include(t => t.Comments) // Inkluder kommentarer sammen med tråden
            .FirstOrDefaultAsync(t => t.Id == id);

        if (thread == null)
        {
            return NotFound();
        }

        return thread;
    }

    // POST: api/Threads
    [HttpPost]
    public async Task<ActionResult<Thread>> PostThread(Thread thread)
    {
        _context.Threads.Add(thread);
        await _context.SaveChangesAsync();

        // Returner den oprettede tråd og dens lokation i headeren (best practice)
        return CreatedAtAction(nameof(GetThread), new { id = thread.Id }, thread);
    }

    // PUT: api/Threads/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutThread(int id, Thread thread)
    {
        if (id != thread.Id)
        {
            return BadRequest();
        }

        _context.Entry(thread).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Threads.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent(); // 204 No Content som svar når en opdatering lykkes
    }

    // DELETE: api/Threads/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteThread(int id)
    {
        var thread = await _context.Threads.FindAsync(id);
        if (thread == null)
        {
            return NotFound();
        }

        _context.Threads.Remove(thread);
        await _context.SaveChangesAsync();

        return NoContent(); // 204 No Content som svar ved succesfuld sletning
    }
}