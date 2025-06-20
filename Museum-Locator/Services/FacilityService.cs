using Microsoft.EntityFrameworkCore;
using Museum_Locator.Data;
using Museum_Locator.Models;

namespace Museum_Locator.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly ApplicationDbContext _context;

        public FacilityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Facility>> GetAllFacilitiesAsync()
        {
            return await _context.Facilities
                .Include(f => f.MuseumFacilities)
                .ThenInclude(mf => mf.Museum)
                .ToListAsync();
        }

        public async Task<Facility?> GetFacilityByIdAsync(int id)
        {
            return await _context.Facilities
                .Include(f => f.MuseumFacilities)
                .ThenInclude(mf => mf.Museum)
                .FirstOrDefaultAsync(f => f.FacilityId == id);
        }

        public async Task AddFacilityAsync(Facility facility)
        {
            _context.Facilities.Add(facility);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFacilityAsync(Facility facility)
        {
            _context.Entry(facility).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFacilityAsync(int id)
        {
            var facility = await _context.Facilities.FindAsync(id);
            if (facility != null)
            {
                _context.Facilities.Remove(facility);
                await _context.SaveChangesAsync();
            }
        }
    }
}