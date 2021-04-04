using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimeCat.Models;

namespace AnimeCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimesController : ControllerBase
    {
        private readonly AnimeContext _context;

        public AnimesController(AnimeContext context)
        {
            _context = context;
        }

        // GET: api/Animes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anime>>> GetAnimes()
        {
            return await _context.Animes.ToListAsync();
        }

        // GET: api/Animes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anime>> GetAnime(int id)
        {
            var anime = await _context.Animes.FindAsync(id);

            if (anime == null)
            {
                return NotFound();
            }

            return anime;
        }

        // PUT: api/Animes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnime(int id, Anime anime)
        {
            if (id != anime.AnimeId)
            {
                return BadRequest();
            }

            _context.Entry(anime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeExists(id))
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

        // POST: api/Animes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Anime>> PostAnime(Anime anime)
        {
            _context.Animes.Add(anime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnime", new { id = anime.AnimeId }, anime);
        }

        // DELETE: api/Animes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnime(int id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime == null)
            {
                return NotFound();
            }

            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimeExists(int id)
        {
            return _context.Animes.Any(e => e.AnimeId == id);
        }
    }
}
