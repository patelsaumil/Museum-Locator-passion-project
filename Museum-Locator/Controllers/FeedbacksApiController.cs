using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Museum_Locator.Data;
using Museum_Locator.Models;

namespace Museum_Locator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeedbacksApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            return await _context.Feedbacks.Include(f => f.User).Include(f => f.Museum).ToListAsync();
        }
    }
}
