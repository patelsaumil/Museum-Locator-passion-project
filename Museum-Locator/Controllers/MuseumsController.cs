using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Museum_Locator.Models;
using Museum_Locator.Data;


namespace Museum_Locator.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuseumsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MuseumsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MuseumsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Museum>>> GetMuseums()
        {
            try
            {
                var museums = await _context.Museums.ToListAsync();
                return Ok(museums);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/MuseumsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Museum>> GetMuseum(int id)
        {
            var museum = await _context.Museums.FindAsync(id);

            if (museum == null)
                return NotFound();

            return Ok(museum);
        }

        // POST: api/MuseumsApi
        [HttpPost]
        public async Task<ActionResult<Museum>> PostMuseum(Museum museum)
        {
            try
            {
                _context.Museums.Add(museum);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMuseum), new { id = museum.Museum_Id }, museum);
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not create museum. Error: {ex.Message}");
            }
        }

        // PUT: api/MuseumsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuseum(int id, Museum museum)
        {
            if (id != museum.Museum_Id)
                return BadRequest("ID mismatch");

            _context.Entry(museum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Museums.Any(m => m.Museum_Id == id))
                    return NotFound();

                throw;
            }
        }

        // DELETE: api/MuseumsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuseum(int id)
        {
            var museum = await _context.Museums.FindAsync(id);
            if (museum == null)
                return NotFound();

            _context.Museums.Remove(museum);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
