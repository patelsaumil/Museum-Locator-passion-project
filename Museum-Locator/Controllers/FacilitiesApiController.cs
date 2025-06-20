using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Museum_Locator.Data;
using Museum_Locator.Models;
using Museum_Locator.DTOs;

namespace Museum_Locator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FacilitiesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacilityDto>>> GetFacilities()
        {
            var facilities = await _context.Facilities
                .Include(f => f.MuseumFacilities)
                    .ThenInclude(mf => mf.Museum)
                .ToListAsync();

            var result = facilities.Select(f => new FacilityDto
            {
                Id = f.FacilityId,
                FacilityName = f.FacilityName,
                MuseumNames = f.MuseumFacilities.Select(mf => mf.Museum.MuseumName).ToList()
            }).ToList();

            return Ok(result);
        }
    }
}