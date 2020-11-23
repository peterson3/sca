using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SCA.Barragens.API.DataStorage;
using SCA.Barragens.API.HubConfig;
using SCA.Barragens.API.TimerFeatures;

namespace SCA.Barragens.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly IHubContext<SensorHub> _hub;

        public SensorController(IHubContext<SensorHub> hub)
        {
            _hub = hub;
        }


        public IActionResult Get()
        {
            return Ok(new { Message = "Request Completed" });
        }
    }
}
