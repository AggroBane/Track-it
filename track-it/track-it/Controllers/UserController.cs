using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using track_it.Data;
using track_it.Entities;

namespace track_it.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{userId}/assets")]
        public List<Asset> Get([FromRoute] string userId)
        {
            return _context.Assets.Where(x => x.UserId == userId).Include(x => x.Tracker).Include(x => x.User).ToList();
        }
    }
}
