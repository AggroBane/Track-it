using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using track_it.Data;
using track_it.Entities;

namespace track_it.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public TestController(AppDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }

        [HttpGet]
        [Route("seed")]
        public async Task<IActionResult> SeedDb()
        {
            if (!_env.IsDevelopment()) return NotFound();

            var user = new User()
            {
                Id = "gamer"
            };
            await _dbContext.Users.AddAsync(user);


            var tracker = new Tracker()
            {
                Id = "139946",
                Lat = 47.6120085,
                Lng = -70.1074071,
                LastPingUtc = DateTime.UtcNow
            };
            await _dbContext.Trackers.AddAsync(tracker);

            await _dbContext.Assets.AddAsync(new Asset()
            {
                Id = "Auto",
                Type = AssetType.CAR,
                Tracker = tracker,
                User = user
            });

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
