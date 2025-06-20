using Museum_Locator.Models;

namespace Museum_Locator.Services
{
    public interface IMuseumService
    {
        Task<List<Museum>> GetAllMuseumsAsync();
        Task<Museum?> GetMuseumByIdAsync(int id);
        Task AddMuseumAsync(Museum museum);
        Task UpdateMuseumAsync(Museum museum);
        Task DeleteMuseumAsync(int id);
    }
}