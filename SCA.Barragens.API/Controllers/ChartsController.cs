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
    public class ChartsController : ControllerBase
    {
        //private readonly IHubContext<ChartHub> _hub;

        //public ChartsController(IHubContext<ChartHub> hub)
        //{
        //    _hub = hub;
        //}


        public IActionResult Get()
        {
            //Request.Headers.Add("Access-Control-Allow-Origin", "*");
            //Request.Headers.Add("Access-Control-Allow-Credentials", "true");
            //Request.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE,HEAD,OPTIONS");

            //var timerManaer = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));

            //Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            //Response.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE,HEAD,OPTIONS");


            return Ok(new { Message = "Request Completed" });




        }
    }
}
