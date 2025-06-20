using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Museum_Locator.Data;
using Museum_Locator.Models;

namespace Museum_Locator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuseumFacilityApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MuseumFacilityApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MuseumFacility>>> GetMuseumFacilities()
        {
            return await _context.MuseumFacilities
                .Include(mf => mf.Museum)
                .Include(mf => mf.Facility)
                .ToListAsync();
        }
    }
}