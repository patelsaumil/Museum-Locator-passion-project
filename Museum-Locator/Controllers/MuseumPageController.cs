using Microsoft.AspNetCore.Mvc;
using Museum_Locator.Models;
using Museum_Locator.Services;

namespace Museum_Locator.Controllers
{
    public class MuseumPageController : Controller
    {
        private readonly IMuseumService _service;

        public MuseumPageController(IMuseumService service)
        {
            _service = service;
        }

        public async Task<IActionResult> List()
        {
            var museums = await _service.GetAllMuseumsAsync();
            return View(museums);
        }

        public async Task<IActionResult> Details(int id)
        {
            var museum = await _service.GetMuseumByIdAsync(id);
            if (museum == null) return NotFound();
            return View(museum);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Museum museum)
        {
            if (ModelState.IsValid)
            {
                await _service.AddMuseumAsync(museum);
                return RedirectToAction(nameof(List));
            }
            return View(museum);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var museum = await _service.GetMuseumByIdAsync(id);
            if (museum == null) return NotFound();
            return View(museum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Museum museum)
        {
            if (id != museum.MuseumId) return BadRequest();

            if (ModelState.IsValid)
            {
                await _service.UpdateMuseumAsync(museum);
                return RedirectToAction(nameof(List));
            }
            return View(museum);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var museum = await _service.GetMuseumByIdAsync(id);
            if (museum == null) return NotFound();
            return View(museum);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteMuseumAsync(id);
            return RedirectToAction(nameof(List));
        }
    }
}
