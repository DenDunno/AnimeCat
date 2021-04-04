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
    public class AnimeGenresController : ControllerBase
    {
        private readonly AnimeContext _context;

        public AnimeGenresController(AnimeContext context)
        {
            _context = context;
        }

        // GET: api/AnimeGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeGenre>>> GetAnimeGenres()
        {
            return await _context.AnimeGenres.ToListAsync();
        }

        // GET: api/AnimeGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeGenre>> GetAnimeGenre(int id)
        {
            var animeGenre = await _context.AnimeGenres.FindAsync(id);

            if (animeGenre == null)
            {
                return NotFound();
            }

            return animeGenre;
        }

        // PUT: api/AnimeGenres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimeGenre(int id, AnimeGenre animeGenre)
        {
            if (id != animeGenre.Id)
            {
                return BadRequest();
            }

            _context.Entry(animeGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeGenreExists(id))
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

        // POST: api/AnimeGenres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimeGenre>> PostAnimeGenre(AnimeGenre animeGenre)
        {
            _context.AnimeGenres.Add(animeGenre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimeGenre", new { id = animeGenre.Id }, animeGenre);
        }

        // DELETE: api/AnimeGenres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimeGenre(int id)
        {
            var animeGenre = await _context.AnimeGenres.FindAsync(id);
            if (animeGenre == null)
            {
                return NotFound();
            }

            _context.AnimeGenres.Remove(animeGenre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimeGenreExists(int id)
        {
            return _context.AnimeGenres.Any(e => e.Id == id);
        }
    }
}
