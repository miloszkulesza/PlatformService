﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {
            
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Commands Service");
            return Ok("Inbound test of Platforms Controller");
        }
    }
}
