using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using track_it.Entities;

namespace track_it.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        [HttpGet]
        [Route("/asset")]
        public Asset Get()
        {
            return new Asset();
        }
    }
}
