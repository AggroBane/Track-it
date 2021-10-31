using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if ((await _dbContext.Assets.CountAsync()) > 0) _dbContext.Assets.RemoveRange(_dbContext.Assets);
            if ((await _dbContext.Trackers.CountAsync()) > 0) _dbContext.Trackers.RemoveRange(_dbContext.Trackers);
            if ((await _dbContext.Users.CountAsync()) > 0) _dbContext.Users.RemoveRange(_dbContext.Users);
            await _dbContext.SaveChangesAsync();

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

            var tracker2 = new Tracker()
            {
                Id = "10397109101114",
                Lat = 40.6122032,
                Lng = -72.1084072,
                LastPingUtc = DateTime.UtcNow
            };
            await _dbContext.Trackers.AddAsync(tracker);
            await _dbContext.Trackers.AddAsync(tracker2);

            await _dbContext.Assets.AddAsync(new Asset()
            {
                Id = "Auto",
                Type = AssetType.CAR,
                Tracker = tracker,
                User = user,
                ImageUrl = ""
            });

            await _dbContext.Assets.AddAsync(new Asset()
            {
                Id = "Cell",
                Type = AssetType.PHONE,
                Tracker = tracker2,
                User = user,
                ImageUrl = ""
            });

            await _dbContext.SaveChangesAsync();

            return Ok("Database seeded");
        }
    }
}
