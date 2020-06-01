using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TVShows.Models;

namespace TVShows.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioShowsController : ControllerBase
    {
        private readonly Lab2TVShowsContext _context;

        public StudioShowsController(Lab2TVShowsContext context)
        {
            _context = context;
        }

        // GET: api/StudioShows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudioShow>>> GetStudioShows()
        {
            return await _context.StudioShows.ToListAsync();
        }

        // GET: api/StudioShows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudioShow>> GetStudioShow(int id)
        {
            var studioShow = await _context.StudioShows.FindAsync(id);

            if (studioShow == null)
            {
                return NotFound();
            }

            return studioShow;
        }

        // PUT: api/StudioShows/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudioShow(int id, StudioShow studioShow)
        {
            if (id != studioShow.Id)
            {
                return BadRequest();
            }

            _context.Entry(studioShow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudioShowExists(id))
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

        // POST: api/StudioShows
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudioShow>> PostStudioShow(StudioShow studioShow)
        {
            _context.StudioShows.Add(studioShow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudioShow", new { id = studioShow.Id }, studioShow);
        }

        // DELETE: api/StudioShows/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudioShow>> DeleteStudioShow(int id)
        {
            var studioShow = await _context.StudioShows.FindAsync(id);
            if (studioShow == null)
            {
                return NotFound();
            }

            _context.StudioShows.Remove(studioShow);
            await _context.SaveChangesAsync();

            return studioShow;
        }

        private bool StudioShowExists(int id)
        {
            return _context.StudioShows.Any(e => e.Id == id);
        }
    }
}
