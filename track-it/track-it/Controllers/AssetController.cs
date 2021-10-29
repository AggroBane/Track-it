using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using track_it.Data;
using track_it.Entities;

namespace track_it.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssetController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{userId}")]
        public List<Asset> Get([FromRoute] string userId)
        {
            return _context.Assets.Where(x => x.UserId == userId).ToList();
        }
    }
}
