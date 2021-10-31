using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using track_it.Data;
using track_it.DTOs;

namespace track_it.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PhoneController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("{serialId}")]
        public async Task<IActionResult> GetDataFromPhone([FromRoute] string serialId, [FromBody] PhonePayload request)
        {
            var tracker = await _context.Trackers.FirstOrDefaultAsync(x => x.Id == serialId);
            if (tracker == null) return NotFound();

            tracker.Lat = request.Lat;
            tracker.Lng = request.Lng;
            tracker.LastPingUtc = DateTime.UtcNow;

            _context.Trackers.Update(tracker);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
