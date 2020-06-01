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
    public class TVshowsController : ControllerBase
    {
        private readonly Lab2TVShowsContext _context;

        public TVshowsController(Lab2TVShowsContext context)
        {
            _context = context;
        }

        // GET: api/TVshows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TVshow>>> GetTVshows()
        {
            return await _context.TVshows.ToListAsync();
        }

        // GET: api/TVshows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TVshow>> GetTVshow(int id)
        {
            var tVshow = await _context.TVshows.FindAsync(id);

            if (tVshow == null)
            {
                return NotFound();
            }

            return tVshow;
        }

        // PUT: api/TVshows/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTVshow(int id, TVshow tVshow)
        {
            if (id != tVshow.Id)
            {
                return BadRequest();
            }

            _context.Entry(tVshow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TVshowExists(id))
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

        // POST: api/TVshows
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TVshow>> PostTVshow(TVshow tVshow)
        {
            _context.TVshows.Add(tVshow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTVshow", new { id = tVshow.Id }, tVshow);
        }

        // DELETE: api/TVshows/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TVshow>> DeleteTVshow(int id)
        {
            var tVshow = await _context.TVshows.FindAsync(id);
            if (tVshow == null)
            {
                return NotFound();
            }

            _context.TVshows.Remove(tVshow);
            await _context.SaveChangesAsync();

            return tVshow;
        }

        private bool TVshowExists(int id)
        {
            return _context.TVshows.Any(e => e.Id == id);
        }
    }
}
