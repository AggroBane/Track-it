using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpPost("")]
        public async Task<IActionResult> Index()
        {
            try
            {
                string rawPayload = null;
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    rawPayload = await reader.ReadToEndAsync();
                }

                var payload = JsonConvert.DeserializeObject<OysterPayload>(rawPayload);
                var serialNo = payload.SerNo?.ToString() ?? "";

                var associatedTracker = _context.Trackers.FirstOrDefault(x => x.Id == serialNo);
                var firstField = payload.Records.FirstOrDefault()?.Fields.FirstOrDefault();
                if (associatedTracker == null || firstField == null) return BadRequest();

                associatedTracker.LastPingUtc = DateTime.UtcNow;
                associatedTracker.Lat = firstField.Lat ?? 0;
                associatedTracker.Lng = firstField.Long ?? 0;

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
