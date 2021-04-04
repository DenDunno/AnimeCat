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
    public class AnimeTranslationsController : ControllerBase
    {
        private readonly AnimeContext _context;

        public AnimeTranslationsController(AnimeContext context)
        {
            _context = context;
        }

        // GET: api/AnimeTranslations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeTranslation>>> GetAnimeTranslations()
        {
            return await _context.AnimeTranslations.ToListAsync();
        }

        // GET: api/AnimeTranslations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeTranslation>> GetAnimeTranslation(int id)
        {
            var animeTranslation = await _context.AnimeTranslations.FindAsync(id);

            if (animeTranslation == null)
            {
                return NotFound();
            }

            return animeTranslation;
        }

        // PUT: api/AnimeTranslations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimeTranslation(int id, AnimeTranslation animeTranslation)
        {
            if (id != animeTranslation.Id)
            {
                return BadRequest();
            }

            _context.Entry(animeTranslation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeTranslationExists(id))
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

        // POST: api/AnimeTranslations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimeTranslation>> PostAnimeTranslation(AnimeTranslation animeTranslation)
        {
            _context.AnimeTranslations.Add(animeTranslation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimeTranslation", new { id = animeTranslation.Id }, animeTranslation);
        }

        // DELETE: api/AnimeTranslations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimeTranslation(int id)
        {
            var animeTranslation = await _context.AnimeTranslations.FindAsync(id);
            if (animeTranslation == null)
            {
                return NotFound();
            }

            _context.AnimeTranslations.Remove(animeTranslation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimeTranslationExists(int id)
        {
            return _context.AnimeTranslations.Any(e => e.Id == id);
        }
    }
}
