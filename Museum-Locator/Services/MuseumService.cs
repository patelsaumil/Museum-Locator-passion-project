using Microsoft.EntityFrameworkCore;
using Museum_Locator.Data;
using Museum_Locator.Models;

namespace Museum_Locator.Services
{
    public class MuseumService : IMuseumService
    {
        private readonly ApplicationDbContext _context;

        public MuseumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Museum>> GetAllMuseumsAsync()
        {
            return await _context.Museums
                .Include(m => m.MuseumFacilities)
                    .ThenInclude(mf => mf.Facility)
                .Include(m => m.Feedbacks)
                .ToListAsync();
        }

        public async Task<Museum?> GetMuseumByIdAsync(int id)
        {
            return await _context.Museums
                .Include(m => m.MuseumFacilities)
                    .ThenInclude(mf => mf.Facility)
                .Include(m => m.Feedbacks)
                .FirstOrDefaultAsync(m => m.MuseumId == id);
        }

        public async Task AddMuseumAsync(Museum museum)
        {
            _context.Museums.Add(museum);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMuseumAsync(Museum museum)
        {
            _context.Entry(museum).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMuseumAsync(int id)
        {
            var museum = await _context.Museums.FindAsync(id);
            if (museum != null)
            {
                _context.Museums.Remove(museum);
                await _context.SaveChangesAsync();
            }
        }
    }
}