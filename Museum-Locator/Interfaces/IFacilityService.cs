using Museum_Locator.Models;

namespace Museum_Locator.Services
{
    public interface IFacilityService
    {
        Task<List<Facility>> GetAllFacilitiesAsync();
        Task<Facility?> GetFacilityByIdAsync(int id);
        Task AddFacilityAsync(Facility facility);
        Task UpdateFacilityAsync(Facility facility);
        Task DeleteFacilityAsync(int id);
    }
}