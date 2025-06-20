using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Museum_Locator.Data;
using Museum_Locator.Models;

namespace Museum_Locator.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuseumApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MuseumApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Museum>>> GetMuseums()
        {
            var museums = await _context.Museums
                .Include(m => m.MuseumFacilities)
                .ThenInclude(mf => mf.Facility)
                .ToListAsync();

            return Ok(museums);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Museum>> GetMuseum(int id)
        {
            var museum = await _context.Museums
                .Include(m => m.MuseumFacilities)
                .ThenInclude(mf => mf.Facility)
                .FirstOrDefaultAsync(m => m.MuseumId == id);

            if (museum == null) return NotFound();
            return Ok(museum);
        }

        [HttpPost]
        public async Task<ActionResult<Museum>> PostMuseum(Museum museum)
        {
            _context.Museums.Add(museum);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMuseum), new { id = museum.MuseumId }, museum);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuseum(int id, Museum museum)
        {
            if (id != museum.MuseumId) return BadRequest();

            _context.Entry(museum).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuseum(int id)
        {
            var museum = await _context.Museums.FindAsync(id);
            if (museum == null) return NotFound();

            _context.Museums.Remove(museum);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
