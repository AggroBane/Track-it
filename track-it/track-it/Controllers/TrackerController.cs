using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using track_it.Data;
using track_it.Entities;

namespace track_it.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class TrackerController
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
    }
}
