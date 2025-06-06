using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Museum_Locator.Data;
using Museum_Locator.Models;

namespace Museum_Locator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Museum_FacilityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Museum_FacilityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Museum_Facility
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Museum_Facility>>> GetMuseum_Facilities()
        {
            return await _context.Museum_Facilities.ToListAsync();
        }

        // GET: api/Museum_Facility/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Museum_Facility>> GetMuseum_Facility(int id)
        {
            var museum_Facility = await _context.Museum_Facilities.FindAsync(id);

            if (museum_Facility == null)
            {
                return NotFound();
            }

            return museum_Facility;
        }

        // PUT: api/Museum_Facility/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuseum_Facility(int id, Museum_Facility museum_Facility)
        {
            if (id != museum_Facility.Museum_Id)
            {
                return BadRequest();
            }

            _context.Entry(museum_Facility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Museum_FacilityExists(id))
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

        // POST: api/Museum_Facility
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Museum_Facility>> PostMuseum_Facility(Museum_Facility museum_Facility)
        {
            _context.Museum_Facilities.Add(museum_Facility);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Museum_FacilityExists(museum_Facility.Museum_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMuseum_Facility", new { id = museum_Facility.Museum_Id }, museum_Facility);
        }

        // DELETE: api/Museum_Facility/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuseum_Facility(int id)
        {
            var museum_Facility = await _context.Museum_Facilities.FindAsync(id);
            if (museum_Facility == null)
            {
                return NotFound();
            }

            _context.Museum_Facilities.Remove(museum_Facility);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Museum_FacilityExists(int id)
        {
            return _context.Museum_Facilities.Any(e => e.Museum_Id == id);
        }
    }
}
