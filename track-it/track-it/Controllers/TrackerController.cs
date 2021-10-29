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
        public async Task<List<User>> Get()
        {
            _context.Users.Add(new User() { Id = "test" });
            await _context.SaveChangesAsync();

            return _context.Users.ToList();
        }
    }
}
