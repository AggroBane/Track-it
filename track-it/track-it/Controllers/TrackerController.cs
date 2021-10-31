using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using track_it.Data;
using track_it.Entities;

namespace track_it.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TrackerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{serialId}")]
        public List<Tracker> Get([FromRoute] string serialId)
        {
            return _context.Trackers.Where(x => x.Id == serialId).ToList();
        }

        [HttpGet]
        [Route("")]
        public List<Tracker> GetAll()
        {
            return _context.Trackers.ToList();
        }

        [HttpDelete]
        [Route("{serialId}")]
        public async Task<IActionResult> Delete([FromRoute] string serialId)
        {
            var tracker = await _context.Trackers.FirstOrDefaultAsync(x => x.Id == serialId);

            if (tracker != null)
            {
                _context.Trackers.Remove(tracker);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] Tracker tracker)
        {
            if (tracker == null) return BadRequest();
            if (tracker.Id == null) return BadRequest();

            var isExisting = await _context.Trackers.AnyAsync(x => x.Id == tracker.Id);
            if (isExisting) return BadRequest();

            await _context.Trackers.AddAsync(tracker);

            return Created("tracker/" + tracker.Id, tracker);
        }

        [HttpPost]
        [Route("updatePosition")]
        public async Task<IActionResult> GetDataFromOyster([FromBody] OysterPayload payload)
        {
            var serialNo = payload.SerNo?.ToString() ?? "";

            var associatedTracker = await _context.Trackers.FirstOrDefaultAsync(x => x.Id == serialNo);
            if (associatedTracker == null) return BadRequest();

            var firstField = payload.Records.FirstOrDefault()?.Fields.FirstOrDefault();
            if (firstField == null) return BadRequest();

            associatedTracker.LastPingUtc = DateTime.UtcNow;
            associatedTracker.Lat = firstField.Lat ?? 0;
            associatedTracker.Lng = firstField.Long ?? 0;

            _context.Trackers.Update(associatedTracker);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
