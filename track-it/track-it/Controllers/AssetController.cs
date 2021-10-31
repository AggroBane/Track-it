using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using track_it.Data;
using track_it.DTOs;
using track_it.Entities;

namespace track_it.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssetController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{assetId}")]
        public async Task<Asset> Get([FromRoute] string assetId)
        {
            return await _context.Assets.FirstOrDefaultAsync(x => x.Id == assetId);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] CreateAssetRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null) return BadRequest("User id not found");

            var tracker = await _context.Trackers.FirstOrDefaultAsync(x => x.Id == request.TrackerId);
            if (tracker == null) return BadRequest("Tracker id not found");

            var createdAsset = new Asset()
            {
                Id = request.Id,
                Tracker = tracker,
                User = user,
                Type = request.Type,
                ImageUrl = request.ImageUrl
            };

            await _context.Assets.AddAsync(createdAsset);
            await _context.SaveChangesAsync();

            return Created("asset/" + createdAsset.Id, createdAsset);
        }

        [HttpPut]
        [Route("{assetId}")]
        public async Task<IActionResult> Modify([FromRoute] string assetId, [FromBody] EditAssetRequest request)
        {
            var asset = await _context.Assets.FirstOrDefaultAsync(x => x.Id == assetId);
            if (asset == null) return NotFound();

            User user = null;
            if (request.UserId != null)
            {
                user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
                if (user == null) return BadRequest("User id not found");
            }

            Tracker tracker = null;
            if (request.TrackerId != null)
            {
                tracker = await _context.Trackers.FirstOrDefaultAsync(x => x.Id == request.TrackerId);
                if (tracker == null) return BadRequest("Tracker id not found");
            }



            if (user != null) asset.User = user;
            if (tracker != null) asset.Tracker = tracker;
            if (request.Type != null) asset.Type = (AssetType)request.Type;
            if (request.ImageUrl != null) asset.ImageUrl = request.ImageUrl;

            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete]
        [Route("{assetId}")]
        public async Task<IActionResult> Delete([FromRoute] string assetId)
        {
            var asset = await _context.Assets.FirstOrDefaultAsync(x => x.Id == assetId);

            if (asset != null)
            {
                _context.Assets.Remove(asset);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}
