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
    public class AnimeInfoesController : ControllerBase
    {
        private readonly AnimeContext _context;

        public AnimeInfoesController(AnimeContext context)
        {
            _context = context;
        }

        // GET: api/AnimeInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeInfo>>> GetAnimeInfoes()
        {
            return await _context.AnimeInfoes.ToListAsync();
        }

        // GET: api/AnimeInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeInfo>> GetAnimeInfo(int id)
        {
            var animeInfo = await _context.AnimeInfoes.FindAsync(id);

            if (animeInfo == null)
            {
                return NotFound();
            }

            return animeInfo;
        }

        // PUT: api/AnimeInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimeInfo(int id, AnimeInfo animeInfo)
        {
            if (id != animeInfo.AnimeInfoId)
            {
                return BadRequest();
            }

            _context.Entry(animeInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeInfoExists(id))
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

        // POST: api/AnimeInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimeInfo>> PostAnimeInfo(AnimeInfo animeInfo)
        {
            _context.AnimeInfoes.Add(animeInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimeInfo", new { id = animeInfo.AnimeInfoId }, animeInfo);
        }

        // DELETE: api/AnimeInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimeInfo(int id)
        {
            var animeInfo = await _context.AnimeInfoes.FindAsync(id);
            if (animeInfo == null)
            {
                return NotFound();
            }

            _context.AnimeInfoes.Remove(animeInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimeInfoExists(int id)
        {
            return _context.AnimeInfoes.Any(e => e.AnimeInfoId == id);
        }
    }
}
